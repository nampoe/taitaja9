using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(@"
__        __   _                                
\ \      / /__| | ___ ___  _ __ ___   ___
 \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \
  \ V  V /  __/ | (_| (_) | | | | | |  __/
   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|
");
        Console.WriteLine("Paina mitä vaan näppäintä aloittaaksesi...");
        Console.ReadKey(true);
        Console.WriteLine("Aloitettu");
        var nimet = LueNimetYamlista("henkilot.yaml");

        Console.Write("Hae henkilöä: ");
        string syote = Console.ReadLine();

        if (nimet.Contains(syote, StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Henkilö '{syote}' löytyi listasta.");
        }
        else
        {
            Console.WriteLine($"Henkilöä '{syote}' ei löytynyt.");
        }
    }

    static List<string> LueNimetYamlista(string polku)
    {
        if (!File.Exists(polku))
        {
            Console.WriteLine($"Tiedostoa '{polku}' ei löytynyt.");
            return new List<string>();
        }

        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        using var reader = new StreamReader(polku);
        var yamlObj = deserializer.Deserialize<Dictionary<string, List<string>>>(reader);
        return yamlObj.TryGetValue("names", out var nimet) ? nimet : new List<string>();
    }
}