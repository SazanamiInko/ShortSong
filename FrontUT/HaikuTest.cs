using BLayer.Logics;
using FrontUT.TDLayer;

namespace FrontUT
{
    /// <summary>
    /// �o��API�e�X�g
    /// </summary>
    [TestClass]
    public class HaikuTest
    {
        #region�@�����o�[

        /// <summary>
        /// �e�X�g�R���e�L�X�g
        /// </summary>
        private TestUtaContextService context=new TestUtaContextService();
        
        /// <summary>
        /// �o�働�W�b�N
        /// </summary>
        private HaikuLogic logic= new HaikuLogic();
        #endregion

        /// <summary>
        /// �e�X�g�̏�����
        /// </summary>
       
        private void TestInitialize()
        {
            context.TestClear();
            logic.Context = context;
        }

        #region ID����
        /// <summary>
        /// �o�傪0���̂Ƃ��̋���
        /// </summary>

        [TestMethod]
        public void TestP()
        {
            TestInitialize();
            var expected = 1;
            var expectedCount = 0;
            var actualCount=context.Haikus.Count;

            //�O��̊m�F
            Assert.AreEqual(expectedCount, actualCount);
           
            //�e�X�g
            var actual=logic.PublishedID();

            //����
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region �o��o�^
        
        [TestMethod]
        public void TestA()
        {
        }
        #endregion

        #region �o��X�V
        [TestMethod]
        public void TestU()
        {
        }
        #endregion

        #region �o��擾
        [TestMethod]
        public void TestG()
        {
        }
        #endregion

        #region �o��ꗗ�擾
        [TestMethod]
        public void TestAL()
        {
        }
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}