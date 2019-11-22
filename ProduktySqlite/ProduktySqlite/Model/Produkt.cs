using System;
using System.Collections.Generic;
using System.Text;

namespace ProduktySqlite.Model
{
    public class Produkt
    {
        public long ProduktId { get; set; }
        public string Nazev { get; set; }
        public float Cena { get; set; }

        public Produkt(long produktId, string nazev, float cena)
        {
            ProduktId = produktId;
            Nazev = nazev;
            Cena = cena;
        }
    }
}
