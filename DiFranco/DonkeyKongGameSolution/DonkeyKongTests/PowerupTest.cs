using Microsoft.VisualStudio.TestTools.UnitTesting;
using DonkeyKongGame;
#pragma warning disable CS8602
#pragma warning disable CS8601
#pragma warning disable CS8600
namespace DonkeyKongTests
{
    [TestClass]
    public class PowerupTest
    {
        private const int TEST_LIFE_1 = -3;
        private const int TEST_LIFE_2 = 5;
        private const int TEST_LIFE_3 = 7;
        private const int PLAYER_DIMENSION = 48;
        private const int NUM_LIVES = 3;

        [TestMethod]
        public void TestGeneratePowerup()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            Assert.IsTrue(gp.Entities.FindAll(e => e.Etype == DonkeyKongGame.Type.STAR
                                                || e.Etype == DonkeyKongGame.Type.HEART
                                                || e.Etype == DonkeyKongGame.Type.SHIELD
                                                || e.Etype == DonkeyKongGame.Type.SNOWFLAKE).Count() == 0);
            gp.AddEntity(ef.GenerateHeartPowerUp(new Pair<float, float>(0f, 0f)));
            gp.AddEntity(ef.GenerateShieldPowerUp(new Pair<float, float>(0f, 0f)));
            gp.AddEntity(ef.GenerateSnowflakePowerUp(new Pair<float, float>(0f, 0f)));
            gp.AddEntity(ef.GenerateStarPowerUp(new Pair<float, float>(0f, 0f)));
            Assert.IsFalse(gp.Entities.FindAll(e => e.Etype == DonkeyKongGame.Type.STAR
                                                || e.Etype == DonkeyKongGame.Type.HEART
                                                || e.Etype == DonkeyKongGame.Type.SHIELD
                                                || e.Etype == DonkeyKongGame.Type.SNOWFLAKE).Count() == 0);
        }

        [TestMethod]
        public void TestStarPowerup()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            StarComponent sc = player.GetComponent<StarComponent>();
            Assert.IsFalse(sc.IsInvincible);
            gp.AddEntity(ef.GenerateStarPowerUp(new Pair<float, float>(PLAYER_DIMENSION, 0f)));
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsTrue(sc.IsInvincible);
            for (int i = 0; i <= 240; i++)
            {
                sc.Update();
            }
            Assert.IsFalse(sc.IsInvincible);
        }

        [TestMethod]
        public void TestShieldPowerup()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            ShieldComponent sc = player.GetComponent<ShieldComponent>();
            Assert.IsFalse(sc.shielded);
            gp.AddEntity(ef.GenerateShieldPowerUp(new Pair<float, float>(PLAYER_DIMENSION, 0f)));
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsTrue(sc.shielded);
            gp.AddEntity(ef.GenerateBarrel(new Pair<float, float>(PLAYER_DIMENSION, 0f)));
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsFalse(sc.shielded);
        }

        [TestMethod]
        public void TestBarrelHitWithShield()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            HealthComponent hc = player.GetComponent<HealthComponent>();
            ShieldComponent sc = player.GetComponent<ShieldComponent>();
            sc.shielded = true;
            gp.AddEntity(player);
            gp.AddEntity(ef.GenerateBarrel(new Pair<float, float>(PLAYER_DIMENSION, 0f)));
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsFalse(sc.shielded);
            Assert.AreEqual(NUM_LIVES, hc.Lives);
            sc.shielded = true;
            IEntity ddBarrel = ef.GenerateBarrel(new Pair<float, float>(PLAYER_DIMENSION, 0f));
            ddBarrel.GetComponent<DoubleDamageComponent>().IsDoubleDamage = true;
            gp.AddEntity(ddBarrel);
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsFalse(sc.shielded);
            Assert.AreEqual(NUM_LIVES - 1, hc.Lives);
        }

        [TestMethod]
        public void TestFreezePowerup()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            FreezeComponent fc = player.GetComponent<FreezeComponent>();
            Assert.IsFalse(fc.freezer);
            gp.AddEntity(ef.GenerateSnowflakePowerUp(new Pair<float, float>(PLAYER_DIMENSION, 0f)));
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.IsTrue(fc.freezer);
            for (int i = 0; i <= 480; i++)
            {
                fc.Update();
            }
            Assert.IsFalse(fc.freezer);
        }

        [TestMethod]
        public void TestHeartPowerup()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            HealthComponent hc = player.GetComponent<HealthComponent>();
            Assert.AreEqual(NUM_LIVES, hc.Lives);
            gp.AddEntity(ef.GenerateHeartPowerUp(new Pair<float, float>(PLAYER_DIMENSION, 0f)));
            MovementComponent mc = player.GetComponent<MovementComponent>();
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.AreEqual(NUM_LIVES, hc.Lives);
            hc.SetLives(-1);
            Assert.AreEqual(NUM_LIVES - 1, hc.Lives);
            mc.MoveEntity(new Pair<float, float>(1, 0));
            mc.Update();
            player.GetComponent<CollisionComponent>().Update();
            Assert.AreEqual(NUM_LIVES, hc.Lives);
            Assert.IsFalse(gp.Entities.Any(e => e.Etype == DonkeyKongGame.Type.HEART));
        }

        [TestMethod]
        public void TestHealthComponent()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            HealthComponent hc = player.GetComponent<HealthComponent>();
            Assert.AreEqual(NUM_LIVES, hc.Lives);
            hc.SetLives(-1);
            Assert.AreEqual(NUM_LIVES - 1, hc.Lives);
            hc.SetLives(TEST_LIFE_1);
            Assert.AreEqual(0, hc.Lives);
            Assert.AreNotEqual(NUM_LIVES - 4, hc.Lives);
            hc.SetLives(2);
            Assert.AreEqual(2, hc.Lives);
            hc.SetLives(TEST_LIFE_2);
            Assert.AreEqual(NUM_LIVES, hc.Lives);
            Assert.AreNotEqual(TEST_LIFE_3, hc.Lives);
        }
    }
}
