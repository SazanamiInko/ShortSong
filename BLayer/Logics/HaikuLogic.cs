﻿using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;
using Interfaces.DataModels;

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
        public bool AddHaiku(IHaikuDataModel model)
        {

            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IHaikuDataModel, THaiku>(); });
            Mapper map = new Mapper(config);
            try
            {
                var record = map.Map<THaiku>(model);
                record.UpdateCount = 0;
                record.UpdateDateTime = string.Empty;
                record.CreateDateTime = DateTime.Now.ToString();
                Context.InsertHaiku(record);
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

            if (Context.GetHaikus().Count() == 0)
            {
                return 1;
            }

            var max = Context.GetHaikus().Max(record => record.Id) + 1;
            return max;
        }

        /// <summary>
        /// 俳句一覧取得
        /// </summary>
        /// <param name="keyword">キーワード</param>
        /// <returns>俳句一覧</returns>
        public List<IHaikuIndexDataModel> GetHaikus(string keyword)
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            List<IHaikuIndexDataModel> haikus = new List<IHaikuIndexDataModel>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<THaiku, ServerHaikuIndexDataModel>(); });
            Mapper map = new Mapper(config);


            Context.GetHaikus().Where(record => ((record.Haiku.IndexOf(keyword) != -1)
                                                  || (record.Index.IndexOf(keyword) != -1)))
                                .Where(record => record.Delete == 0)
                                .ToList()
               .ForEach(record =>
               {

                   var newRec = map.Map<ServerHaikuIndexDataModel>(record);
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
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            var target = Context.GetHaikus().Where(record => record.Id == id)
                .FirstOrDefault();

            if (target != null)
            {
                target.UpdateDateTime = DateTime.Now.ToString();
                target.Delete = 1;
                Context.SaveChanges();
            }
            else
            {
                throw new Exception("システム例外が発生しました");
            }

            return true;
        }


        /// <summary>
        /// 俳句取得
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>俳句</returns>
        public IHaikuDataModel GetHaiku(long id)
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }

            ServerHaikuDataModel ret = new ServerHaikuDataModel();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<THaiku, ServerHaikuDataModel>(); });
            Mapper map = new Mapper(config);

            var record = Context.GetHaikus().Where(record => record.Id == id)
                .FirstOrDefault();

            if (record != null)
            {
                return map.Map<ServerHaikuDataModel>(record);
            }
            return null;

        }

        /// <summary>
        /// 俳句更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHaiku(IHaikuUpdateDataModel model)
        {
            if (Context == null)
            {
                throw new Exception("システム例外が発生しました");
            }


            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IHaikuUpdateDataModel, THaiku>(); });
            Mapper map = new Mapper(config);
            try
            {

                var target = Context.GetHaikus().Where(record => record.Id == model.Id)
                         .FirstOrDefault();

                if (target == null)
                {
                    return false;
                }

                map.Map(model, target);
                target.UpdateCount = model.UpdateCount + 1;
                target.UpdateDateTime = DateTime.Now.ToString();
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
