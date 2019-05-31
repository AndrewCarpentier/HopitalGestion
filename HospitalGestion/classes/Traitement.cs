using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Traitement
    {
        private int idTraitement;
        private DateTime date;
        private decimal prix;
        private int idPatient;
        private int idMedecin;

        public int IdTraitement { get => idTraitement; set => idTraitement = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public int IdMedecin { get => idMedecin; set => idMedecin = value; }

        public override string ToString()
        {
            string result = $"Id du traitement : {IdTraitement}";
            result += $"Date du traitement : {Date}";
            result += $"Prix du traitement : {Prix}";
            return base.ToString();
        }
    }

    
}
