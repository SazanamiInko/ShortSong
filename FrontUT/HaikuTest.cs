using BLayer.Logics;
using FrontUT.TDLayer;

namespace FrontUT
{
    /// <summary>
    /// oๅAPIeXg
    /// </summary>
    [TestClass]
    public class HaikuTest
    {
        #region@o[

        /// <summary>
        /// eXgReLXg
        /// </summary>
        private TestUtaContextService context=new TestUtaContextService();
        
        /// <summary>
        /// oๅWbN
        /// </summary>
        private HaikuLogic logic= new HaikuLogic();
        #endregion

        /// <summary>
        /// eXgฬ๚ป
        /// </summary>
       
        private void TestInitialize()
        {
            context.TestClear();
            logic.Context = context;
        }

        #region IDญ๘
        /// <summary>
        /// oๅช0ฬฦซฬฎ
        /// </summary>

        [TestMethod]
        public void TestP()
        {
            TestInitialize();
            var expected = 1;
            var expectedCount = 0;
            var actualCount=context.Haikus.Count;

            //O๑ฬmF
            Assert.AreEqual(expectedCount, actualCount);
           
            //eXg
            var actual=logic.PublishedID();

            //ุ
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region oๅo^
        
        [TestMethod]
        public void TestA()
        {
        }
        #endregion

        #region oๅXV
        [TestMethod]
        public void TestU()
        {
        }
        #endregion

        #region oๅๆพ
        [TestMethod]
        public void TestG()
        {
        }
        #endregion

        #region oๅ๊ๆพ
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