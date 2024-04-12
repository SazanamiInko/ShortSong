
namespace Interfaces.DataModels
{

    /// <summary>
    ///  短歌更新用
    /// </summary>
    public interface IShortSongUpdateDataModel
    {
        
        /// <summary>
    ///  管理番号
    /// </summary>
    public long Id{get;set;} 
              
        /// <summary>
    ///  前書き
    /// </summary>
    public string Front{get;set;} 
              
        /// <summary>
    ///  短歌
    /// </summary>
    public string Uta{get;set;} 
              
        /// <summary>
    ///  かな
    /// </summary>
    public string Kana{get;set;} 
              
        /// <summary>
    ///  英語
    /// </summary>
    public string English{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public string Index{get;set;} 
              
        /// <summary>
    ///  備考
    /// </summary>
    public string Memo{get;set;} 
              
        /// <summary>
    ///  季節
    /// </summary>
    public long Seazon{get;set;} 
              
        /// <summary>
    ///  本歌
    /// </summary>
    public string RefUta{get;set;} 
              
        /// <summary>
    ///  更新日時
    /// </summary>
    public string UpdateDate{get;set;} 
              
        /// <summary>
    ///  更新回数
    /// </summary>
    public long UpdateCount{get;set;} 
              
        /// <summary>
    ///  コメント
    /// </summary>
    public string Comment{get;set;} 
          
    }
}