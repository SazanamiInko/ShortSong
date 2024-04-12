
namespace Interfaces.DataModels
{

    /// <summary>
    ///  お気に入り
    /// </summary>
    public interface IPreferenceDataModel
    {
        
        /// <summary>
    ///  短歌
    /// </summary>
    public string Uta{get;set;} 
              
        /// <summary>
    ///  作者
    /// </summary>
    public string Author{get;set;} 
              
        /// <summary>
    ///  出典
    /// </summary>
    public string Book{get;set;} 
              
        /// <summary>
    ///  時代
    /// </summary>
    public string Era{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public string Index{get;set;} 
              
        /// <summary>
    ///  備考
    /// </summary>
    public string Memo{get;set;} 
              
        /// <summary>
    ///  登録日時
    /// </summary>
    public string CreateDate{get;set;} 
          
    }
}