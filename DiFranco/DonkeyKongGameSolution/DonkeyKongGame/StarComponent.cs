using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongGame
{
    public class StarComponent : AbstractComponent
    {
        public bool IsInvincible { get; set; }
        private int timeElapsed;

        public StarComponent()
        {
            IsInvincible = false;
            timeElapsed = 0;
        }

        public override void Update()
        {
            timeElapsed++;
            if (IsInvincible && timeElapsed > 240)
            {
                IsInvincible = false;
            }
        }
        public void SetInvincible(bool isInvincible)
        {
            this.IsInvincible = isInvincible;
            if (isInvincible)
            {
                timeElapsed = 0;
            }
        }
    }
}
