
namespace Interfaces.DataModels
{

    /// <summary>
    ///  俳句
    /// </summary>
    public interface IHaikuDataModel
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
    ///  俳句
    /// </summary>
    public String Haiku{get;set;} 
              
        /// <summary>
    ///  かな
    /// </summary>
    public String Kana{get;set;} 
              
        /// <summary>
    ///  英語
    /// </summary>
    public String English{get;set;} 
              
        /// <summary>
    ///  備考
    /// </summary>
    public String Memo{get;set;} 
              
        /// <summary>
    ///  季節
    /// </summary>
    public long Seazon{get;set;} 
              
        /// <summary>
    ///  季語
    /// </summary>
    public String SeazonWord{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public String Index{get;set;} 
              
        /// <summary>
    ///  作成日時
    /// </summary>
    public String CreateDateTime{get;set;} 
              
        /// <summary>
    ///  更新日時
    /// </summary>
    public String UpdateDateTime{get;set;} 
              
        /// <summary>
    ///  更新回数
    /// </summary>
    public long UpdateCount{get;set;} 
              
        /// <summary>
    ///  削除フラグ
    /// </summary>
    public long Delete{get;set;} 
          
    }
}