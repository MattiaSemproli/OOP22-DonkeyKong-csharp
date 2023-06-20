#pragma warning disable CS8600
#pragma warning disable CS8602
namespace DonkeyKongGame
{
    public class InputsComponent : AbstractComponent
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

        public override void Update()
        {
            int? input = this.Entity.Gameplay.KeyInputs.FirstOrDefault();
            if (input != null)
            {
                switch (input)
                {
                    case MOVE_LEFT:
                    case MOVE_LEFT_ARROW:
                        Move(new Pair<float, float>(-1, 0));
                        break;
                    case MOVE_RIGHT:
                    case MOVE_RIGHT_ARROW:
                        Move(new Pair<float, float>(1, 0));
                        break;
                    case MOVE_UP:
                    case MOVE_UP_ARROW:
                        MoveOnLadder(new Pair<float, float>(0, -1));
                        break;
                    case MOVE_DOWN:
                    case MOVE_DOWN_ARROW:
                        MoveOnLadder(new Pair<float, float>(0, 1));
                        break;
                    case JUMP:
                        Jump();
                        break;
                    default:
                        break;
                }
            }
        }

        private void Move(Pair<float, float> direction)
        {
            MovementComponent moveOptional = this.Entity.GetComponent<MovementComponent>();
            if (moveOptional != null)
            {
                moveOptional.MoveEntity(direction);
            }
        }

        private void MoveOnLadder(Pair<float, float> direction)
        {
            MovementComponent moveOptional = this.Entity.GetComponent<MovementComponent>();
            if (moveOptional != null)
            {
                moveOptional.MoveEntityOnLadder(direction);
            }
        }

        private void Jump()
        {
            MovementComponent moveOptional = this.Entity.GetComponent<MovementComponent>();
            if (moveOptional != null)
            {
                moveOptional.Jump();
            }
        }
    }
}
