using InterfaceMaker.DataModel;
using InterfaceMaker.Interface;
using InterfaceMaker.T4;

namespace InterfaceMaker.Players
{
    /// <summary>
    /// クライアント側自動作成
    /// </summary>
    public class ClientPlayer : IT4Play
    {
        #region フィールド
        /// <summary>
        /// T4
        /// </summary>
        private ClientDataModelMakerT4 t4;
        #endregion

        #region コンストラクタ

        /// <summary>
        /// 使用禁止のコンストラクタ
        /// </summary>
        private ClientPlayer() { }

        /// <summary>
        /// 使用すべきコンストラクタ
        /// </summary>
        /// <param name="material"></param>
        /// <param name="path"></param>
        public ClientPlayer(MaterialDataModel material,string path)
        {
            this.t4 = new ClientDataModelMakerT4();
            this.t4.MaterialDataModel = material;
            this.path =PathUtil.GetClientPath(path);
        }


        #endregion
        #region メソッド
        /// <summary>
        /// ソース作成実行
        /// </summary>
       
        public override void Play()
        {
            string source = t4.TransformText();
            string outputClient = Path.Combine(path, t4.GetFileName()) ;
            File.WriteAllText(outputClient, source);
        }

        /// <summary>
        /// 作成ファイル名を返す
        /// </summary>
        /// <returns></returns>
        public override string GetFileName()
        {
            return this.t4.GetFileName();
        }
        #endregion

    }
}
