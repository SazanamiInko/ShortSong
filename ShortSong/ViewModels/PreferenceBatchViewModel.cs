using FLayer;
using Interfaces.DataModels;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using ShortSong.Data;
using System.IO;

namespace ShortSong.ViewModels
{
    /// <summary>
    /// お気に入り一括登録ビューモデル
    /// </summary>
    public class PreferenceBatchViewModel : ComponentBase
    {

        #region プロパティ

        /// <summary>
        /// 作者
        /// </summary>
        [Parameter]
        public string Author { get; set; } = "";

        /// <summary>
        /// 出典
        /// </summary>
        [Parameter]
        public string? Book { get; set; } = "";

        /// <summary>
        /// 時代
        /// </summary>
        [Parameter]
        public string? Era { get; set; } = "";

        /// <summary>
        /// お気に入り
        /// </summary>
        [Parameter]
        public List<ClientPreferenceDetailDataModel> Preferences { get; set; }

        #endregion


        #region サービス
        /// <summary>
        /// ダイアログ
        /// </summary>
        [Inject]
        public IMatDialogService MatDialogService { get; set; }

        /// <summary>
        /// ナビゲーション
        /// </summary>
        [Inject]
        protected NavigationManager NavManager { get; set; }


        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PreferenceBatchViewModel() 
        { 
            this.Preferences = new List<ClientPreferenceDetailDataModel>();
        }

        #endregion

        #region イベント
       
        /// <summary>
        /// ファイルをアップロード
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task OnFileUpload(IMatFileUploadEntry[] files)
        {
            try
            {
                Preferences.Clear();
                if (files.Count() == 0)
                {
                    return;
                }

                using (var stream = new MemoryStream())
                {
                    await files[0].WriteToStreamAsync(stream);
                   
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var reader = new StreamReader(stream))
                    {
                        var fileContent = await reader.ReadToEndAsync();
                        var preferences = fileContent.Split("\n");
                        foreach (var item in preferences)
                        {
                            this.Preferences.Add(new ClientPreferenceDetailDataModel() { Uta=item});
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {

                if (this.MatDialogService != null)
                {
                    this.MatDialogService.AlertAsync("ファイルアップロードに失敗しました。");
                }
                throw;
            }
        
        }

        /// <summary>
        /// お気に入り一括登録
        /// </summary>
        /// <returns></returns>
        public async Task OnAddPreferenceAsync()
        {
            try
            {
                ClientPreferenceBatchDataModel model= new ClientPreferenceBatchDataModel();
                model.Author = this.Author;
                model.Book = this.Book;
                model.Era = this.Era;

                foreach (var item in Preferences.Where(record => record.Check))
                {
                    model.Items.Add(item);
                }
                FrontAPI.AddBatchPreference(model);
                this.MatDialogService.AlertAsync("お気に入りを一括登録しました。");
            }
            catch
            {
                this.MatDialogService.AlertAsync("お気に入りを一括登録に失敗しました。");
            }
        }
        #endregion

    }
}
