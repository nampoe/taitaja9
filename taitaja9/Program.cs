using System;

namespace taitaja9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Anna etu- ja sukunimi");         // kysytään käyttäjältä etu- ja sukunimi hakua ja suodatusta varten
            string nimi = Console.ReadLine();

            Console.Write("Anna laji");                     //kysytään käyttäjältä laji hakemista ja suodatusta varten
            string laji = Console.ReadLine();

            Console.Write("Anna pisteet");                     //kysytään käyttäjältä pisteet suodatusta varten
            string pisteetSyote = Console.ReadLine();
            int pisteet = int.Parse(pisteetSyote);

            Console.WriteLine($"Nimi: {nimi}, Laji: {laji}, Pisteet: {pisteet}");   //konsoli tulostaa nimen, lajin ja pisteet ruudulle.   Sitten ohjelma siirtää tiedot yamliin




        }
    }
}