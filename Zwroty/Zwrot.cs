using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zwroty
{
    class Zwrot
    {
        string PL, ENG;

        public Zwrot(string PL, string ENG)
        {
            this.PL = PL;
            this.ENG = ENG;
        }

        public string konkatenacja()
        {
            return PL + " - " + ENG;
        }
    }
}
