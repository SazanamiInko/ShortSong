using AutoMapper;
using BLayer.DataModel;
using DLayer.Interfacrs;
using DLayer.Models;

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
        public bool AddPreference(PreferenceAddModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<PreferenceAddModel, TPreference>(); });
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
        public List<PreferenceSimpleModel> GetPreferences(string keyword)
        {
            List<PreferenceSimpleModel> ret = new List<PreferenceSimpleModel>();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPreference, PreferenceSimpleModel>(); });
            Mapper map = new Mapper(config);


            Context.GetPreferences().Where(record => record.Uta.IndexOf(keyword) > -1
                                                 || record.Author.IndexOf(keyword) > -1)
                .ToList()
                .ForEach(record =>
                {
                    var newRecord = map.Map<PreferenceSimpleModel>(record);
                    ret.Add(newRecord);
                });


            return ret;
        }

        /// <summary>
        /// お気に入り更新
        /// </summary>
        /// <param name="model">お気に入りモデル</param>
        /// <returns></returns>
        public bool UpdatePregerence(PreferenceUpdateModel model)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<PreferenceUpdateModel, TPreference>(); });
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
        public PreferenceUpdateModel GetPreference(long id)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<TPreference, PreferenceUpdateModel>(); });
            Mapper map = new Mapper(config);


            var target = Context.GetPreferences().Where(record => record.Id == id)
                .FirstOrDefault();
            if (target == null)
            {
                return new PreferenceUpdateModel();
            }

            return map.Map<PreferenceUpdateModel>(target);

        }
        #endregion
    }
}
