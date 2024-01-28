using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;

namespace BLayer.Logics
{
    /// <summary>
    /// 俳句業務ロジックAPI
    /// </summary>
    public class HaikuLogic
    {
        #region プロパティ

        /// <summary>
        /// データコンテキスト
        /// </summary>
        public IUtaContext? Context { get; set; }

        #endregion

        #region API

        /// <summary>
        /// 俳句登録API
        /// </summary>
        /// <param name="model">俳句登録モデル</param>
        /// <returns>俳句登録できた場合はtrue</returns>
        public bool AddHaiku(HaikuModel model)
        {

            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<HaikuModel, THaiku>(); });
            Mapper map = new Mapper(config);
            try
            {  
                var record = map.Map<THaiku>(model);
                Context.THaikus.Add(record);
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
        /// 俳句ID発行
        /// </summary>
        /// <returns>発行したID</returns>
        public long PublishedID()
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            if (Context.THaikus.Count() == 0)
            {
                return 1;
            }

            var max = Context.THaikus.Max(record => record.Id) + 1;
            return max;
        }

        /// <summary>
        /// 俳句一覧取得
        /// </summary>
        /// <param name="keyword">キーワード</param>
        /// <returns>俳句一覧</returns>
        public List<HaikuSimple> GetHaikus(string keyword)
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            List<HaikuSimple> haikus = new List<HaikuSimple>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<THaiku, HaikuSimple>(); });
            Mapper map = new Mapper(config);


            Context.THaikus.Where(record => record.Haiku.IndexOf(keyword) != -1)
                                .Where(record => record.Delete == 0)
                                .ToList()
               .ForEach(record =>
               {

                   var newRec = map.Map<HaikuSimple>(record);
                   haikus.Add(newRec);
               });


            return haikus;
        }

        /// <summary>
        /// 俳句削除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>削除に成功した場合はrue</returns>
        public bool DeleteHaiku(long id)
        {
            try
            {
                if (Context == null)
                {
                    throw new Exception("システム例外が発生しました");
                }

                var target = Context.THaikus.Where(record => record.Id == id)
                    .FirstOrDefault();

                if (target != null)
                {
                    target.UpdateDateTime = DateTime.Now.ToString();
                    target.Delete = 1;
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
        /// 俳句取得
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>俳句</returns>
        public HaikuModel GetHaiku(long id)
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            HaikuModel ret = new HaikuModel();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<THaiku, HaikuModel>(); });
            Mapper map = new Mapper(config);


            var record = Context.TShortSongs.Where(record => record.Id == id)
                .FirstOrDefault();

            if (record != null)
            {
                return map.Map<HaikuModel>(record);
            }
            return ret;

        }

        /// <summary>
        /// 俳句更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHaiku(HaikuUpdateModel model)
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }


            var config = new MapperConfiguration(cfg => { cfg.CreateMap<HaikuUpdateModel, THaiku>(); });
            Mapper map = new Mapper(config);
            try
            {

                var target = Context.TShortSongs.Where(record => record.Id == model.Id)
                         .FirstOrDefault();

                if (target == null)
                {
                    return false;
                }

                map.Map(model, target);
                target.UpdateCount = model.UpdateCount + 1;
                target.UpdateDate = DateTime.Now.ToString();
                Context.SaveChanges();

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

            return true;
        }
    }
#endregion
}
