using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Chirurgie : Traitement
    {
        private int id_chirurgie;
        private string chirurgien;
        private string anesthesiste;
        public int Id_chirurgie { get => id_chirurgie; set => id_chirurgie = value; }
        public string Chirurgien { get => chirurgien; set => chirurgien = value; }
        public string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }
    }
}
