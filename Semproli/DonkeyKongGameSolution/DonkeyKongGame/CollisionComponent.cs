#pragma warning disable CS8602
#pragma warning disable CS8600
using DonkeyKongGame;
using System.Diagnostics;
using System;
using System.Drawing;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    this.checkPlayerPlatformCollision(entity);
                    this.checkPlayerLadderCollision(entity);
                    this.checkPlayerWallCollision(entity);
                    this.checkPlayerState(entity);
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
                this.checkIsCollidingWithOtherEntities(entity);
            }
        }

        private void checkPlayerPlatformCollision(IEntity entity)
        {
            MovementComponent mc = entity.GetComponent<MovementComponent>();
            if(this.nextPosition.GetY > entity.Position.GetY)
            {
                entity.Gameplay.Entities
                    .Where(e => !this.checkIsNotBlock(e.Etype))
                    .Where(e =>
                    {
                        RectangleF e2Hitbox = e.GetComponent<CollisionComponent>().Gethitbox();
                        
                    });
            }
        }

        private bool checkIsNotBlock(Type type)
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
