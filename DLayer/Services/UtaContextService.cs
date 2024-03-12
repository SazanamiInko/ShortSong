using AutoMapper;
using DLayer.Interfacrs;
using DLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLayer.Services
{
    /// <summary>
    /// 歌コンテキストサービス
    /// </summary>
    public class UtaContextService : IUtaContext
    {
        #region メンバー

        private UtaContext context;

        #endregion

        #region プロパティ


        public DbSet<THaiku> THaikus { get { return context.THaikus; } }

        public DbSet<THistory> THistories { get { return context.THistories; } }

        public DbSet<TPreference> TPreferences { get { return context.TPreferences; } }


        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UtaContextService()
        {
            context = new UtaContext();
        }

        #endregion

        #region ラッパー関数

        /// <summary>
        /// 保存処理
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        #endregion

        #region データ層API

        #region 季節

        /// <summary>
        /// 季節の取得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<MSeazon> GetSeazons()
        {
            return context.MSeazons.ToList();
        }

        #endregion

        #region 短歌

        /// <summary>
        /// 短歌の取得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<TShortSong> GetShortSong()
        {
            return context.TShortSongs.ToList();
        }

        /// <summary>
        /// 短歌の登録
        /// </summary>
        /// <param name="shortSong"></param>
        public void InsertShortSong(TShortSong shortSong)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TShortSong, TShortSong>(); });
            Mapper map = new Mapper(config);
            var record = map.Map<TShortSong>(shortSong);

            context.TShortSongs.Add(record);
        }

        /// <summary>
        /// 短歌の削除
        /// </summary>
        /// <param name="shortSong"></param>
        public void RemoveShortSong(TShortSong shortSong)
        {
            var target = context.TShortSongs.Where(record => record.Id == shortSong.Id)
                .FirstOrDefault();

            if (target != null)
            {
                context.TShortSongs.Remove(target);
            }
        }

        /// <summary>
        /// 短歌の更新
        /// </summary>
        /// <param name="shortSong"></param>
        public void UpdateShortSong(TShortSong shortSong)
        {
            var target = context.TShortSongs.Where(record => record.Id == shortSong.Id)
                .FirstOrDefault();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TShortSong, TShortSong>(); });
            Mapper map = new Mapper(config);
            target = map.Map<TShortSong>(shortSong);

        }

        #endregion

        #region お気に入り
        /// <summary>
        /// お気に入りの取得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<TPreference> GetPreferences()
        {
            return context.TPreferences.ToList();
        }

        /// <summary>
        /// お気に入りの更新
        /// </summary>
        /// <param name="preference"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdatePreferences(TPreference preference)
        {
            var target = context.TPreferences.Where(record => record.Id == preference.Id)
               .FirstOrDefault();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPreference, TPreference>(); });
            Mapper map = new Mapper(config);
            target = map.Map<TPreference>(preference);
        }

        /// <summary>
        /// お気に入りの登録
        /// </summary>
        /// <param name="preference"></param>
        public void InsertPreferences(TPreference preference)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPreference, TPreference>(); });
            Mapper map = new Mapper(config);
            var record = map.Map<TPreference>(preference);

            context.TPreferences.Add(record);
        }

        /// <summary>
        /// お気に入りの削除
        /// </summary>
        /// <param name="preference"></param>
        public void RemovePreferences(TPreference preference)
        {
            var target = context.TPreferences.Where(record => record.Id == preference.Id)
               .FirstOrDefault();
            context.TPreferences.Remove(target);
        }
        #endregion

        #region 俳句
        /// <summary>
        /// 俳句の取得
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<THaiku> GetHaikus()
        {
            return context.THaikus.ToList();
        }

        /// <summary>
        /// 俳句の登録
        /// </summary>
        /// <param name="haiku"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void InsertHaiku(THaiku haiku)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<THaiku, THaiku>(); });
            Mapper map = new Mapper(config);
            var record = map.Map<THaiku>(haiku);

            context.THaikus.Add(record);
        }

        /// <summary>
        /// 俳句の削除
        /// </summary>
        /// <param name="haiku"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveHaiku(THaiku haiku)
        {
            var target = context.THaikus.Where(record => record.Id == haiku.Id)
             .FirstOrDefault();
            context.THaikus.Remove(target);
        }

        /// <summary>
        /// 俳句の更新
        /// </summary>
        /// <param name="haiku"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateHaiku(THaiku haiku)
        {
            var target = context.THaikus.Where(record => record.Id == haiku.Id)
             .FirstOrDefault();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<THaiku, THaiku>(); });
            Mapper map = new Mapper(config);
            target = map.Map<THaiku>(haiku);
        }
        #endregion

        #endregion
    }
}
