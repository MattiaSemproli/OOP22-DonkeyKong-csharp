namespace DonkeyKongGame
{
    public class DoubleDamageComponent : AbstractComponent
    {
        public bool IsDoubleDamage { get; set; }

        public DoubleDamageComponent() {
            IsDoubleDamage = false;
        }

        public override void Update() {
        }
    }
}