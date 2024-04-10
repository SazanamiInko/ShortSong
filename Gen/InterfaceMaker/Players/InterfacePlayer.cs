using InterfaceMaker.DataModel;
using InterfaceMaker.Interface;
using InterfaceMaker.T4;

namespace InterfaceMaker.Players
{
    /// <summary>
    /// インタフェース作成者
    /// </summary>
    public class InterfacePlayer : IT4Play
    {
        #region フィールド

        /// <summary>
        /// T4エンジン
        /// </summary>
        private readonly InterfaceMakerT4 t4;

        #endregion

        #region コンストラク

        /// <summary>
        /// 使用禁止のコンストラクタ
        /// </summary>
        private InterfacePlayer(){ }

        /// <summary>
        /// 使わせるコンストラクタ
        /// </summary>
        /// <param name="material"></param>
        public InterfacePlayer(MaterialDataModel material,
                               string path)
        {
            this.t4 = new InterfaceMakerT4();
            t4.MaterialDataModel = material;
            this.path = PathUtil.GetInterfacePath(path);
        }
        #endregion

        #region メソッド
        /// <summary>
        /// 実行
        /// </summary>
        public override void Play()
        {
            //ソース生成
            var source = t4.TransformText();
            //CSファイルに保存する
            string outputInterFace = Path.Combine(path, t4.GetFileName());
            File.WriteAllText(outputInterFace, source);
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
