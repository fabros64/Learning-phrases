﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zwroty
{
    public class Poszczegolna_Baza
    {
        string nazwa;
        List <Zwrot> zwroty;
        Zwrot zwrot;
        
        public Poszczegolna_Baza(string nazwa)
        {
            this.nazwa = nazwa;
            zwroty = new List<Zwrot>();
        }

        public Poszczegolna_Baza()
        {
            zwroty = new List<Zwrot>();
        }

        public string getNazwa()
        {
            return nazwa;
        }

        public void Dodaj_Zwrot(string PL, string ENG)
        {
            zwrot = new Zwrot(PL, ENG);
            zwroty.Add(zwrot);
        }

        public void Dodaj_Zwrot(Zwrot zwrot)
        {
            zwroty.Add(zwrot);
        }

        public List<Zwrot> getZwroty()
        {
            return zwroty;
        }

        public void setNazwa(string nazwa)
        {
            this.nazwa = nazwa;
        }

    }
}
