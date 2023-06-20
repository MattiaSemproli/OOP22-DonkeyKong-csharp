#pragma warning disable CS8602

namespace DonkeyKongGame
{
    public class ThrowComponent : AbstractComponent
    {
        public bool IsFrozen { get; set; }
        public bool IsThrowing { get; set; }
        private int _timeElapsed = 130;
        
        public ThrowComponent()
        {
            IsFrozen = false;
            IsThrowing = false;
        }

        public override void Update()
        {
        }
    }
}