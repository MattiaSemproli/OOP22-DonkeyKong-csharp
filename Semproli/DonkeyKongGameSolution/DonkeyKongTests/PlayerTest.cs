#pragma warning disable CS8600
#pragma warning disable CS8602
using DonkeyKongGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DonkeyKongTests
{
    [TestClass]
    public class PlayerTest
    {
        private const float TEST_PLAYER_X = 100f;
        private const float TEST_PLAYER_Y = 100f;
        private const int DIMENSION = 48;

        private static readonly IGameplay _gp = new Gameplay();
        private readonly IEntityFactory _ef = new EntityFactory(_gp);

        [TestMethod]
        public void testInitPlayerAndPosition()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y));
            Assert.IsNotNull(player);
            Assert.AreEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
            Assert.AreEqual(TEST_PLAYER_Y, player.Position.GetY);
            Assert.AreNotEqual(new Pair<float, float>(0, 0), player.Position);
            Assert.AreNotEqual(0, player.Position.GetX);
        }

        [TestMethod]
        public void testPlayerGetSomeComponentsAndArePresent()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y));
            Assert.IsNotNull(player.GetComponent<CollisionComponent>());
            Assert.IsNotNull(player.GetComponent<MovementComponent>());
        }

        [TestMethod]
        public void testPlayerGetComponentNotPresent()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y));
            Assert.IsNull(player.GetComponent<ThrowComponent>());
        }

        [TestMethod]
        public void testMovePlayer()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y));
            MovementComponent mc = player.GetComponent<MovementComponent>();
            Assert.AreEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.AreNotEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
        }
    }
}
