#pragma warning disable CS8602
#pragma warning disable CS8601
#pragma warning disable CS8600
using DonkeyKongGame;
using System.Drawing;

namespace DonkeyKongGame
{
    public class CollisionComponent : AbstractComponent
    {
        private RectangleF hitbox;
        private readonly float x, y;
        private int width, height;
        private Pair<float, float>? nextPosition = null;
        private const int DEFAULT_WALL = 500;
        private const int DEFAULT_DIMENSION = 48;

        public CollisionComponent(float x, float y)
        {
            this.x = x;
            this.y = y;
            initDifferentHitbox();
        }

        public override void Update()
        {
            this.nextPosition = this.Entity.NextPosition;
            IEntity entity = this.Entity;
            Type eType = this.Entity.Etype;
            if (this.nextPosition != null)
            {
                this.hitbox.X = nextPosition.GetX;
                this.hitbox.Y = nextPosition.GetY;
                if (eType == Type.PLAYER)
                {
                    this.CheckPlayerWallCollision(entity);
                }
            }
            else
            {
                this.nextPosition = this.Entity.Position;
                this.hitbox.X = nextPosition.GetX;
                this.hitbox.Y = nextPosition.GetY;
            }
            if (eType == Type.PLAYER)
            {
                this.CheckIsCollidingWithOtherEntities(entity);
            }
        }

        private void CheckPlayerWallCollision(IEntity entity) 
        {
            if(hitbox.Y > DEFAULT_WALL) 
            {
                entity.Gameplay.RemoveEntity(entity);
            }
            else if(hitbox.X > DEFAULT_WALL - DEFAULT_DIMENSION)
            {
                entity.Position = new Pair<float, float>(DEFAULT_WALL - DEFAULT_DIMENSION, this.nextPosition.GetY);
            }
            else if (hitbox.Y < 0)
            {
                entity.Position = new Pair<float, float>(this.nextPosition.GetX, 0);
            }
            else if (hitbox.X < 0)
            {
                entity.Position = new Pair<float, float>(0f, this.nextPosition.GetY);
            }
            else
            {
                entity.Position = this.nextPosition;
            }
        }

        private void CheckIsCollidingWithOtherEntities(IEntity entity) 
        {
            entity.Gameplay.Entities
                .Where(e => !e.Equals(entity) && this.CheckIsNotBlock(e.Etype))
                .Where(e => hitbox.IntersectsWith(e.GetComponent<CollisionComponent>().Gethitbox()))
                .ToList()
                .ForEach(e => 
                {
                    StarComponent sc = entity.GetComponent<StarComponent>();
                    ShieldComponent shc = entity.GetComponent<ShieldComponent>();
                    FreezeComponent sfc = entity.GetComponent<FreezeComponent>();
                    HealthComponent hc = entity.GetComponent<HealthComponent>();
                    MovementComponent mc = entity.GetComponent <MovementComponent>();
                    if (e.Etype == Type.BARREL)
                    {
                        if (!sc.IsInvincible) 
                        {
                            if (!shc.shielded)
                            {
                                if (e.GetComponent<DoubleDamageComponent>().IsDoubleDamage)
                                {
                                    hc.SetLives(-2);
                                }
                                else 
                                {
                                    hc.SetLives(-1);
                                }
                            }
                            else
                            {
                                if (e.GetComponent<DoubleDamageComponent>().IsDoubleDamage)
                                {
                                    hc.SetLives(-1);
                                }
                                shc.shielded = false;
                            }
                        }
                        else
                        {
                            shc.shielded = false;
                        }
                        entity.Gameplay.RemoveEntity(e);
                    }
                    if (e.Etype == Type.STAR)
                    {
                        sc.IsInvincible = true;
                        entity.Gameplay.RemoveEntity(e);
                    }
                    if(e.Etype == Type.SHIELD)
                    {
                        shc.shielded = true;
                        entity.Gameplay.RemoveEntity(e);
                    }
                    if(e.Etype == Type.SNOWFLAKE)
                    {
                        sfc.freezer = true;
                        entity.Gameplay.RemoveEntity(e);
                    }
                    if(e.Etype == Type.HEART && hc.Lives < 3)
                    {
                        hc.SetLives(1);
                        entity.Gameplay.RemoveEntity(e);
                    }
                });
        }

        private bool CheckIsNotBlock(Type type)
        {
            return type != Type.BLOCK
                && type != Type.BLOCK_LADDER_DOWN
                && type != Type.BLOCK_LADDER_UP
                && type != Type.BLOCK_LADDER_UPDOWN;
        }

        public RectangleF Gethitbox()
        {
            return new RectangleF(hitbox.X, hitbox.Y, hitbox.Width, hitbox.Height);
        }

        private void initDifferentHitbox()
        {
            width = DEFAULT_DIMENSION;
            height = DEFAULT_DIMENSION;
            hitbox = new RectangleF(x, y, width, height);
        }
    }
}
