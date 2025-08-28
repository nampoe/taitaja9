using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;

string filePath = "data.yaml";

var deserializer = new DeserializerBuilder()
    .WithNamingConvention(CamelCaseNamingConvention.Instance) 
    .Build();
public class Person
{
    public string Name {  get; set; }
    public string Laji { get; set; }
    public int Tulos { get; set; }
}

