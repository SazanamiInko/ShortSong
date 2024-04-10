
namespace Interfaces.DataModels
{

    /// <summary>
    ///  俳句一覧用
    /// </summary>
    public interface IHaikuIndexDataModel
    {
        
        /// <summary>
    ///  管理番号
    /// </summary>
    public long ID{get;set;} 
              
        /// <summary>
    ///  俳句
    /// </summary>
    public String Haiku{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public String Index{get;set;} 
          
    }
}