// See https://aka.ms/new-console-template for more information

using DocumentFormat.OpenXml.Spreadsheet;
using GenBLayer;
using GenBLayer.DataMpdels;
using GenFront;


string testgenFolder = @"C:\\Users\\Public\\Documents\\Test\\ShortSpng\\TestData";
string outputPath=@"C:\Users\Public\Documents\Test\ShortSpng\TestDataGen";
TestDataGen gen = new TestDataGen();
List<TestDataGenDataModel> models = new List<TestDataGenDataModel>();

DirectoryInfo info=new DirectoryInfo(testgenFolder);
var genfiles = info.GetFiles();

foreach (var file in genfiles)
{
    var model=gen.CreateTestGenDataModel(file.FullName);
    DataGenEngine engine = new DataGenEngine(model);
    var content=engine.TransformText();
    string path = outputPath + "/" + model.ClassName + ".cs";
    File.WriteAllText(path, content);
}




