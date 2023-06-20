namespace DonkeyKongGame
{
    public interface IEntity
    {
        HashSet<IComponent> AllComponents { get; }

        Type Etype { get; set; }

        IEntity AddComponent(AbstractComponent c);

        C? GetComponent<C>() where C : IComponent;

        Pair<float, float> Position { get; set; }

        Pair<float, float>? NextPosition { get; set; }

        IGameplay Gameplay { get; set; }

        float? Speed { get; set; }

        void SaveNextPosition(Pair<float, float>? nextPos);
    }
}