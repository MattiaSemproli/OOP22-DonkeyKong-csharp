using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongGame
{
    public interface IEntityFactory
    {
        IEntity GeneratePlayer(Pair<float, float> pos);
    }
}
