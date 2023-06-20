using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonkeyKongGame
{
    public class EntityFactory : IEntityFactory
    {
        private IGameplay _g;

        public EntityFactory(IGameplay g) 
        {
            this._g = g;
        }

        public IEntity GeneratePlayer(Pair<float, float> pos)
        {
            return new Entity(Type.PLAYER, pos, _g)
                .AddComponent(new CollisionComponent(pos.GetX, pos.GetY))
                .AddComponent(new MovementComponent());
        }

        public IEntity GeneratePrincess(Pair<float, float> pos)
        {
            return new Entity(Type.PRINCESS, pos, _g)
                .AddComponent(new CollisionComponent(pos.GetX, pos.GetY));
        }
    }
}
