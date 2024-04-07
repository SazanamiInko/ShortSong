// See https://aka.ms/new-console-template for more information


using InterfaceMaker;
using InterfaceMaker.DataModel;
using InterfaceMaker.T4;
using System.Text.Json;

string workFolder = string.Empty;
string outputFolder = string.Empty;
string interfaceOutputFolder = string.Empty;
string clientOutputFolder = string.Empty;
string serverOutputFolder = string.Empty;

//設定ファイルの読み込み
using (var fs=File.OpenRead("./setting.json"))
{
    using (var sr = new StreamReader(fs))
    {
        if(sr==null)
        {
            throw new Exception("設定ファイルが開けません");
        }

        var setting = JsonSerializer.Deserialize<SettingDataModel>(sr.ReadLine());

        if (setting == null)
        {
            throw new Exception("設定ファイルが開けません");
        }

        workFolder = setting.WorkFolder;
        outputFolder = setting.OutputFolder;

    }
}

if(string.IsNullOrEmpty(workFolder))
{
    throw new Exception("作業フォルダが設定されてません");
}

if(string.IsNullOrEmpty(outputFolder))
{
    throw new Exception("出力フォルダが設定されてません");
}

if(!Directory.Exists(workFolder))
{
    throw new Exception("作業フォルダがありません");
}

interfaceOutputFolder = Path.Combine(outputFolder, "Interface");
if (!Directory.Exists(interfaceOutputFolder))
{
    throw new Exception("インタフェースの出力フォルダがありません");
}

clientOutputFolder = Path.Combine(outputFolder, "Client");
if (!Directory.Exists(clientOutputFolder))
{
    throw new Exception("クライアントの出力フォルダがありません");
}

serverOutputFolder = Path.Combine(outputFolder, "Server");
if (!Directory.Exists(serverOutputFolder))
{
    throw new Exception("サーバーの出力フォルダがありません");
}


//作業フォルダからファイル一覧を取得する
DirectoryInfo dirInfo = new DirectoryInfo(workFolder);
var defines=dirInfo.GetFiles("*.xlsx");
foreach (var define in defines)
{
    //T4エンジンの内容を取得
    var material = DataFeeder.CreateMaterial(define.FullName);
    Console.Out.WriteLine(material.ClassName);
    //T4エンジンの初期化
    InterfaceMakerT4 imaker = new InterfaceMakerT4();
    imaker.MaterialDataModel = material;

    ClientDataModelMakerT4 cmaker = new ClientDataModelMakerT4();
    cmaker.MaterialDataModel = material;

    ServerDataModelMakerT4 smaker = new ServerDataModelMakerT4();
    smaker.MaterialDataModel = material;

    //ソース生成
    var source = imaker.TransformText();
    //CSファイルに保存する
    string outputInterFace = Path.Combine(interfaceOutputFolder, "I" + material.ClassName + ".cs");
    File.WriteAllText(outputInterFace, source);

    source = cmaker.TransformText();
    string outputClient = Path.Combine(clientOutputFolder, "Client" + material.ClassName + ".cs");
    File.WriteAllText(outputClient, source);

    source = smaker.TransformText();
    string outputServer = Path.Combine(serverOutputFolder, "Server" + material.ClassName + ".cs");
    File.WriteAllText(outputServer, source);



}





