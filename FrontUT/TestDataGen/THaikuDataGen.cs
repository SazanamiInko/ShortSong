using DLayer.Models;

namespace FrontUT.TTestDataGen
{
    public class THaikuDataGen
	{
		#region メソッド	

		/// <summary>
		/// Pattern1データ作成
		/// </summary>
		public List<THaiku> GenPattern1()
		{
			List<THaiku> ret = new List<THaiku>();
			THaiku THaiku1 = new THaiku();

			THaiku1.Id = 1;
			THaiku1.Front = "まえがき";
			THaiku1.Haiku = "テストなのああテストなのテストなの";
			THaiku1.Kana = "てすとなのああてすとなのてすとなの";
			THaiku1.Seazon = 1;
			THaiku1.SeazonWord = "テスト";
			THaiku1.Memo = "備考です";
			THaiku1.Index = "インコ俳句会";
			THaiku1.English = "Test";
			THaiku1.Delete = 0;
			THaiku1.CreateDateTime = "システム日時";
			THaiku1.UpdateDateTime = "システム日時";
			THaiku1.UpdateCount = 1;
			ret.Add(THaiku1);

			THaiku THaiku2 = new THaiku();
			THaiku2.Id = 2;
			THaiku2.Front = "";
			THaiku2.Haiku = "削除済みのデータ";
			THaiku2.Kana = "さくじょずみのでーた";
			THaiku2.Seazon = 0;
			THaiku2.SeazonWord = "削除";
			THaiku2.Memo = "";
			THaiku2.Index = "インコ俳句会";
			THaiku2.English = "";
			THaiku2.Delete = 1;
			THaiku2.CreateDateTime = "システム日時";
			THaiku2.UpdateDateTime = "システム日時";
			THaiku2.UpdateCount = 1;
			ret.Add(THaiku2);

			THaiku THaiku3 = new THaiku();
			THaiku3.Id = 3;
			THaiku3.Front = "";
			THaiku3.Haiku = "検索用のデータ";
			THaiku3.Kana = "けんさくようのでーた";
			THaiku3.Seazon = 2;
			THaiku3.SeazonWord = "検索";
			THaiku3.Memo = "";
			THaiku3.Index = "さざなみ句座";
			THaiku3.English = "";
			THaiku3.Delete = 0;
			THaiku3.CreateDateTime = "システム日時";
			THaiku3.UpdateDateTime = "システム日時";
			THaiku3.UpdateCount = 1;
			ret.Add(THaiku3);

			THaiku THaiku4 = new THaiku();
			THaiku4.Id = 4;
			THaiku4.Front = "";
			THaiku4.Haiku = "さざなみや滋賀は昔の桜かな";
			THaiku4.Kana = "さざなみやしがはむかしのさくらかな";
			THaiku4.Seazon = 2;
			THaiku4.SeazonWord = "検索";
			THaiku4.Memo = "";
			THaiku4.Index = "滋賀句座";
			THaiku4.English = "";
			THaiku4.Delete = 0;
			THaiku4.CreateDateTime = "システム日時";
			THaiku4.UpdateDateTime = "システム日時";
			THaiku4.UpdateCount = 1;
			ret.Add(THaiku4);
			return ret;
		}
		#endregion
	}
}