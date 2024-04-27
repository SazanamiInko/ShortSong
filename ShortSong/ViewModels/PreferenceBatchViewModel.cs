using MatBlazor;
using Microsoft.AspNetCore.Components;
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
        public string Author { get; set; } = null!;

        /// <summary>
        /// 出典
        /// </summary>
        [Parameter]
        public string? Book { get; set; }

        /// <summary>
        /// 時代
        /// </summary>
        [Parameter]
        public string? Era { get; set; }


        

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

                        fileContent.Split("\r\n");
                    }

                    
                }
            }
            catch (Exception ex)
            {

                if (this.MatDialogService != null)
                {
                    this.MatDialogService.AlertAsync("ファイルアップロードに失敗しました。。");
                }
                throw;
            }
        
        }

        #endregion

    }
}
