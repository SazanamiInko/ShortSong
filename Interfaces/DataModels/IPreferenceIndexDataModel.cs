
namespace Interfaces.DataModels
{

    /// <summary>
    ///  お気に入り一覧用
    /// </summary>
    public interface IPreferenceIndexDataModel
    {
        
        /// <summary>
    ///  管理番号
    /// </summary>
    public long Id{get;set;} 
              
        /// <summary>
    ///  短歌
    /// </summary>
    public String Uta{get;set;} 
              
        /// <summary>
    ///  作者
    /// </summary>
    public String Auther{get;set;} 
          
    }
}