using DonkeyKongGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DonkeyKongTests
{
    [TestClass]
    public class CollisionComponentTest
    {
        private const float XPLAYERR = 0.6f;
        private const float XPLAYERL = 0.3f;
        private const int ROWS = 5;
        private const int COLUMNS = 5;
        private static readonly IGameplay _gp = new Gameplay();
        private readonly IEntityFactory _ef = new EntityFactory(_gp);
        [TestMethod]
        public void TestCollisionsPlayerWall()
        {
            _game.AddEntity(_entityFactory.MakeIndestructibleWall(new Pair<float, float>(0f, 1f)));
            _game.AddEntity(_entityFactory.MakeIndestructibleWall(new Pair<float, float>(1f, 0f)));
            IEntity player = _entityFactory.MakePlayable(new Pair<float, float>(0f, 0f));
            _game.AddEntity(player);
            Assert.AreEqual(player.EntityPosition, new Pair<float, float>(0f, 0f));
            MoveOneTiles(player);
            Assert.AreEqual(new Pair<float, float>(0f, 0f), player.EntityPosition);
        }
    }
}
