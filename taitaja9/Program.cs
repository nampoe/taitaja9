using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;



public class Program
{
    public static void Main()
    {

        Console.BackgroundColor = ConsoleColor.DarkBlue;

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


        while (true)
        {

            Console.WriteLine("Mitä haluat tehdä?\n1 - Lisätä henkilön\n2 - Etsiä henkilön\n3 - Listata henkilöt");
            int.TryParse(Console.ReadLine(), out int act);

            switch (act)
            {
                case 1:

                    Console.WriteLine("\nAnna etu- ja sukunimi");
                    string name = Console.ReadLine();

                    Console.WriteLine("\nAnna laji");
                    string laji = Console.ReadLine();

                    Console.WriteLine("\nAnna pisteet");
                    double tulos = double.Parse(Console.ReadLine() ?? "0");

                    // Create new Person and add to list
                    Person newPerson = new Person
                    {
                        Name = name,
                        Laji = laji,
                        Tulos = tulos
                    };

                    people.Add(newPerson);

                    string newYaml = serializer.Serialize(people);
                    File.WriteAllText(filePath, newYaml);

                    Console.WriteLine("\nHenkilö lisätty.\n");

                    break;


                Console.Write("Anna nimi haettavaksi: ");
                string haku = Console.ReadLine().ToLower();
                var loydetyt = people.FindAll(t => t.Laji.ToLower().Contains(haku)).OrderBy(t => t.Name); 
                if (loydetyt.Count() > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n{0,-20} {1,-15} {2,-10}", "Nimi", "Laji", "Tulos");
                    Console.WriteLine(new string('-', 50));
                    Console.ResetColor();
                    foreach (var t in loydetyt)
                    {
                        Console.WriteLine("{0,-20} {1,-15} {2,-10}", t.Name, t.Laji, t.Tulos);
                    }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ei tuloksia annetulla nimellä.");
                        Console.ResetColor();
                    }
                    break;

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ei tuloksia annetulla nimellä.");
                        Console.ResetColor();
                    }

                    break;


                case 3:

                    Console.WriteLine();

                    int nameWidth = Math.Max(4, people.Count > 0 ? people.Max(p => p.Name.Length) : 4);
                    int lajiWidth = Math.Max(4, people.Count > 0 ? people.Max(p => p.Laji.Length) : 4);
                    int tulosWidth = Math.Max(5, people.Count > 0 ? people.Max(p => p.Tulos.ToString().Length) : 5);


                    Console.WriteLine($"{"Nimi".PadRight(nameWidth)}  {"Laji".PadRight(lajiWidth)}  {"Tulos".PadRight(tulosWidth)}");


                    Console.WriteLine(new string('-', nameWidth + lajiWidth + tulosWidth + 4));


                    foreach (var p in people)
                    {
                        Console.WriteLine($"{p.Name.PadRight(nameWidth)}  {p.Laji.PadRight(lajiWidth)}  {p.Tulos.ToString().PadRight(tulosWidth)}");
                    }
                    Console.WriteLine("\n\n");


                    break;

                default:
                    break;
            }


            System.Threading.Thread.Sleep(1000);


        }
    }



}


public class Person
{
    public string Name { get; set; }
    public string Laji { get; set; }
    public double Tulos { get; set; }
}

