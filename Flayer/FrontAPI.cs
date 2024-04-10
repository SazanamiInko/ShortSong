using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Services;
using Interfaces.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLayer
{
    /// <summary>
    /// APIフロント
    /// </summary>
    public static class FrontAPI
    {
        #region メンバー
        /// <summary>
        /// DBコンテキスト
        /// </summary>
        private static UtaContextService context;

        /// <summary>
        /// 短歌ロジック
        /// </summary>
        private static ShortSongLogic shortSongLogic;

        /// <summary>
        /// お気に入りロジック
        /// </summary>
        private static PreferenceLogic preferenceLogic;

        /// <summary>
        /// 季節マスタロジック
        /// </summary>
        private static SeazonLogic seazonLogic;

        /// <summary>
        /// 俳句ロジック
        /// </summary>
        private static HaikuLogic haikuLogic;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static FrontAPI()
        {
            context = new UtaContextService();

            shortSongLogic=new ShortSongLogic();
            preferenceLogic=new PreferenceLogic();
            seazonLogic = new SeazonLogic();
            haikuLogic = new HaikuLogic();

            shortSongLogic.Context = context;
            preferenceLogic.Context = context;
            seazonLogic.Context = context;
            haikuLogic.Context = context;
        }
        #endregion

        #region API

        /// <summary>
        /// 俳句管理番号発効
        /// </summary>
        /// <returns></returns>
        public static long PublishedHaikuId()
        {
            return haikuLogic.PublishedID();
        }

        /// <summary>
        /// 俳句登録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddHaiku(IHaikuDataModel model)
        {
            return haikuLogic.AddHaiku(model);
        }

        /// <summary>
        /// 俳句一覧取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<IHaikuIndexDataModel> GetHaikus(string keyword)
        {
            return haikuLogic.GetHaikus(keyword);
        }

        /// <summary>
        /// 俳句削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteHaiku(long id)
        {
            return haikuLogic.DeleteHaiku(id);
        }

        /// <summary>
        /// 俳句取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IHaikuDataModel GetHaiku(long id)
        {
            return haikuLogic.GetHaiku(id);
        }

        /// <summary>
        /// 俳句更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateHaiku(IHaikuUpdateDataModel model)
        {
            return haikuLogic.UpdateHaiku(model);
        }

        /// <summary>
        /// お気に入り追加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddPreference(IPreferenceDataModel model)
        {
            return preferenceLogic.AddPreference(model);
        }

        /// <summary>
        /// お気に入り削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeletePreference(long id) 
        {
            return preferenceLogic.DeletePrefernce(id);
        }

        /// <summary>
        /// お気に入り更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdatePregerence(IPreferenceUpdateDataModel model)
        {
            return preferenceLogic.UpdatePregerence(model);
        }

        /// <summary>
        /// お気に入り取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IPreferenceUpdateDataModel GetPreference(long id)
        {
            return preferenceLogic.GetPreference(id);
        }

        /// <summary>
        /// お気に入り一覧取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<IPreferenceIndexDataModel> GetPreferences(string keyword)
        {
            return preferenceLogic.GetPreferences(keyword);
        }

        /// <summary>
        /// 季節マスタ取得
        /// </summary>
        /// <returns></returns>
        public static List<ISeazonDataModel> GetSeazons()
        {
            return seazonLogic.GetSeazons();
        }

        /// <summary>
        /// 短歌登録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddShortSong(IShortSongDataModel model)
        {
            return shortSongLogic.AddShortSong(model);
        }

        /// <summary>
        /// 短歌更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateShortSong(IShortSongUpdateDataModel model)
        {
            return shortSongLogic.UpdateShortSong(model);
        }

        /// <summary>
        /// 短歌一覧取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<IShortSongIndexDataModel> GetShortSongs(string keyword)
        {
            return shortSongLogic.GetShortSongs(keyword);
        }

        /// <summary>
        /// 短歌削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool DeleteShortSong(long id)
        {
            return shortSongLogic.DeleteShortSong(id);
        }

        /// <summary>
        /// 短歌取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IShortSongUpdateDataModel GetShortSong(long id)
        {
            return shortSongLogic.GetShortSong(id);
        }
        
        /// <summary>
        /// 短歌管理番号発効
        /// </summary>
        /// <returns></returns>
        public static long PublishIDShortSong()
        {
            return shortSongLogic.PublishedID();
        }

        #endregion
    }
}
