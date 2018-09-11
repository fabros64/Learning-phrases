using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zwroty
{
    public class Zwrot
    {
        string PL, ENG;

        public Zwrot(string PL, string ENG)
        {
            this.PL = PL;
            this.ENG = ENG;
        }

        public Zwrot()
        {

        }

        public string konkatenacja()
        {
            return PL + " - " + ENG;
        }

        public string getPL()
        {
            return PL;
        }

        public string getENG()
        {
            return ENG;
        }

        public void setPL(string PL)
        {
            this.PL = PL;
        }

        public void setENG(string ENG)
        {
            this.ENG = ENG;
        }

    }
}
