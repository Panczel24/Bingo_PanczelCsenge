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

        public void SorsoltSzamotJelol(int szam)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (Kartya[i, j] == szam)
                        Jelolve[i, j] = true;
        }

        public bool BingoEll()
        {
            for (int i = 0; i < 5; i++)
            {
                bool bingo = true;

                for (int j = 0; j < 5; j++)
                {
                    if (!Jelolve[i, j])
                    {
                        bingo = false;
                        break;
                    }
                }

                if (bingo)
                    return true;
            }

            for (int j = 0; j < 5; j++)
            {
                bool bingo = true;

                for (int i = 0; i < 5; i++)
                {
                    if (!Jelolve[i, j])
                    {
                        bingo = false;
                        break;
                    }
                }

                if (bingo)
                    return true;
            }

            bool atlo1 = true;
            for (int i = 0; i < 5; i++)
            {
                if (!Jelolve[i, i])
                {
                    atlo1 = false;
                    break;
                }
            }

            if (atlo1)
                return true;

            bool atlo2 = true;
            for (int i = 0; i < 5; i++)
            {
                if (!Jelolve[i, 4 - i])
                {
                    atlo2 = false;
                    break;
                }
            }

            if (atlo2)
                return true;

            return false;
        }

        public void KartyaKiir()
        {
            Console.WriteLine(Nev);
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (Jelolve[i, j])
                    {
                        if (Kartya[i, j] == null)
                            Console.Write(" X".PadLeft(4));
                        else
                            Console.Write(Kartya[i, j].ToString().PadLeft(4));
                    }
                    else
                    {
                        Console.Write(" 0".PadLeft(4));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
