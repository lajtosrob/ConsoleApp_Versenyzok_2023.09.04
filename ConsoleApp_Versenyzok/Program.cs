// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using balkezesek;
using ConsoleApp_Versenyzok;
using System.Linq;
// See https://aka.ms/new-console-template for more information

namespace balkezesek;
class Program
{

    static List<Pilotak> PilotakList = new List<Pilotak>();

    static void Main(string[] args)

    {
        //2. pilotak.csv sorainak beolvasása 

        StreamReader sr = new StreamReader("DATAS/Pilotak.csv");

        string headerLine = sr.ReadLine();

        while(!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(';');

            Pilotak pilotakData = new Pilotak(
                line[0],
                line[1],
                line[2],
                line[3]
                );

            PilotakList.Add( pilotakData );
        }

        sr.Close();

        // 3. 

        Console.WriteLine($"3. feladat: {PilotakList.Count()}");

        // 4. 

        Console.WriteLine($"4. feladat: {PilotakList.Last().Nev}");

        // 5. 

        Console.WriteLine("5. feladat: ");

        PilotakList
            .Where(x => DateTime.Parse(x.SzuletesDatuma).Year < 1901)
            .ToList()
            .ForEach(x => Console.WriteLine($"\t{x.Nev} ({x.SzuletesDatuma})"));

        // 6. 

        Console.Write("6. feladat: ");

        var legkisebbRajtszam =  PilotakList
            .Where(x => !string.IsNullOrEmpty(x.Rajtszam))
            .OrderBy(x => int.Parse(x.Rajtszam))
            .ToList()
            .First();

        Console.WriteLine(legkisebbRajtszam.Nemzetiseg);

        // 7.

        Console.Write("7. feladat:");

        PilotakList
            .Where(x => !string.IsNullOrEmpty(x.Rajtszam))
            .GroupBy(x => x.Rajtszam)
            .Where(x => x.Count() > 1)
            .Select(x => x.Key)
            .ToList()
            .ForEach(x => Console.Write($" {x}"));
    }
}