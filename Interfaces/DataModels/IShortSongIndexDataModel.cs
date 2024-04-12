
namespace Interfaces.DataModels
{

    /// <summary>
    ///  短歌一覧用
    /// </summary>
    public interface IShortSongIndexDataModel
    {
        
        /// <summary>
    ///  管理番号
    /// </summary>
    public long Id{get;set;} 
              
        /// <summary>
    ///  短歌
    /// </summary>
    public string Uta{get;set;} 
              
        /// <summary>
    ///  見出し
    /// </summary>
    public string Index{get;set;} 
          
    }
}