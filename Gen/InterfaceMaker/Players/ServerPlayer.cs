using InterfaceMaker.DataModel;
using InterfaceMaker.Interface;
using InterfaceMaker.T4;

namespace InterfaceMaker.Players
{
    /// <summary>
    /// サーバー側自動生成
    /// </summary>
    public class ServerPlayer : IT4Play
    {
        #region フィールド

        /// <summary>
        /// T4
        /// </summary>
        private ServerDataModelMakerT4 t4;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// 使用禁止のコンストラクタ
        /// </summary>
        private ServerPlayer() { }

        /// <summary>
        /// 使用すべきコンストラクタ
        /// </summary>
        /// <param name="material"></param>
        /// <param name="path"></param>
        public ServerPlayer(MaterialDataModel material,string path)
        {
            this.t4 = new ServerDataModelMakerT4();
            t4.MaterialDataModel=material;
            this.path = PathUtil.GetServerPath(path);
        }

        #endregion

        #region メソッド
        /// <summary>
        /// サーバー側自動作成
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public override void Play()
        {
            string source = t4.TransformText();
            string outputServer = Path.Combine(path, t4.GetFileName());
            File.WriteAllText(outputServer, source);
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
