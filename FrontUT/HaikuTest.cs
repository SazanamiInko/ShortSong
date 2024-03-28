using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Models;
using FrontUT.TDLayer;
using FrontUT.TTestDataGen;

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
        [TestCategory("�o��ID����")]
        [TestMethod]
        public void UT0001_No01()
        {
            var expected = "�V�X�e����O���������܂���";
            try
            { 
            TestInitialize();
            

            logic.Context = null;

            //�e�X�g
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
        /// �o�傪0���̂Ƃ��̋���
        /// </summary>
        [TestCategory("�o��ID����")]
        [TestMethod]
        public void UT0001_No02()
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

        /// <summary>
        /// �o�傪0���̂Ƃ��̋���
        /// </summary>
        [TestCategory("�o��ID����")]
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

            //�e�X�g
            var actual = logic.PublishedID();


            //����
            Assert.AreEqual(expected, actual);

        }

        #endregion

        #region �o��ꗗ�擾
        [TestCategory("�o��ꗗ�擾")]
        [TestMethod]
        public void UT0002_No01()
        {

            var expected = "�V�X�e����O���������܂���";
            try
            {
                TestInitialize();


                logic.Context = null;

                //�e�X�g
                var actual = logic.GetHaikus("aa");
            }
            catch (Exception e)
            {
                Assert.AreEqual(expected, e.Message);
                return;
            }

            Assert.Fail();
        }


        [TestCategory("�o��ꗗ�擾")]
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
            //�e�X�g
            var actual = logic.GetHaikus("�f�[�^");

            var actual3 = actual.Where(record => record.Id == 3)
                 .FirstOrDefault();

            var actual2 = actual.Where(record => record.Id == 2)
               .FirstOrDefault();

            Assert.IsNotNull(actual3);
            Assert.IsNull(actual2);
        }

        [TestCategory("�o��ꗗ�擾")]
        [TestMethod]
        public void UT0002_No03()
        {
            TestInitialize();
            THaikuDataGen gen = new THaikuDataGen();

            var genData = gen.GenPattern1();
            var expectedCount = 1;
            var expected = new HaikuSimple();
            
            expected.Id = 1;
            expected.Haiku = "�e�X�g�Ȃ̂����e�X�g�Ȃ̃e�X�g�Ȃ�";
            expected.Index = "�C���R�o���";


            foreach (var data in genData)
            {
                context.InsertHaiku(data);
            }
            //�e�X�g
            var actual = logic.GetHaikus("�C���R");

            var actual1 = actual.Where(record => record.Id == 1)
                 .FirstOrDefault();
            Assert.AreEqual(expectedCount, actual.Count);

            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Id,actual1.Id);
            Assert.AreEqual(expected.Haiku, actual1.Haiku);
            Assert.AreEqual(expected.Index, actual1.Index);

        }

        [TestCategory("�o��ꗗ�擾")]
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
            //�e�X�g
            var actual = logic.GetHaikus("�����Ȃ�");

            var actual1 = actual.Where(record => record.Id == 1)
                 .FirstOrDefault();
            Assert.AreEqual(expectedCount, actual.Count);

            Assert.IsNotNull(actual);

        }
        #endregion

        #region �o��擾
        [TestMethod]
        public void UT0003_No01()
        {

            var expected = "�V�X�e����O���������܂���";
            try
            {
                TestInitialize();


                logic.Context = null;

                //�e�X�g
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
            expected.Front = "�܂�����";
            expected.Haiku = "�e�X�g�Ȃ̂����e�X�g�Ȃ̃e�X�g�Ȃ�";
            expected.Kana = "�Ă��ƂȂ̂����Ă��ƂȂ̂Ă��ƂȂ�";
            expected.English = "Test";
            expected.Seazon = 1;
            expected.SeazonWord = "�e�X�g";
            expected.Index = "�C���R�o���";
            expected.Memo = "���l�ł�";
            expected.CreateDateTime = "�V�X�e������";
            expected.UpdateDateTime = "�V�X�e������";
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

        #region �o��o�^

        [TestMethod]
        public void UT0004_No01()
        {
            var expected = "�V�X�e����O���������܂���";
            try
            {
                TestInitialize();


                logic.Context = null;

                //�e�X�g
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
            expected.Front = "�F���܂��̐̂̊y��";
            expected.Haiku = " �t�����o�C�o�C�̔w�������Ă���";
            expected.Kana = "�͂邩�����΂��΂��̂��������Ă���";
            expected.English = "Spring";
            expected.Seazon = 2;
            expected.SeazonWord = "�t��";
            expected.Index = "MHK";
            expected.Memo = "���܂���";
            expected.CreateDateTime = "�V�X�e������";
            expected.UpdateDateTime = string.Empty;
            expected.UpdateCount = 0;
            expected.Delete = 0;

            var parameter = new HaikuModel();

            parameter.Id = 6;
            parameter.Front = "�F���܂��̐̂̊y��";
            parameter.Haiku = " �t�����o�C�o�C�̔w�������Ă���";
            parameter.Kana = "�͂邩�����΂��΂��̂��������Ă���";
            parameter.English = "Spring";
            parameter.Seazon = 2;
            parameter.SeazonWord = "�t��";
            parameter.Index = "MHK";
            parameter.Memo = "���܂���";
            parameter.CreateDateTime = "�V�X�e������";
            parameter.UpdateDateTime = "�V�X�e������";
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
            Assert.IsTrue(actual,"API�߂�l");
            Assert.IsNotNull(actualData);

            Assert.AreEqual(expected.Id, actualData.Id, "�Ǘ��ԍ�");
            Assert.AreEqual(expected.Front, actualData.Front, "�O����");
            Assert.AreEqual(expected.Haiku, actualData.Haiku, "�o��");
            Assert.AreEqual(expected.Kana, actualData.Kana, "����");
            Assert.AreEqual(expected.English, actualData.English, "�p��");
            Assert.AreEqual(expected.Seazon, actualData.Seazon, "�G��");
            Assert.AreEqual(expected.SeazonWord, actualData.SeazonWord, "�G��");
            Assert.AreEqual(expected.Index, actualData.Index, "���o��");
            Assert.AreEqual(expected.Index, actualData.Index, "�G��");
            Assert.AreEqual(expected.UpdateDateTime, actualData.UpdateDateTime, "�X�V����");
            Assert.AreEqual(expected.UpdateCount, actualData.UpdateCount, "�X�V��");
            Assert.AreEqual(expected.Delete, actualData.Delete, "�폜�t���O");

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

        #region �o��X�V
        [TestMethod]
        public void UT0005_No01()
        {

            var expected = "�V�X�e����O���������܂���";
            try
            {
                TestInitialize();

                logic.Context = null;

                //�e�X�g
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
            parameter.Front = "�F���܂��̐̂̊y��";
            parameter.Haiku = " �t�����o�C�o�C�̔w�������Ă���";
            parameter.Kana = "�͂邩�����΂��΂��̂��������Ă���";
            parameter.English = "Spring";
            parameter.Seazon = 2;
            parameter.SeazonWord = "�t��";
            parameter.Index = "MHK";
            parameter.Memo = "���܂���";
            parameter.UpdateDateTime = "�V�X�e������";
            parameter.UpdateCount = 1;
          

            var expected = new THaiku();
            expected.Id = 1;
            expected.Front = "�F���܂��̐̂̊y��";
            expected.Haiku = " �t�����o�C�o�C�̔w�������Ă���";
            expected.Kana = "�͂邩�����΂��΂��̂��������Ă���";
            expected.English = "Spring";
            expected.Seazon = 2;
            expected.SeazonWord = "�t��";
            expected.Index = "MHK";
            expected.Memo = "���܂���";
            expected.CreateDateTime = "�V�X�e������";
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
            Assert.IsTrue(actual, "API�߂�l");
            Assert.IsNotNull(actualData);

            Assert.AreEqual(expected.Id, actualData.Id, "�Ǘ��ԍ�");
            Assert.AreEqual(expected.Front, actualData.Front, "�O����");
            Assert.AreEqual(expected.Haiku, actualData.Haiku, "�o��");
            Assert.AreEqual(expected.Kana, actualData.Kana, "����");
            Assert.AreEqual(expected.English, actualData.English, "�p��");
            Assert.AreEqual(expected.Seazon, actualData.Seazon, "�G��");
            Assert.AreEqual(expected.SeazonWord, actualData.SeazonWord, "�G��");
            Assert.AreEqual(expected.Index, actualData.Index, "���o��");
            Assert.AreEqual(expected.Index, actualData.Index, "�G��");
            Assert.AreEqual(expected.Index, actualData.Index, "�G��");
            Assert.AreEqual(expected.CreateDateTime, actualData.CreateDateTime, "�X�V��");
            Assert.AreEqual(expected.Delete, actualData.Delete, "�폜�t���O");

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

        #region �o��폜

        [TestMethod]
        public void UT0006_No01()
        {

            var expected = "�V�X�e����O���������܂���";
            try
            {
                TestInitialize();


                logic.Context = null;

                //�e�X�g
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

            var expected = "�V�X�e����O���������܂���";
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
            Assert.IsTrue(actual, "API�߂�l");
            Assert.IsNotNull(actualData);
            Assert.AreEqual(expected, actualData.Delete, "�폜�t���O");
        }
        #endregion


    }
}