using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DonkeyKongGame
{
    public class Entity : IEntity
    {
        private readonly HashSet<IComponent> _components;

        public Type Etype { get; set; }
        public Pair<float, float> Position { get; set; }
        public Pair<float, float>? NextPosition { get; set; }
        public IGameplay Gameplay { get; set; }
        public float? Speed { get; set; }

        public Entity(Type type, Pair<float, float> position, IGameplay gameplay)
        {
            Etype = type;
            Position = position;
            _components = new HashSet<IComponent>();
            Gameplay = gameplay;
            if(type == Type.PLAYER)
            {
                Speed = 2f;
            } 
            else if (type == Type.BARREL)
            {
                Speed = 2f;
            }
        }

        public HashSet<IComponent> AllComponents
        {
            get { return new HashSet<IComponent>(_components); }
        }

        public IEntity AddComponent(AbstractComponent c)
        {
            c.Entity = this;
            _components.Add(c);
            return this;
        }

        public C? GetComponent<C>() where C : IComponent
        {
            return _components.OfType<C>().FirstOrDefault();
        }

        public void SaveNextPosition(Pair<float, float>? nextPos)
        {
            NextPosition = nextPos != null ? new Pair<float, float>(Position.GetX + nextPos.GetX, Position.GetY + nextPos.GetY) : null;
        }
    }
}
