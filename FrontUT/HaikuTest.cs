using BLayer.Logics;
using FrontUT.TDLayer;

namespace FrontUT
{
    /// <summary>
    /// 俳句APIテスト
    /// </summary>
    [TestClass]
    public class HaikuTest
    {
        #region　メンバー

        /// <summary>
        /// テストコンテキスト
        /// </summary>
        private TestUtaContextService context=new TestUtaContextService();
        
        /// <summary>
        /// 俳句ロジック
        /// </summary>
        private HaikuLogic logic= new HaikuLogic();
        #endregion

        /// <summary>
        /// テストの初期化
        /// </summary>
       
        private void TestInitialize()
        {
            context.TestClear();
            logic.Context = context;
        }

        #region ID発効
        /// <summary>
        /// 俳句が0件のときの挙動
        /// </summary>

        [TestMethod]
        public void TestP()
        {
            TestInitialize();
            var expected = 1;
            var expectedCount = 0;
            var actualCount=context.Haikus.Count;

            //前提の確認
            Assert.AreEqual(expectedCount, actualCount);
           
            //テスト
            var actual=logic.PublishedID();

            //検証
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region 俳句登録
        
        [TestMethod]
        public void TestA()
        {
        }
        #endregion

        #region 俳句更新
        [TestMethod]
        public void TestU()
        {
        }
        #endregion

        #region 俳句取得
        [TestMethod]
        public void TestG()
        {
        }
        #endregion

        #region 俳句一覧取得
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