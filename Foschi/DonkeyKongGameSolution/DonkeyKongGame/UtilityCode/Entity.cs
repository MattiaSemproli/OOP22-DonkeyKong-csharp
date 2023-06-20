namespace DonkeyKongGame
{
    public class Entity : IEntity
    {
        private readonly HashSet<IComponent> _components;

        public Type Etype { get; set; }
        public Pair<float, float> Position { get; set; }
        public IGameplay Gameplay { get; set; }
        public Entity(Type type, Pair<float, float> position, IGameplay gameplay)
        {
            Etype = type;
            Position = position;
            _components = new HashSet<IComponent>();
            Gameplay = gameplay;
        }

        public HashSet<IComponent> AllComponents
        {
            get { return new HashSet<IComponent>(_components); }
        }

        public IEntity AddComponent(AbstractComponent c)
        {
            c.Entity = this;
            _components.Add(c);
            return this;
        }

        public C? GetComponent<C>() where C : IComponent
        {
            return _components.OfType<C>().FirstOrDefault();
        }

        
    }
}