#pragma warning disable CS8600
#pragma warning disable CS8602
using DonkeyKongGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DonkeyKongTests
{
    [TestClass]
    public class MonkeyTest
    {
        [TestMethod]
        public void TestGenerateMonkey()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity _monkey = _ef.GenerateMonkey(new Pair<float, float>(0, 0));
            Assert.IsFalse(_gp.Entities.Contains(_monkey));
            _gp.AddEntity(_monkey);
            Assert.IsTrue(_gp.Entities.Contains(_monkey));
            Assert.IsNotNull(_monkey.GetComponent<ThrowComponent>());
        }

        [TestMethod]
        public void TestMonkeyThrowIfNotFrozen()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity _monkey = _ef.GenerateMonkey(new Pair<float, float>(0, 0));
            Assert.IsFalse(_monkey.GetComponent<ThrowComponent>().IsFrozen);
            _gp.AddEntity(_monkey);
            Assert.IsTrue(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.BARREL).Count() == 0);
            _monkey.GetComponent<ThrowComponent>().Update();
            Assert.IsFalse(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.BARREL).Count() == 0);
        }

        [TestMethod]
        public void TestMonkeyThrowIfFrozen()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity _monkey = _ef.GenerateMonkey(new Pair<float, float>(0, 0));
            Assert.IsFalse(_monkey.GetComponent<ThrowComponent>().IsFrozen);
            _monkey.GetComponent<ThrowComponent>().IsFrozen = true;
            _gp.AddEntity(_monkey);
            Assert.IsTrue(_monkey.GetComponent<ThrowComponent>().IsFrozen);
            Assert.IsTrue(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.BARREL).Count() == 0);
            _monkey.GetComponent<ThrowComponent>().Update();
            Assert.IsTrue(_gp.Entities.FindAll(_e => _e.Etype == DonkeyKongGame.Type.BARREL).Count() == 0);
        }
    }
}