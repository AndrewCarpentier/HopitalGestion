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
        private int chirurgien;
        private int anesthesiste;

        public int Id_chirurgie { get => id_chirurgie; set => id_chirurgie = value; }
        public int Chirurgien { get => chirurgien; set => chirurgien = value; }
        public int Anesthesiste { get => anesthesiste; set => anesthesiste = value; }
    }
}
