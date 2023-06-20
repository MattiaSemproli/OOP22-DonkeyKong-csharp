#pragma warning disable CS8602
namespace DonkeyKongGame
{
    public class MovementComponent : AbstractComponent
    {
        private Pair<float, float> movePos = new Pair<float, float>(0f, 0f);

        public override void Update()
        {
            this.Entity.SaveNextPosition(movePos == new Pair<float, float>(0f, 0f) ? null : movePos);
        }

        public void MoveEntity(Pair<float, float> direction)
        {
            movePos = new Pair<float, float>(direction.GetX * this.Entity.Speed ?? 0, direction.GetY * this.Entity.Speed ?? 0);
        }
    }
}
