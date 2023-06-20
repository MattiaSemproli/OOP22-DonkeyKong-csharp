#pragma warning disable CS8600
#pragma warning disable CS8602
using DonkeyKongGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DonkeyKongTests
{
    [TestClass]
    public class BarrelTest
    {
        [TestMethod]
        public void TestGenerateNormalBarrel()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity barrel = _ef.GenerateBarrel(new Pair<float, float>(0, 0));
            Assert.IsFalse(_gp.Entities.Contains(barrel));
            _gp.AddEntity(barrel);
            Assert.IsTrue(_gp.Entities.Contains(barrel));
            Assert.IsFalse(barrel.GetComponent<DoubleDamageComponent>().IsDoubleDamage);
        }

        [TestMethod]
        public void TestGenerateDoubleDamageBarrel()
        {
            IGameplay _gp = new Gameplay();
            IEntityFactory _ef = new EntityFactory(_gp);
            IEntity barrel = _ef.GenerateBarrel(new Pair<float, float>(0, 0));
            Assert.IsFalse(barrel.GetComponent<DoubleDamageComponent>().IsDoubleDamage);
            barrel.GetComponent<DoubleDamageComponent>().IsDoubleDamage = true;
            _gp.AddEntity(barrel);
            Assert.IsTrue(_gp.Entities.Contains(barrel));
            Assert.IsTrue(barrel.GetComponent<DoubleDamageComponent>().IsDoubleDamage);
        }

        [TestMethod]
        public void TestThrowBarrel()
        {
            IGameplay _gp = new Gameplay();
            Assert.IsTrue(_gp.Entities.Count == 0);
            _gp.ThrowBarrel(new Pair<float, float>(0, 0));
            Assert.IsTrue(_gp.Entities.Count > 0);
            IEntity _e = _gp.Entities.First();
            Assert.AreEqual(DonkeyKongGame.Type.BARREL, _e.Etype);
            _gp.ThrowBarrel(new Pair<float, float>(0, 0));
            _gp.ThrowBarrel(new Pair<float, float>(0, 0));
            Assert.IsTrue(_gp.Entities.Count > 1);
            _gp.RemoveAllBarrels();
            Assert.IsTrue(_gp.Entities.Count == 0);
        }
    }
}