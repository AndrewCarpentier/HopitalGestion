using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Chirurgie : Traitement
    {
        private int id;
        private int idChirurgien;
        private int idAnesthesiste;

        public int Id { get => id; set => id = value; }
        public int IdChirurgien { get => idChirurgien; set => idChirurgien = value; }
        public int IdAnesthesiste { get => idAnesthesiste; set => idAnesthesiste = value; }
    }
}
