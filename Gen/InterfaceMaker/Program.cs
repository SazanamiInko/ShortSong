// See https://aka.ms/new-console-template for more information


using InterfaceMaker;
using InterfaceMaker.DataModel;
using System.Text.Json;

string workFolder = string.Empty;
string outputFolder = string.Empty;

try
{ 
Console.Out.WriteLine( "データモデルのソースを自動作成します");

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
Console.Out.WriteLine("設定ファイルを読み込みました");
Console.Out.WriteLine("環境チェック");
if (string.IsNullOrEmpty(workFolder))
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
Console.Out.WriteLine("環境チェック終了");


//作業フォルダからファイル一覧を取得する
DirectoryInfo dirInfo = new DirectoryInfo(workFolder);
var defines=dirInfo.GetFiles("*.xlsx");

Console.Out.WriteLine("以下のファイルのソースを自動作成します");
foreach (var define in defines)
{
    Console.Out.WriteLine(define.Name);
}
Console.Out.WriteLine("");
//出力の準備をする
PathUtil.InitilizeOutputs(outputFolder);

foreach (var define in defines)
{
    //T4エンジンの内容を取得
    var material = DataFeeder.CreateMaterial(define.FullName);
    Console.Out.WriteLine(material.Comment+"処理中");

    T4PlayerManager manager = new T4PlayerManager(material, outputFolder);

    foreach(var player in manager.Players)
    {
        Console.Out.WriteLine(player.GetFileName());
        player.Play();
    }   

}
}
catch(Exception ex)
{
    Console.Out.WriteLine(ex.Message);
    Console.Out.WriteLine("自動作成に失敗しました");
}




