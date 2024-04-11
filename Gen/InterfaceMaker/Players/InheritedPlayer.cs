using InterfaceMaker.DataModel;
using InterfaceMaker.Interface;
using InterfaceMaker.T4;

namespace InterfaceMaker.Players
{
    /// <summary>
    /// 派生クラス自動生成
    /// </summary>
    public class InheritedPlayer : IT4Play
    {
        #region フィールド

        /// <summary>
        /// T4エンジン
        /// </summary>
        private readonly InheritedMaker t4;

        #endregion

        #region  コンストラクタ

        /// <summary>
        /// 使用禁止のコンストラクタ
        /// </summary>
        private InheritedPlayer() { }

        /// <summary>
        /// 使用すべきコンストラクタ
        /// </summary>
        /// <param name="matrerial"></param>
        /// <param name="inheritedInfo"></param>
        /// <param name="path"></param>
        public InheritedPlayer(MaterialDataModel matrerial,
                               InheritedT4DataModel inheritedInfo,
                               string path)
        {
            this.t4 = new InheritedMaker();
            t4.MaterialDataModel = matrerial;
            t4.InheritedT4DataModel = inheritedInfo;
            this.path = PathUtil.GetInheritedPath(path,inheritedInfo.Name);
        }

        #endregion

        #region メソッド

        /// <summary>
        /// ファイル名を返す
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string GetFileName()
        {
           return this.t4.GetFileName();
        }

        /// <summary>
        /// 自動生成する
        /// </summary>
        public override void Play()
        {
            //ソース生成
            var source = t4.TransformText();
            //CSファイルに保存する
            string outputInheritedPath = Path.Combine(path, t4.GetFileName());
            File.WriteAllText(outputInheritedPath, source);
        }

        #endregion


    }
}
