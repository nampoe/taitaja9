using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System;
using System.Collections.Generic;
using System.IO;


public class Program
{
    public static void Main()
    {
        string filePath = "C:\\Users\\jani\\Documents\\GitHub\\taitaja9\\taitaja9\\data.yaml";


        // deserializer ja serializer
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        // deserializer ja serializer




        List<Person> people = new List<Person>();

        if (File.Exists(filePath) && !string.IsNullOrWhiteSpace(File.ReadAllText(filePath)))
        {
            string existingYaml = File.ReadAllText(filePath);
            people = deserializer.Deserialize<List<Person>>(existingYaml) ?? new List<Person>();
        }

        // Console builder for new person
        Console.WriteLine("Enter Name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter Laji:");
        string laji = Console.ReadLine();

        Console.WriteLine("Enter Tulos:");
        int tulos = int.Parse(Console.ReadLine() ?? "0");

        // Create new Person and add to list
        Person newPerson = new Person
        {
            Name = name,
            Laji = laji,
            Tulos = tulos
        };

        people.Add(newPerson);

        // Serialize the list back to YAML
        string newYaml = serializer.Serialize(people);
        File.WriteAllText(filePath, newYaml);

        Console.WriteLine("Person added to data.yaml successfully!");

        System.Threading.Thread.Sleep(5000);


    }
}

public class Person
{
    public string Name { get; set; }
    public string Laji { get; set; }
    public int Tulos { get; set; }
}