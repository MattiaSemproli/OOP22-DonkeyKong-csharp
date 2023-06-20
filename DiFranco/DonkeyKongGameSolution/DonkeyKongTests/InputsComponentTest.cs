using Microsoft.VisualStudio.TestTools.UnitTesting;
using DonkeyKongGame;
#pragma warning disable CS8602
#pragma warning disable CS8601
#pragma warning disable CS8600
namespace DonkeyKongTests
{
    [TestClass]
    public class InputsComponentTest
    {
        private const int WRONG_CODE_TEST = 75;
        private const int MOVE_RIGHT = 68;
        private const int JUMP = 32;

        [TestMethod]
        public void TestInputWrongCode()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            gp.UpdateKeyPressed(MOVE_RIGHT);
            Assert.IsTrue(gp.KeyInputs.Contains(MOVE_RIGHT));
            gp.UpdateKeyPressed(WRONG_CODE_TEST);
            Assert.IsFalse(gp.KeyInputs.Contains(WRONG_CODE_TEST));
            gp.ResetKeys();
            Assert.IsTrue(gp.KeyInputs.Count() == 0);
        }

        [TestMethod]
        public void TestProcessInput()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            InputsComponent ic = player.GetComponent<InputsComponent>();
            ic.Update();
            Assert.IsNull(player.NextPosition);
            gp.UpdateKeyPressed(MOVE_RIGHT);
            Assert.IsTrue(gp.KeyInputs.Contains(MOVE_RIGHT));
            ic.Update();
            player.GetComponent<MovementComponent>().Update();
            Assert.IsNotNull(player.NextPosition);
        }

        [TestMethod]
        public void TestProcessJump()
        {
            IGameplay gp = new Gameplay();
            IEntityFactory ef = new EntityFactory(gp);
            IEntity player = ef.GeneratePlayer(new Pair<float, float>(0, 0));
            gp.AddEntity(player);
            gp.UpdateKeyPressed(JUMP);
            Assert.IsFalse(player.GetComponent<MovementComponent>().IsInAir());
            InputsComponent ic = player.GetComponent<InputsComponent>();
            ic.Update();
            Assert.IsTrue(player.GetComponent<MovementComponent>().IsInAir());
        }
    }
}
