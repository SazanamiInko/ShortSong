using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;
using Interfaces.DataModels;

namespace BLayer.Logics
{
    /// <summary>
    /// 季節ロジック
    /// </summary>
    public  class SeazonLogic
    {
        #region プロパティ

        /// <summary>
        /// データコンテキスト
        /// </summary>
        public IUtaContext Context { get; set; }

        #endregion

        #region API

        /// <summary>
        /// 季節を取得
        /// </summary>
        /// <returns></returns>
        public List<ISeazonDataModel> GetSeazons()
        {
            List<ISeazonDataModel> seazons = new List<ISeazonDataModel>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MSeazon, ServerSeazonDataModel>(); });
            Mapper map = new Mapper(config);

            Context.GetSeazons().ToList()
                            .ForEach(record =>
                            {
                                var newRec = map.Map<ServerSeazonDataModel>(record);
                                seazons.Add(newRec);
                            });

            return seazons;
        }
        #endregion
    }
}
