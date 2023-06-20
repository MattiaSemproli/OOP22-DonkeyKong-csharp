using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongGame
{
    public interface IGameplay
    {
        List<IEntity> Entities { get; }

        void AddEntity<E>(E entity) where E : IEntity;

        void RemoveEntity<E>(E entity) where E : IEntity;
    }
}
