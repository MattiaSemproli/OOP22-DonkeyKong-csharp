#pragma warning disable CS8600
#pragma warning disable CS8602
namespace DonkeyKongGame
{
    public class FreezeComponent : AbstractComponent
    {
        public bool freezer { get; set; }
        private int timeElapsed;

        public FreezeComponent()
        {
            freezer = false;
            timeElapsed = 0;
        }

        public override void Update()
        {
            timeElapsed++;
            if (freezer && timeElapsed > 480)
            {
                freezer = false;
                SetMonkeyFreezer(freezer);
            }
        }

        public void SetFrozen(bool freezer)
        {
            this.freezer = freezer;
            if (freezer)
            {
                timeElapsed = 0;
                SetMonkeyFreezer(freezer);
            }
        }

        private void SetMonkeyFreezer(bool freezer)
        {
            IEntity monkey = this.Entity.Gameplay.Entities
                .FirstOrDefault(e => e.Etype == Type.MONKEY);
            if (monkey != null)
            {
                monkey.GetComponent<ThrowComponent>().IsFrozen = freezer;
            }
        }
    }
}
