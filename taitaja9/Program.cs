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

            Console.Write("Anna pisteet");                  //kysytään käyttäjältä pisteet suodatusta varten
            string pisteetSyote = Console.ReadLine();
            int pisteet;
            while (!int.TryParse(pisteetSyote, out pisteet))        // tämä varmistaa että syöte on numero, jos se ei ole niin se kysyy uudelleen.
            {
                Console.Write("Virheellinen syöte. Anna pisteet numerona: ");
                pisteetSyote = Console.ReadLine();
            }

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear(); // Päivittää koko konsolin taustavärin

            Console.WriteLine($"Nimi: {nimi}, Laji: {laji}, Pisteet: {pisteet}");   //konsoli tulostaa nimen, lajin ja pisteet ruudulle.   Sitten ohjelma siirtää tiedot yamliin
        }
    }
}