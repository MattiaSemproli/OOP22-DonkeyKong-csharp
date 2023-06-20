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
            _timeElapsed++;
            if (!IsFrozen && _timeElapsed > 130)
            {
                this.Entity.Gameplay.ThrowBarrel(new Pair<float, float>(0, 0));
                _timeElapsed = 0;
                IsThrowing = false;
            }
            else if (!IsFrozen
                 && _timeElapsed < 130
                 && _timeElapsed > 130 - 75)
            {
                IsThrowing = true;
            }
        }
    }
}