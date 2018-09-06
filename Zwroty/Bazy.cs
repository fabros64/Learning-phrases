using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zwroty
{
    public class Bazy
    {
        List<Poszczegolna_Baza> bazy;

        public Bazy()
        {
            bazy = new List<Poszczegolna_Baza>();
        }

        public void Dodaj_Baze(Poszczegolna_Baza baza)
        {
            bazy.Add(baza);
        }
            
    }
}
