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

        StreamReader sr = new StreamReader("DATAS/pilotak.csv");

        string headerLine = sr.ReadLine();

        while(!sr.EndOfStream)
        {
            string[] line = sr.ReadLine().Split(';');

            Pilotak PilotakData = new Pilotak(
                line[0],
                line[1],
                line[2],
                line[3]
                );

            PilotakList.Add( PilotakData ); 

        }

        sr.Close();

        // 3. 

        Console.WriteLine($"3. feladat: {PilotakList.Count()}");

        // 4. 

        Console.WriteLine($"4. feladat: {PilotakList.Last().Nev}");

        // 5. 

        Console.WriteLine("5. feladat:");

        List<Pilotak> PilotakXIX = PilotakList.Where(x => isPilotakXIX(x.SzuletesDatuma)).ToList();

        foreach (Pilotak pilota in PilotakXIX)
        {
            Console.WriteLine($"\t{pilota.Nev} ({pilota.SzuletesDatuma})");
        }

        static bool isPilotakXIX(string szuletesiDatum)
        {
            if (DateTime.TryParse(szuletesiDatum, out DateTime datum) )
            {
                return datum.Year < 1901;
            }
            return false;
        }

        // 6. 

        Console.Write("6. feladat: ");

        Pilotak legkisebbRajtszamu = PilotakList
            .Where(p => !string.IsNullOrEmpty(p.Rajtszam)) // A rajtszámmal nem rendelkező pilótákat nem vesszük figyelembe.
            .OrderBy(p =>int.Parse(p.Rajtszam)) // Rendezés növekvő sorrendbe rajtszám alapján
            .FirstOrDefault();  // Az első pilóta kiválasztása a listában. 

        Console.Write(legkisebbRajtszamu.Nemzetiseg);
        Console.WriteLine();

        // 7.

        Console.Write("7. feladat:");

        var tobbRajtszam = PilotakList
            .Where(p => !string.IsNullOrEmpty (p.Rajtszam))
            .GroupBy(x => x.Rajtszam)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        tobbRajtszam.ForEach(x => Console.Write($" {x}"));

    }
}