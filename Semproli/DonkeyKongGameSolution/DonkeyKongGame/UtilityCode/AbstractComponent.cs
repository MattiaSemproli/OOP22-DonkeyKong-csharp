namespace DonkeyKongGame
{
    public abstract class AbstractComponent : IComponent
    {
        public IEntity? Entity { get; set; }

        public abstract void Update();

    }
}
