using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongGame
{
    public class ShieldComponent : AbstractComponent
    {
        public bool shielded { get; set; }

        public ShieldComponent()
        {
            shielded = false;
        }

        public override void Update()
        {
        }
    }
}
