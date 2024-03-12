using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;

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
        public List<SeazonModel> GetSeazons()
        {
            List<SeazonModel> seazons = new List<SeazonModel>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<MSeazon, SeazonModel>(); });
            Mapper map = new Mapper(config);

            Context.GetSeazons().ToList()
                            .ForEach(record =>
                            {
                                var newRec = map.Map<SeazonModel>(record);
                                seazons.Add(newRec);
                            });

            return seazons;
        }
        #endregion
    }
}
