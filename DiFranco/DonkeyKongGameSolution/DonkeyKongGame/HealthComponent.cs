namespace DonkeyKongGame
{
    public class HealthComponent : AbstractComponent
    {
        public int Lives { get; set; }

        public HealthComponent(int numLives)
        {
            Lives = numLives;
        }

        public override void Update()
        {
        }

        public void SetLives(int lives)
        {
            this.Lives = (this.Lives + lives) > 3 ? 3 : (this.Lives + lives);
            this.Lives = this.Lives < 0 ? 0 : this.Lives;
        }
    }
}
