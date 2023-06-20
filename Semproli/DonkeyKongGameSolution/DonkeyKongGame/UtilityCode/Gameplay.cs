using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongGame
{
    public class Gameplay : IGameplay
    {
        public List<IEntity> Entities { get; }

        public Gameplay() => Entities = new List<IEntity>();

        public void AddEntity<E>(E entity) where E : IEntity
        {
            Entities.Add(entity);
        }

        public void RemoveEntity<E>(E entity) where E : IEntity
        {
            Entities.Remove(entity);
        }
    }
}
