using System;

enum Henkilo
{
    Matti,
    Maija,
    Pekka,
    Liisa,
    Oona
}

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

        Console.Write("Hae henkilöä: ");
        string syote = Console.ReadLine();

        if (Enum.TryParse<Henkilo>(syote, ignoreCase: true, out var loydetty))
        {
            Console.WriteLine($"Henkilö '{loydetty}' löytyi listasta.");
        }
        else
        {
            Console.WriteLine($"Henkilöä '{syote}' ei löytynyt.");
        }
    }
}