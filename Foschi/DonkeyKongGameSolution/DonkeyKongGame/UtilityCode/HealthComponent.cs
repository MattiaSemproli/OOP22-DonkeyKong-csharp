namespace DonkeyKongGame
{
    public class HealthComponent : AbstractComponent
    {
        public int Lifes { get; set; }

        public HealthComponent() {
            Lifes = 3;
        }

        public override void Update() {
        }
    }
}