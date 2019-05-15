using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Chirurgie : Traitement
    {
        protected int id_chirurgie;
        protected string chirurgien;
        protected string anesthesiste;
        protected int Id_chirurgie { get => id_chirurgie; set => id_chirurgie = value; }
        protected string Chirurgien { get => chirurgien; set => chirurgien = value; }
        protected string Anesthesiste { get => anesthesiste; set => anesthesiste = value; }
    }
}
