namespace DonkeyKongGame
{
    public class EntityFactory : IEntityFactory
    {
        private IGameplay _g;

        public EntityFactory(IGameplay g) 
        {
            this._g = g;
        }

        public IEntity GeneratePlayer(Pair<float, float> pos)
        {
            return new Entity(Type.PLAYER, pos, _g)
                        .AddComponent(new HealthComponent(3))
                        .AddComponent(new InputsComponent())
                        .AddComponent(new MovementComponent())
                        .AddComponent(new CollisionComponent(pos.GetX, pos.GetY))
                        .AddComponent(new StarComponent())
                        .AddComponent(new ShieldComponent())
                        .AddComponent(new FreezeComponent());
        }

        public IEntity GenerateBarrel(Pair<float, float> pos)
        {
            return new Entity(Type.BARREL, pos, _g)
                        .AddComponent(new DoubleDamageComponent())
                        .AddComponent(new CollisionComponent(pos.GetX, pos.GetY));
        }

        public IEntity GenerateStarPowerUp(Pair<float, float> pos)
        {
            return new Entity(Type.STAR, pos, _g)
                        .AddComponent(new CollisionComponent(pos.GetX, pos.GetY));
        }

        public IEntity GenerateShieldPowerUp(Pair<float, float> pos)
        {
            return new Entity(Type.SHIELD, pos, _g)
                        .AddComponent(new CollisionComponent(pos.GetX, pos.GetY));
        }

        public IEntity GenerateSnowflakePowerUp(Pair<float, float> pos)
        {
            return new Entity(Type.SNOWFLAKE, pos, _g)
                        .AddComponent(new CollisionComponent(pos.GetX, pos.GetY));
        }

        public IEntity GenerateHeartPowerUp(Pair<float, float> pos)
        {
            return new Entity(Type.HEART, pos, _g)
                        .AddComponent(new CollisionComponent(pos.GetX, pos.GetY));
        }
    }
}