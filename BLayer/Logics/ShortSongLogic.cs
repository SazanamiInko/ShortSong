using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;

namespace BLayer.Logics
{
    /// <summary>
    /// 短歌ロジック
    /// </summary>
    public class ShortSongLogic
    {
        #region プロパティ

        /// <summary>
        /// データコンテキスト
        /// </summary>
        public IUtaContext Context { get; set; }

        #endregion

        #region API    

        /// <summary>
        /// ID発行
        /// </summary>
        /// <returns>発行したID</returns>
        public long PublishedID()
        {
            if (Context.GetShortSong().Count() == 0)
            {
                return 1;
            }

            var max = Context.GetShortSong().Max(record => record.Id) + 1;
            return max;
        }


        /// <summary>
        /// 短歌追加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddShortSong(ShortSongModel model)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ShortSongModel, TShortSong>(); });
            Mapper map = new Mapper(config);
            try
            {

                var record = map.Map<TShortSong>(model);
                Context.InsertShortSong(record);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }

        /// <summary>
        /// 短歌更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateShortSong(ShortSongUpdateModel model)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ShortSongUpdateModel, TShortSong>(); });
            Mapper map = new Mapper(config);
            try
            {

                var target = Context.GetShortSong().Where(record => record.Id == model.Id)
                         .FirstOrDefault();

                if (target == null)
                {
                    return false;
                }

                THistory history = new THistory();
                history.Comment = model.Comment;
                history.ShortSong = model.Id;

                if (target.Uta != model.Uta)
                {
                    history.Before = target.Uta;
                }

                map.Map(model, target);
                Context.UpdateShortSong(target);
                Context.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }


        /// <summary>
        /// 短歌一覧
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<ShortSongSimple> GetShortSongs(string keyword)
        {
            List<ShortSongSimple> songs = new List<ShortSongSimple>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TShortSong, ShortSongSimple>(); });
            Mapper map = new Mapper(config);


            Context.GetShortSong().Where(record => record.Uta.IndexOf(keyword) != -1
                                             || (record.Index != null
                                                 && record.Index.IndexOf(keyword) != -1))
                                .Where(record => record.Delete == 0)
                                .ToList()
               .ForEach(record =>
               {

                   var newRec = map.Map<ShortSongSimple>(record);
                   songs.Add(newRec);
               });


            return songs;
        }

        /// <summary>
        /// 短歌削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteShortSong(long id)
        {
            try
            {

                var target = Context.GetShortSong().Where(record => record.Id == id)
                    .FirstOrDefault();

                if (target != null)
                {
                    target.Delete = 1;
                    Context.UpdateShortSong(target);
                    Context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        /// <summary>
        /// 短歌取得
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>短歌</returns>
        public ShortSongUpdateModel GetShortSong(long id)
        {
            ShortSongUpdateModel ret = new ShortSongUpdateModel();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TShortSong, ShortSongUpdateModel>(); });
            Mapper map = new Mapper(config);


            var record = Context.GetShortSong().Where(record => record.Id == id)
                .FirstOrDefault();

            if (record != null)
            {
                return map.Map<ShortSongUpdateModel>(record);
            }
            return ret;

        }

        #endregion
    }
}
