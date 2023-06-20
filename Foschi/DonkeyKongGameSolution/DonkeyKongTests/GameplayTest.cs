#pragma warning disable CS8600
#pragma warning disable CS8602
using DonkeyKongGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DonkeyKongTests
{
    [TestClass]
    public class GameplayTest
    {
        [TestMethod]
        public void TestInitGameplay()
        {
            IGameplay _gp = new Gameplay();
            Assert.AreEqual(0, _gp.Entities.Count());
            _gp.InitializeGame();
            Assert.AreNotEqual(0, _gp.Entities.Count());
            Assert.IsTrue(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.MONKEY).Count() > 0);
            Assert.IsTrue(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.PLAYER).Count() > 0);
            Assert.IsTrue(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.PRINCESS).Count() > 0);
            Assert.IsFalse(_gp.IsWin());
        }

        [TestMethod]
        public void TestWin()
        {
            IGameplay _gp = new Gameplay();
            Assert.IsFalse(_gp.IsWin());
            _gp.SetWin();
            Assert.IsTrue(_gp.IsWin());
        }

        [TestMethod]
        public void TestLosePlayerRemoved()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity _player = _ef.GeneratePlayer(new Pair<float, float>(0, 0));
            _gp.AddEntity(_player);
            Assert.IsFalse(_gp.IsOver());
            _gp.RemovePlayer();
            Assert.IsTrue(_gp.IsOver());
            Assert.IsFalse(_gp.IsWin());
        }

        [TestMethod]
        public void TestLosePlayerNoLives()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity _player = _ef.GeneratePlayer(new Pair<float, float>(0, 0));
            _gp.AddEntity(_player);
            Assert.IsFalse(_gp.IsOver());
            _player.GetComponent<HealthComponent>().Lifes = 0;
            _gp.CheckIsOver();
            Assert.IsTrue(_gp.IsOver());
            Assert.IsFalse(_gp.IsWin());
        }
    }
}