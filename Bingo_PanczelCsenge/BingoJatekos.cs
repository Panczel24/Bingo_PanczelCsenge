using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo_PanczelCsenge
{
    internal class BingoJatekos
    {
        private string nev;
        private int[,] kartya;
        private bool[,] jeolt;

        public BingoJatekos(string nev, int[,] kartya, bool[,] jeolt)
        {
            this.nev = nev;
            this.kartya = kartya;
            this.jeolt = jeolt;
        }

        public string Nev { get => nev; set => nev = value; }
        public int[,] Kartya { get => kartya; set => kartya = value; }
        public bool[,] Jeolt { get => jeolt; set => jeolt = value; }
    }
}
