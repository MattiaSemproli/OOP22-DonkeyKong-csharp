namespace DonkeyKongGame
{
    public interface IEntityFactory
    {
        IEntity GeneratePlayer(Pair<float, float> pos);

        IEntity GenerateMonkey(Pair<float, float> pos);

        IEntity GeneratePrincess(Pair<float, float> pos);

        IEntity GenerateBarrel(Pair<float, float> pos);

    }
}