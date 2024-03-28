using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Models;
using FrontUT.TDLayer;
using FrontUT.TTestDataGen;

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
        [TestCategory("俳句ID発効")]
        [TestMethod]
        public void UT0001_No01()
        {
            var expected = "システム例外が発生しました";
            try
            { 
            TestInitialize();
            

            logic.Context = null;

            //テスト
            var actual = logic.PublishedID();
            }
            catch(Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();

        }


        /// <summary>
        /// 俳句が0件のときの挙動
        /// </summary>
        [TestCategory("俳句ID発効")]
        [TestMethod]
        public void UT0001_No02()
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

        /// <summary>
        /// 俳句が0件のときの挙動
        /// </summary>
        [TestCategory("俳句ID発効")]
        [TestMethod]
        public void UT0001_No03()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern0();

            foreach(var data in genData)
            {
                context.InsertHaiku(data);
            }

            var expected = 2;

            //テスト
            var actual = logic.PublishedID();


            //検証
            Assert.AreEqual(expected, actual);

        }

        #endregion

        #region 俳句一覧取得
        [TestCategory("俳句一覧取得")]
        [TestMethod]
        public void UT0002_No01()
        {

            var expected = "システム例外が発生しました";
            try
            {
                TestInitialize();


                logic.Context = null;

                //テスト
                var actual = logic.GetHaikus("aa");
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }


        [TestCategory("俳句一覧取得")]
        [TestMethod]
        public void UT0002_No02()
        {

            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }
            //テスト
            var actual = logic.GetHaikus("データ");

            var actual3 = actual.Where(record => record.Id == 3)
                 .FirstOrDefault();

            var actual2 = actual.Where(record => record.Id == 2)
               .FirstOrDefault();

            Assert.IsNotNull(actual3);
            Assert.IsNull(actual2);
        }

        [TestCategory("俳句一覧取得")]
        [TestMethod]
        public void UT0002_No03()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();
            var expectedCount = 1;
            var expected = new HaikuSimple();
            
            expected.Id = 1;
            expected.Haiku = "テストなのああテストなのテストなの";
            expected.Index = "インコ俳句会";


            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }
            //テスト
            var actual = logic.GetHaikus("インコ");

            var actual1 = actual.Where(record => record.Id == 1)
                 .FirstOrDefault();
            Assert.AreEqual(expectedCount, actual.Count);

            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Id,actual1.Id);
            Assert.AreEqual(expected.Haiku, actual1.Haiku);
            Assert.AreEqual(expected.Index, actual1.Index);

        }

        [TestCategory("俳句一覧取得")]
        [TestMethod]
        public void UT0002_No04()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();
            var expectedCount = 2;



            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }
            //テスト
            var actual = logic.GetHaikus("さざなみ");

            var actual1 = actual.Where(record => record.Id == 1)
                 .FirstOrDefault();
            Assert.AreEqual(expectedCount, actual.Count);

            Assert.IsNotNull(actual);

        }
        #endregion

        #region 俳句取得
        [TestMethod]
        public void UT0003_No01()
        {

            var expected = "システム例外が発生しました";
            try
            {
                TestInitialize();


                logic.Context = null;

                //テスト
                var actual = logic.GetHaiku(1);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void UT0003_No02() 
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }

            var expected=new HaikuModel();
            expected.Id = 1;
            expected.Front = "まえがき";
            expected.Haiku = "テストなのああテストなのテストなの";
            expected.Kana = "てすとなのああてすとなのてすとなの";
            expected.English = "Test";
            expected.Seazon = 1;
            expected.SeazonWord = "テスト";
            expected.Index = "インコ俳句会";
            expected.Memo = "備考です";
            expected.CreateDateTime = "システム日時";
            expected.UpdateDateTime = "システム日時";
            expected.UpdateCount = 1;
            expected.Delete = 0;

           var actual =logic.GetHaiku(1);

            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Id,actual.Id);
            Assert.AreEqual(expected.Front, actual.Front);
            Assert.AreEqual(expected.Haiku, actual.Haiku);
            Assert.AreEqual(expected.Kana, actual.Kana);
            Assert.AreEqual(expected.English, actual.English);
            Assert.AreEqual(expected.Seazon, actual.Seazon);
            Assert.AreEqual(expected.SeazonWord, actual.SeazonWord);
            Assert.AreEqual(expected.Index, actual.Index);
            Assert.AreEqual(expected.Memo, actual.Memo);
            Assert.AreEqual(expected.CreateDateTime, actual.CreateDateTime);
            Assert.AreEqual(expected.UpdateDateTime, actual.UpdateDateTime);
            Assert.AreEqual(expected.UpdateCount, actual.UpdateCount);
            Assert.AreEqual(expected.Delete, actual.Delete);
           
        }

        [TestMethod]
        public void UT0003_No03()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }

            var actual = logic.GetHaiku(99);

            Assert.IsNull(actual);
        }
        #endregion

        #region 俳句登録

        [TestMethod]
        public void UT0004_No01()
        {
            var expected = "システム例外が発生しました";
            try
            {
                TestInitialize();


                logic.Context = null;

                //テスト
                var actual = logic.AddHaiku(new HaikuModel());
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void UT0004_No02()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern0();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }

            var expected = new THaiku();

            expected.Id = 6;
            expected.Front = "宇宙まおの昔の楽曲";
            expected.Haiku = " 春風がバイバイの背を押している";
            expected.Kana = "はるかぜがばいばいのせをおしている";
            expected.English = "Spring";
            expected.Seazon = 2;
            expected.SeazonWord = "春風";
            expected.Index = "MHK";
            expected.Memo = "いまいち";
            expected.CreateDateTime = "システム日時";
            expected.UpdateDateTime = string.Empty;
            expected.UpdateCount = 0;
            expected.Delete = 0;

            var parameter = new HaikuModel();

            parameter.Id = 6;
            parameter.Front = "宇宙まおの昔の楽曲";
            parameter.Haiku = " 春風がバイバイの背を押している";
            parameter.Kana = "はるかぜがばいばいのせをおしている";
            parameter.English = "Spring";
            parameter.Seazon = 2;
            parameter.SeazonWord = "春風";
            parameter.Index = "MHK";
            parameter.Memo = "いまいち";
            parameter.CreateDateTime = "システム日時";
            parameter.UpdateDateTime = "システム日時";
            parameter.UpdateCount = 1;
            parameter.Delete = 0;

            var test_before = DateTime.Now.ToString();
            Thread.Sleep(1000);
            var actual = logic.AddHaiku(parameter);
            Thread.Sleep(1000);
            var test_after = DateTime.Now.ToString();
            var actualData = context.GetHaikus()
                                     .Where(record => record.Id == 6)
                                    .FirstOrDefault();
            Assert.IsTrue(actual,"API戻り値");
            Assert.IsNotNull(actualData);

            Assert.AreEqual(expected.Id, actualData.Id, "管理番号");
            Assert.AreEqual(expected.Front, actualData.Front, "前書き");
            Assert.AreEqual(expected.Haiku, actualData.Haiku, "俳句");
            Assert.AreEqual(expected.Kana, actualData.Kana, "かな");
            Assert.AreEqual(expected.English, actualData.English, "英語");
            Assert.AreEqual(expected.Seazon, actualData.Seazon, "季節");
            Assert.AreEqual(expected.SeazonWord, actualData.SeazonWord, "季語");
            Assert.AreEqual(expected.Index, actualData.Index, "見出し");
            Assert.AreEqual(expected.Index, actualData.Index, "季語");
            Assert.AreEqual(expected.UpdateDateTime, actualData.UpdateDateTime, "更新日時");
            Assert.AreEqual(expected.UpdateCount, actualData.UpdateCount, "更新回数");
            Assert.AreEqual(expected.Delete, actualData.Delete, "削除フラグ");

            Assert.IsNotNull(actualData.CreateDateTime);

            if (string.Compare( actualData.CreateDateTime,test_before)<=0)
            {
                Assert.Fail();
            }


            if (string.Compare(actualData.CreateDateTime, test_after) >= 0)
            {
                Assert.Fail();
            }

        }
        #endregion

        #region 俳句更新
        [TestMethod]
        public void UT0005_No01()
        {

            var expected = "システム例外が発生しました";
            try
            {
                TestInitialize();

                logic.Context = null;

                //テスト
                var actual = logic.UpdateHaiku(new HaikuUpdateModel());
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }
        [TestMethod]
        public void UT0005_No02() 
        {

            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }

            var parameter = new HaikuUpdateModel();
            parameter.Id = 1;
            parameter.Front = "宇宙まおの昔の楽曲";
            parameter.Haiku = " 春風がバイバイの背を押している";
            parameter.Kana = "はるかぜがばいばいのせをおしている";
            parameter.English = "Spring";
            parameter.Seazon = 2;
            parameter.SeazonWord = "春風";
            parameter.Index = "MHK";
            parameter.Memo = "いまいち";
            parameter.UpdateDateTime = "システム日時";
            parameter.UpdateCount = 1;
          

            var expected = new THaiku();
            expected.Id = 1;
            expected.Front = "宇宙まおの昔の楽曲";
            expected.Haiku = " 春風がバイバイの背を押している";
            expected.Kana = "はるかぜがばいばいのせをおしている";
            expected.English = "Spring";
            expected.Seazon = 2;
            expected.SeazonWord = "春風";
            expected.Index = "MHK";
            expected.Memo = "いまいち";
            expected.CreateDateTime = "システム日時";
            expected.UpdateDateTime = string.Empty;
            expected.UpdateCount = 1;
            expected.Delete = 0;

            var test_before = DateTime.Now.ToString();
            Thread.Sleep(1000);
            var actual = logic.UpdateHaiku(parameter);
            Thread.Sleep(1000);
            var test_after = DateTime.Now.ToString();
          
            var actualData = context.GetHaikus()
                                     .Where(record => record.Id == 1)
                                    .FirstOrDefault();
            Assert.IsTrue(actual, "API戻り値");
            Assert.IsNotNull(actualData);

            Assert.AreEqual(expected.Id, actualData.Id, "管理番号");
            Assert.AreEqual(expected.Front, actualData.Front, "前書き");
            Assert.AreEqual(expected.Haiku, actualData.Haiku, "俳句");
            Assert.AreEqual(expected.Kana, actualData.Kana, "かな");
            Assert.AreEqual(expected.English, actualData.English, "英語");
            Assert.AreEqual(expected.Seazon, actualData.Seazon, "季節");
            Assert.AreEqual(expected.SeazonWord, actualData.SeazonWord, "季語");
            Assert.AreEqual(expected.Index, actualData.Index, "見出し");
            Assert.AreEqual(expected.Index, actualData.Index, "季語");
            Assert.AreEqual(expected.Index, actualData.Index, "季語");
            Assert.AreEqual(expected.CreateDateTime, actualData.CreateDateTime, "更新回数");
            Assert.AreEqual(expected.Delete, actualData.Delete, "削除フラグ");

            Assert.IsNotNull(actualData.UpdateDateTime);

            if (string.Compare(actualData.UpdateDateTime, test_before) <= 0)
            {
                Assert.Fail();
            }


            if (string.Compare(actualData.UpdateDateTime, test_after) >= 0)
            {
                Assert.Fail();
            }
        }
        #endregion

        #region 俳句削除

        [TestMethod]
        public void UT0006_No01()
        {

            var expected = "システム例外が発生しました";
            try
            {
                TestInitialize();


                logic.Context = null;

                //テスト
                var actual = logic.DeleteHaiku(1);
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void UT0006_No02()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }

            var expected = "システム例外が発生しました";
            try
            {
                
            var actual = logic.DeleteHaiku(99);

            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void UT0006_No03()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();

            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }

            var expected = 1;
            var actual = logic.DeleteHaiku(1);

            var actualData = context.GetHaikus()
                                    .Where(record => record.Id == 1)
                                   .FirstOrDefault();
            Assert.IsTrue(actual, "API戻り値");
            Assert.IsNotNull(actualData);
            Assert.AreEqual(expected, actualData.Delete, "削除フラグ");
        }
        #endregion


    }
}