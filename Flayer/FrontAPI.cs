using BLayer.DataModel;
using BLayer.Logics;
using DLayer.Services;
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
        public static bool AddHaiku(HaikuModel model)
        {
            return haikuLogic.AddHaiku(model);
        }

        /// <summary>
        /// 俳句一覧取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<HaikuSimple> GetHaikus(string keyword)
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
        public static HaikuModel GetHaiku(long id)
        {
            return haikuLogic.GetHaiku(id);
        }

        /// <summary>
        /// 俳句更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateHaiku(HaikuUpdateModel model)
        {
            return haikuLogic.UpdateHaiku(model);
        }

        /// <summary>
        /// お気に入り追加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddPreference(PreferenceAddModel model)
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
        public static bool UpdatePregerence(PreferenceUpdateModel model)
        {
            return preferenceLogic.UpdatePregerence(model);
        }

        /// <summary>
        /// お気に入り取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PreferenceUpdateModel GetPreference(long id)
        {
            return preferenceLogic.GetPreference(id);
        }

        /// <summary>
        /// お気に入り一覧取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<PreferenceSimpleModel> GetPreferences(string keyword)
        {
            return preferenceLogic.GetPreferences(keyword);
        }

        /// <summary>
        /// 季節マスタ取得
        /// </summary>
        /// <returns></returns>
        public static List<SeazonModel> GetSeazons()
        {
            return seazonLogic.GetSeazons();
        }

        /// <summary>
        /// 短歌登録
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AddShortSong(ShortSongModel model)
        {
            return shortSongLogic.AddShortSong(model);
        }

        /// <summary>
        /// 短歌更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool UpdateShortSong(ShortSongUpdateModel model)
        {
            return shortSongLogic.UpdateShortSong(model);
        }

        /// <summary>
        /// 短歌一覧取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<ShortSongSimple> GetShortSongs(string keyword)
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
        public static ShortSongUpdateModel GetShortSong(long id)
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
