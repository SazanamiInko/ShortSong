using DLayer.Interfacrs;
using DLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontUT.TDLayer
{
    /// <summary>
    /// テスト用データ層
    /// </summary>
    public class TestUtaContextService : IUtaContext
    {
        #region メンバー変数

        /// <summary>
        /// 短歌 
        /// </summary>
        public List<TShortSong> ShortSongs { get; }

        /// <summary>
        /// お気に入り 
        /// </summary>
        public List<TPreference> Preferences { get; }

        /// <summary>
        /// 俳句 
        /// </summary>
        public List<THaiku> Haikus { get; }

        /// <summary>
        /// 季節 
        /// </summary>
        public List<MSeazon> Seazons { get; }
        #endregion


        #region いずれ消す
        public DbSet<THistory> THistories => throw new NotImplementedException();
        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TestUtaContextService()
        {
            this.Seazons = new List<MSeazon>();
            this.ShortSongs = new List<TShortSong>();
            this.Haikus = new List<THaiku>();
            this.Preferences = new List<TPreference>();
        }

        #endregion

        #region オーバーライド関数

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void SaveChanges()
        {

        }

        #endregion

        #region データ層API

        /// <summary>
        /// 季節の取得
        /// </summary>
        /// <returns></returns>
        public List<MSeazon> GetSeazons()
        {
            return this.Seazons;
        }

        /// <summary>
        /// 短歌の取得
        /// </summary>
        /// <returns></returns>
        public List<TShortSong> GetShortSong()
        {
            return this.ShortSongs;
        }

        /// <summary>
        /// 短歌の更新
        /// </summary>
        /// <param name="shortSong"></param>
        public void UpdateShortSong(TShortSong shortSong)
        {
            var target = ShortSongs.Where(record => record.Id == shortSong.Id)
                 .FirstOrDefault();
            target = shortSong;
        }

        /// <summary>
        /// 短歌の登録
        /// </summary>
        /// <param name="shortSong"></param>
        public void InsertShortSong(TShortSong shortSong)
        {
            this.ShortSongs.Add(shortSong);
        }

        /// <summary>
        /// お気に入りの取得
        /// </summary>
        /// <returns></returns>
        public List<TPreference> GetPreferences()
        {
            return this.Preferences;
        }

        /// <summary>
        /// お気に入りの更新
        /// </summary>
        /// <param name="preference"></param>
        public void UpdatePreferences(TPreference preference)
        {
            var target = this.Preferences.Where(record => record.Id == preference.Id)
                  .FirstOrDefault();
            target = preference;
        }

        /// <summary>
        /// お気に入りの登録
        /// </summary>
        /// <param name="preference"></param>
        public void InsertPreferences(TPreference preference)
        {
            this.Preferences.Add(preference);
        }

        /// <summary>
        /// お気に入りの削除
        /// </summary>
        /// <param name="preference"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemovePreferences(TPreference preference)
        {
            var target = this.Preferences.Where(record => record.Id == preference.Id)
                 .FirstOrDefault();

            if (target != null)
            {
                this.Preferences.Remove(target);
            }
        }

        /// <summary>
        /// 俳句の取得
        /// </summary>
        /// <returns></returns>
        public List<THaiku> GetHaikus()
        {
            return this.Haikus;
        }

        /// <summary>
        /// 俳句の登録
        /// </summary>
        /// <param name="haiku"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void InsertHaiku(THaiku haiku)
        {
            this.Haikus.Add(haiku);
        }

        /// <summary>
        /// 俳句の削除
        /// </summary>
        /// <param name="haiku"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveHaiku(THaiku haiku)
        {
            var target = this.Haikus.Where(record => record.Id == haiku.Id)
               .FirstOrDefault();

            if (target != null)
            {
                this.Haikus.Remove(target);
            }
        }

        /// <summary>
        /// 俳句の更新
        /// </summary>
        /// <param name="haiku"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateHaiku(THaiku haiku)
        {
            var target = this.Haikus.Where(record => record.Id == haiku.Id)
                   .FirstOrDefault();
            target = haiku;
        }
        #endregion


        #region テスト専用
        /// <summary>
        /// テストをクリアする
        /// </summary>
        public void TestClear()
        {
            this.ShortSongs.Clear();
            this.Preferences.Clear();
            this.Haikus.Clear();
            this.Seazons.Clear();
        }

        #endregion
    }
}
