using InterfaceMaker.DataModel;
using InterfaceMaker.Interface;
using InterfaceMaker.Players;

namespace InterfaceMaker
{
    /// <summary>
    /// T4実行者
    /// </summary>
    public class T4PlayerManager
    {
        #region プロパティ
        
        /// <summary>
        /// 作成者リスト
        /// </summary>
        public List<IT4Play> Players { get; }

        #endregion

        #region コンストラクタ

        /// <summary>
        /// 使用禁止のコンストラクタ
        /// </summary>
        private T4PlayerManager() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="matrerial"></param>
        /// <param name="outpath"></param>
        public T4PlayerManager(MaterialDataModel matrerial,
                               List<InheritedT4DataModel> inheritedT4DataModels,
                                string outpath
                               )
        {
            this.Players = new List<IT4Play>();          
            Players.Add(new InterfacePlayer(matrerial, outpath));
           
            foreach(var inheritedT4DataModel in inheritedT4DataModels)
            {
                Players.Add(new InheritedPlayer(matrerial,inheritedT4DataModel, outpath));
            }
        }

        #endregion


    }
}
