using InterfaceMaker.DataModel;

namespace InterfaceMaker
{
    /// <summary>
    /// 出力フォルダユーティリティ
    /// </summary>
    public  static  class PathUtil
    {
        /// <summary>
        /// 出力フォルダ初期化
        /// </summary>
        /// <param name="path">パス</param>
        private static void InitilizeOutput(string path)
        {
            if (Directory.Exists(path))
            {
                DirectoryInfo iOutInfo = new DirectoryInfo(path);
                iOutInfo.Delete(true);
            }
            Directory.CreateDirectory(path);

        }

        /// <summary>
        /// 出力パスの初期化
        /// </summary>
        /// <param name="path"></param>
        public static void InitilizeOutputs(string path,List<InheritedT4DataModel> T4Infos)
        {
            InitilizeOutput(GetInterfacePath(path));
           
            foreach(var info in T4Infos)
            {
               string targetPath= Path.Combine(path,info.Name );
               InitilizeOutput(targetPath);
            }

        }

        /// <summary>
        /// インタフェース側の出力パスを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetInterfacePath(string path)
        {
            return Path.Combine(path, "Interface");
        }

        /// <summary>
        /// 派生クラス出力先
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetInheritedPath(string path,string name)
        {
            return Path.Combine(path,name);
        }



        /// <summary>
        /// クライアント側の出力パスを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetClientPath(string path)
        {
            return  Path.Combine(path, "Client");
        }

        /// <summary>
        /// サーバー側の出力パスを返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetServerPath(string path)
        {
            return Path.Combine(path, "Server");
        }
    }
}
