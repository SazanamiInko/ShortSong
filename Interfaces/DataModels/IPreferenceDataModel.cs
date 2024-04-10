
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
    public String Uta{get;set;} 
              
        /// <summary>
    ///  作者
    /// </summary>
    public String Author{get;set;} 
              
        /// <summary>
    ///  出典
    /// </summary>
    public String Book{get;set;} 
              
        /// <summary>
    ///  時代
    /// </summary>
    public String Era{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public String Index{get;set;} 
              
        /// <summary>
    ///  備考
    /// </summary>
    public String Memo{get;set;} 
              
        /// <summary>
    ///  登録日時
    /// </summary>
    public String CreateDate{get;set;} 
          
    }
}