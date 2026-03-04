namespace Bingo_PanczelCsenge
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<BingoJatekos> jatekosok = new List<BingoJatekos>();

            string[] nevek = File.ReadAllLines("nevek.text");

            for (int i = 0; i < nevek.Length && i < 100; i++)
            {
                string fajlNev = nevek[i];

                if (File.Exists(fajlNev))
                {
                    string nev = fajlNev.Replace(".txt", "");
                    BingoJatekos uj = new BingoJatekos(nev, fajlNev);
                    jatekosok.Add(uj);
                }
            }

            Console.WriteLine("4. feladat");
            Console.WriteLine($"Játékosok száma: {jatekosok.Count}");
            Console.WriteLine();

            Console.WriteLine("7. feladat");

            Random rnd = new Random();
            List<int> huzott = new List<int>();

            bool vanBingo = false;
            int sorszam = 1;

            while (!vanBingo)
            {
                int szam;

                do
                {
                    szam = rnd.Next(1, 76);
                }
                while (huzott.Contains(szam));

                huzott.Add(szam);

                Console.WriteLine($"{sorszam,3}. húzás: {szam}");
                sorszam++;

                foreach (var j in jatekosok)
                    j.SorsoltSzamotJelol(szam);

                vanBingo = false;
                for (int i = 0; i < jatekosok.Count; i++)
                {
                    if (jatekosok[i].BingoEll())
                    {
                        vanBingo = true;
                        break;
                    }
                }
            }

            Console.WriteLine();

            Console.WriteLine("8. feladat");

            foreach (var j in jatekosok)
            {
                if (j.BingoEll())
                {
                    j.KartyaKiir();
                }
            }
        }
    }
}
