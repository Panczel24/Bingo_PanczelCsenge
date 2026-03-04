using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_PanczelCsenge
{
    internal class BingoJatekos
    {
        public string Nev { get; set; }
        public int[,] Kartya { get; set; } 
        public bool[,] Jelolve { get; set; }

        public BingoJatekos(string nev, string fajlNev)
        {
            Nev = nev;

            Kartya = new int[5, 5];
            Jelolve = new bool[5, 5];

            string[] sorok = File.ReadAllLines(fajlNev);

            for (int i = 0; i < 5; i++)
            {
                string[] adatok = sorok[i].Split(';');
                for (int j = 0; j < 5; j++)
                {
                    if (adatok[j] == "X")
                    {
                        Kartya[i, j] = -111;
                        Jelolve[i, j] = true;
                    }
                    else
                    {
                        Kartya[i, j] = int.Parse(adatok[j]);
                    }
                }
            }
        }

       
    }
}
