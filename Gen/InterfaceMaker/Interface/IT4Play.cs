using InterfaceMaker.DataModel;

namespace InterfaceMaker.Interface
{
    /// <summary>
    /// T4実行者
    /// </summary>
    public abstract class IT4Play
    {
        #region フィールド

        /// <summary>
        /// パス
        /// </summary>
        protected string path;
         
        #endregion

        #region メソッド
        /// <summary>
        /// 実行
        /// </summary>
        public abstract void Play();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string GetFileName();
        #endregion
    }
}
