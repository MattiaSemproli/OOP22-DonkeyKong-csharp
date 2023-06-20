namespace DonkeyKongGame
{
    public interface IEntityFactory
    {
        IEntity GeneratePlayer(Pair<float, float> pos);

        IEntity GenerateBarrel(Pair<float, float> pos);
        IEntity GenerateStarPowerUp(Pair<float, float> pos);
        IEntity GenerateShieldPowerUp(Pair<float, float> pos);
        IEntity GenerateSnowflakePowerUp(Pair<float, float> pos);
        IEntity GenerateHeartPowerUp(Pair<float, float> pos);

    }
}