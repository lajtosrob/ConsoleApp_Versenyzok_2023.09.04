using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Versenyzok
{
    internal class Pilotak
    {
        string nev;
        string szuletesDatuma;
        string nemzetiseg;
        string rajtszam;

        public Pilotak(string nev, string szuletesDatuma, string nemzetiseg, string rajtszam)
        {
            this.nev = nev;
            this.szuletesDatuma = szuletesDatuma;
            this.nemzetiseg = nemzetiseg;
            this.rajtszam = rajtszam;
        }

        public string Nev { get => nev; set => nev = value; }
        public string SzuletesDatuma { get => szuletesDatuma; set => szuletesDatuma = value; }
        public string Nemzetiseg { get => nemzetiseg; set => nemzetiseg = value; }
        public string Rajtszam { get => rajtszam; set => rajtszam = value; }
    }
}
