using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Traitement
    {
        private int id_traitement;
        private DateTime date_traitement;
        private decimal prix_traitement;
        private int idPatient;

        public int Id_traitement { get => id_traitement; set => id_traitement = value; }
        public DateTime Date_traitement { get => date_traitement; set => date_traitement = value; }
        public decimal Prix_traitement { get => prix_traitement; set => prix_traitement = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
    }

    
}
