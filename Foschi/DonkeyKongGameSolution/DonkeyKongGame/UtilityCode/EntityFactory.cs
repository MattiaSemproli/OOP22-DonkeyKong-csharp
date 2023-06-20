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
                        .AddComponent(new HealthComponent());
        }

        public IEntity GenerateBarrel(Pair<float, float> pos)
        {
            return new Entity(Type.BARREL, pos, _g)
                        .AddComponent(new DoubleDamageComponent());
        }

        public IEntity GenerateMonkey(Pair<float, float> pos)
        {
            return new Entity(Type.MONKEY, pos, _g)
                        .AddComponent(new ThrowComponent());
        }

        public IEntity GeneratePrincess(Pair<float, float> pos)
        {
            return new Entity(Type.PRINCESS, pos, _g);
        }
    }
}