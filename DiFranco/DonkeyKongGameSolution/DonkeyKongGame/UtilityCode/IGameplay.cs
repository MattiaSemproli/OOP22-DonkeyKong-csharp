namespace DonkeyKongGame
{
    public interface IGameplay
    {

        List<IEntity> Entities { get; }

        void AddEntity(IEntity IEntity);

        void RemoveEntity(IEntity IEntity);

        List<int> KeyInputs { get; }
        void UpdateKeyPressed(int key);
        void UpdateKeyReleased(int key);
        void ResetKeys();
    }
}
