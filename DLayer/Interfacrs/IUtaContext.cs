using DLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLayer.Interfacrs
{
    /// <summary>
    /// 歌コンテキストインターフェース
    /// </summary>
    public interface IUtaContext
    {

        public DbSet<THistory> THistories { get; }


        #region データアクセス

        #region 季節  
        /// <summary>
        /// 季節の取得
        /// </summary>
        /// <returns></returns>
        public List<MSeazon> GetSeazons();
        #endregion

        #region 短歌
        /// <summary>
        /// 短歌の取得
        /// </summary>
        /// <returns></returns>
        public List<TShortSong> GetShortSong();

        /// <summary>
        /// 短歌の更新
        /// </summary>
        /// <param name="shortSong"></param>
        public void UpdateShortSong(TShortSong shortSong);

        /// <summary>
        /// 短歌の登録
        /// </summary>
        /// <param name="shortSong"></param>
        public void InsertShortSong(TShortSong shortSong);
        #endregion

        #region お気に入り

        /// <summary>
        /// お気に入りの取得
        /// </summary>
        /// <returns></returns>
        public List<TPreference> GetPreferences();

        /// <summary>
        /// お気に入りの更新
        /// </summary>
        /// <param name="preference"></param>
        public void UpdatePreferences(TPreference preference);

        /// <summary>
        /// お気に入りの登録
        /// </summary>
        /// <param name="preference"></param>
        public void InsertPreferences(TPreference preference);

        /// <summary>
        /// お気に入りの削除
        /// </summary>
        /// <param name="preference"></param>
        public void RemovePreferences(TPreference preference);
        #endregion

        #region 俳句

        /// <summary>
        /// 俳句の取得
        /// </summary>
        /// <returns></returns>
        public List<THaiku> GetHaikus();

        /// <summary>
        /// 俳句の登録
        /// </summary>
        /// <param name="haiku"></param>
        public void InsertHaiku(THaiku haiku);

        /// <summary>
        /// 俳句の削除
        /// </summary>
        /// <param name="haiku"></param>
        public void RemoveHaiku(THaiku haiku);

        /// <summary>
        /// 俳句の更新
        /// </summary>
        /// <param name="haiku"></param>
        public void UpdateHaiku(THaiku haiku);

        #endregion

        #endregion


        public void SaveChanges();
    }
}
