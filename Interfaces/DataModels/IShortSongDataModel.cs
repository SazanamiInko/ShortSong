
namespace Interfaces.DataModels
{

    /// <summary>
    ///  短歌
    /// </summary>
    public interface IShortSongDataModel
    {
        
        /// <summary>
    ///  管理番号
    /// </summary>
    public long Id{get;set;} 
              
        /// <summary>
    ///  前書き
    /// </summary>
    public String Front{get;set;} 
              
        /// <summary>
    ///  短歌
    /// </summary>
    public String Uta{get;set;} 
              
        /// <summary>
    ///  かな
    /// </summary>
    public String Kana{get;set;} 
              
        /// <summary>
    ///  英語
    /// </summary>
    public String English{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public String Index{get;set;} 
              
        /// <summary>
    ///  備考
    /// </summary>
    public String Memo{get;set;} 
              
        /// <summary>
    ///  季節
    /// </summary>
    public String Seazon{get;set;} 
              
        /// <summary>
    ///  登録日時
    /// </summary>
    public String CreateDate{get;set;} 
              
        /// <summary>
    ///  削除フラグ
    /// </summary>
    public long Delete{get;set;} 
              
        /// <summary>
    ///  本歌
    /// </summary>
    public String RefUta{get;set;} 
          
    }
}