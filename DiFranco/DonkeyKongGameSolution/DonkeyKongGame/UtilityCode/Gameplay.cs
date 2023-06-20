#pragma warning disable CS8602

namespace DonkeyKongGame
{
    public class Gameplay : IGameplay
    {
        private const int MOVE_LEFT = 65;
        private const int MOVE_RIGHT = 68;
        private const int MOVE_UP = 87;
        private const int MOVE_DOWN = 83;
        private const int JUMP = 32;
        private const int MOVE_LEFT_ARROW = 37;
        private const int MOVE_RIGHT_ARROW = 39;
        private const int MOVE_UP_ARROW = 38;
        private const int MOVE_DOWN_ARROW = 40;
        private List<int> movementCodes = new List<int>();
        public List<IEntity> Entities { get; }
        public List<int> KeyInputs { get; }
        private Random random = new Random();

        public Gameplay()
        {
            Entities = new List<IEntity>();
            KeyInputs = new List<int>();
            movementCodes.Add(MOVE_LEFT);
            movementCodes.Add(MOVE_RIGHT);
            movementCodes.Add(MOVE_DOWN);
            movementCodes.Add(MOVE_UP);
            movementCodes.Add(MOVE_LEFT_ARROW);
            movementCodes.Add(MOVE_RIGHT_ARROW);
            movementCodes.Add(MOVE_DOWN_ARROW);
            movementCodes.Add(MOVE_UP_ARROW);
            movementCodes.Add(JUMP);
        }

        public void AddEntity(IEntity IEntity)
        {
            Entities.Add(IEntity);
        }

        public void RemoveEntity(IEntity IEntity)
        {
            Entities.Remove(IEntity);
        }

        public void UpdateKeyPressed(int key)
        {
            if (this.movementCodes.Contains(key))
            {
                KeyInputs.Insert(0, key);
            }
        }

        public void UpdateKeyReleased(int key)
        {
            KeyInputs.RemoveAll(k => k == key);
        }

        public void ResetKeys()
        {
            KeyInputs.Clear();
        }
    }
}
