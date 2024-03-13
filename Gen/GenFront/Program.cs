// See https://aka.ms/new-console-template for more information

using GenBLayer;
using GenBLayer.DataMpdels;
using GenFront;


string testgenFolder = @"C:\\Users\\Public\\Documents\\Test\\ShortSpng\\TestData";
TestDataGen gen = new TestDataGen();
List<TestDataGenDataModel> models = new List<TestDataGenDataModel>();

DirectoryInfo info=new DirectoryInfo(testgenFolder);
var genfiles = info.GetFiles();

foreach (var file in genfiles)
{
    var model=gen.CreateTestGenDataModel(file.FullName);
    DataGenEngine engine = new DataGenEngine(model);
    engine.TransformText();
}




