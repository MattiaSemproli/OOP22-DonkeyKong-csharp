#pragma warning disable CS8602

namespace DonkeyKongGame
{
    public class Gameplay : IGameplay
    {
        private IEntityFactory EntityFactory;
        public List<IEntity> Entities { get; }
        private Random random = new Random();
        private bool _win;

        public Gameplay()
        {
            _win = false;
            Entities = new List<IEntity>();
            EntityFactory = new EntityFactory(this);
        }

        public void InitializeGame()
        {
            this.GenerateInteractableEntities();
        }

        private void GenerateInteractableEntities()
        {
            this.Entities.Add(EntityFactory.GeneratePlayer(new Pair<float, float>(0, 0)));
            this.Entities.Add(EntityFactory.GenerateMonkey(new Pair<float, float>(50, 50)));
            this.Entities.Add(EntityFactory.GeneratePrincess(new Pair<float, float>(50, 0)));
        }

        public bool IsWin()
        {
            return _win;
        }

        public void SetWin()
        {
            _win = true;
        }

        public bool IsOver()
        {
            if (!this.Entities.Any(e => e.Etype == Type.PLAYER))
            {
                return true;
            }
            return false;
        }

        public void CheckIsOver()
        {
            if (!IsOver() && !HasPlayerLife())
            {
                RemovePlayer();
            }
        }

        private bool HasPlayerLife()
        {
            return this.Entities
                .Where(_e => _e.Etype == Type.PLAYER)
                .Select(_e => _e.GetComponent<HealthComponent>().Lifes)
                .FirstOrDefault() > 0;
        }

        public void ThrowBarrel(Pair<float, float> position)
        {
            IEntity Barrel = EntityFactory.GenerateBarrel(position);
            if (new Random().Next(10) < 3)
            {
                Barrel.GetComponent<DoubleDamageComponent>().IsDoubleDamage = true;
            }
            Entities.Add(Barrel);
        }

        public void AddEntity(IEntity IEntity)
        {
            Entities.Add(IEntity);
        }

        public void RemoveEntity(IEntity IEntity)
        {
            Entities.Remove(IEntity);
        }

        public void RemoveAllBarrels()
        {
            Entities.RemoveAll(_e => _e.Etype == Type.BARREL);
        }

        public void RemovePlayer()
        {
            Entities.RemoveAll(_e => _e.Etype == Type.PLAYER);
        }

    }
}
