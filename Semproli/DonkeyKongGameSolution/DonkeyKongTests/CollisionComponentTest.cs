#pragma warning disable CS8600
#pragma warning disable CS8602
using DonkeyKongGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DonkeyKongTests
{
    [TestClass]
    public class CollisionComponentTest
    {
        private const float TEST_PLAYER_X = 0f;
        private const float TEST_PLAYER_Y = 0f;
        private const int DIMENSION = 48;
        private const int NEXT_TO_FALL_IN_VOID = 500 - 1;
        private static readonly IGameplay _gp = new Gameplay();
        private readonly IEntityFactory _ef = new EntityFactory(_gp);

        [TestMethod]
        public void testPlayerCollisionWithWall()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y));
            Assert.AreEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(-1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.AreEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.AreNotEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
        }

        [TestMethod]
        public void testPlayerFallenInVoid()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, NEXT_TO_FALL_IN_VOID));
            _gp.AddEntity(player);
            Assert.IsTrue(_gp.Entities.Contains(player));
            Assert.AreEqual(new Pair<float, float>(TEST_PLAYER_X, NEXT_TO_FALL_IN_VOID), player.Position);
            Assert.AreNotEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(0, 1));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsFalse(_gp.Entities.Contains(player));
        }

        [TestMethod]
        public void testPlayerAndPrincess()
        {
            IEntity player = _ef.GeneratePlayer(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y));
            Assert.AreEqual(new Pair<float, float>(TEST_PLAYER_X, TEST_PLAYER_Y), player.Position);
            MovementComponent mc = player.GetComponent<MovementComponent>();
            Assert.IsFalse(_gp.IsWin());
            _gp.AddEntity(player);
            _gp.AddEntity(_ef.GeneratePrincess(new Pair<float, float>(TEST_PLAYER_X + DIMENSION, TEST_PLAYER_Y)));
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsTrue(_gp.IsWin());
        }
    }
}
