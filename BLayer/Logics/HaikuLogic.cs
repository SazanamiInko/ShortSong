using AutoMapper;
using BLayer.DataModel;
using DLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLayer.Logics
{
    public class HaikuLogic
    {
        #region プロパティ

        /// <summary>
        /// データコンテキスト
        /// </summary>
        public UtaContext Context { get; set; }

        public bool AddHaiku(HaikuModel model)
        {
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

        #endregion

        #region API

        /// <summary>
        /// ID発行
        /// </summary>
        /// <returns>発行したID</returns>
        public long PublishedID()
        {
            if (Context.THaikus.Count() == 0)
            {
                return 1;
            }

            var max = Context.THaikus.Max(record => record.Id) + 1;
            return max;
        }


        #endregion
    }

}
