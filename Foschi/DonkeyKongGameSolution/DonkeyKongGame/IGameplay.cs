namespace DonkeyKongGame
{
    public interface IGameplay
    {

        List<IEntity> Entities { get; }

        void InitializeGame();

        void AddEntity(IEntity IEntity);

        void RemoveEntity(IEntity IEntity);

        void ThrowBarrel(Pair<float, float> position);

        void RemoveAllBarrels();

        void RemovePlayer();

        void SetWin();

        bool IsWin();

        void CheckIsOver();

        bool IsOver();
    }
}
