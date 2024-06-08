using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;
using Interfaces.DataModels;

namespace BLayer.Logics
{
    /// <summary>
    /// お気に入りロジック
    /// </summary>
    public class PreferenceLogic
    {
        #region プロパティ

        /// <summary>
        /// データコンテキスト
        /// </summary>
        public IUtaContext Context { get; set; }

        #endregion

        #region API
        /// <summary>
        /// お気に入り登録
        /// </summary>
        /// <param name="model">お気に入りモデル</param>
        /// <returns>成功した場合true</returns>
        public bool AddPreference(IPreferenceDataModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<IPreferenceDataModel, TPreference>(); });
                Mapper map = new Mapper(config);

                var record = map.Map<TPreference>(model);
                Context.InsertPreferences(record);
                Context.SaveChanges();

            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// お気に入り取得
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<IPreferenceIndexDataModel> GetPreferences(string keyword)
        {
            List<IPreferenceIndexDataModel> ret = new List<IPreferenceIndexDataModel>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPreference, ServerPreferenceIndexDataModel>(); });
            Mapper map = new Mapper(config);


            Context.GetPreferences().Where(record => record.Uta.IndexOf(keyword) > -1
                                                 || record.Author.IndexOf(keyword) > -1)
                .ToList()
                .ForEach(record =>
                {
                    var newRecord = map.Map<ServerPreferenceIndexDataModel>(record);
                    ret.Add(newRecord);
                });


            return ret;
        }

        /// <summary>
        /// お気に入り更新
        /// </summary>
        /// <param name="model">お気に入りモデル</param>
        /// <returns></returns>
        public bool UpdatePregerence(IPreferenceUpdateDataModel model)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<IPreferenceUpdateDataModel, TPreference>(); });
            Mapper map = new Mapper(config);

            try
            {

                var target = Context.GetPreferences().Where(record => record.Id == model.Id)
                                   .FirstOrDefault();
                if (target == null)
                {
                    return true;
                }
                map.Map(model, target);
                Context.UpdatePreferences(target);
                Context.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        /// <summary>
        /// お気に入り削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletePrefernce(long id)
        {
            try
            {
                var target = Context.GetPreferences().Where(record => record.Id == id)
                                   .FirstOrDefault();
                if (target == null)
                {
                    return true;
                }

                Context.RemovePreferences(target);
                Context.SaveChanges();
            }
            catch (Exception)
            {


                return false;
            }
            return true;
        }

        /// <summary>
        /// お気に入り取得
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IPreferenceUpdateDataModel GetPreference(long id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPreference, ServerPreferenceUpdateDataModel>(); });
            Mapper map = new Mapper(config);


            var target = Context.GetPreferences().Where(record => record.Id == id)
                .FirstOrDefault();
            if (target == null)
            {
                return new ServerPreferenceUpdateDataModel();
            }

            return map.Map<ServerPreferenceUpdateDataModel>(target);

        }


        /// <summary>
        /// お気に入り一括登録
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool AddBatchPreference(IPreferenceBatchDataModel model)
        {
            Context.ExecTransaction(() =>
                {

                    var commonConfig = new MapperConfiguration(cfg => { cfg.CreateMap<IPreferenceBatchDataModel, TPreference>(); });
                    Mapper commonMap = new Mapper(commonConfig);

                    var detailConfig = new MapperConfiguration(cfg => { cfg.CreateMap<IPreferenceDetailDataModel, TPreference>(); });
                    Mapper detailMap = new Mapper(detailConfig);


                    foreach (var uta in model.Items)
                    {
                        var record = commonMap.Map<TPreference>(model);
                        detailMap.Map(uta, record);
                        Context.InsertPreferences(record);

                    }

                    Context.SaveChanges();

                }
                #endregion

            );

            return true;
        }
    }
}
