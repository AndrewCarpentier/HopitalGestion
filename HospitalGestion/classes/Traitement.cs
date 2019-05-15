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
        private int date_traitement;
        private int prix_traitement;

        public int Id_traitement { get => id_traitement; set => id_traitement = value; }
        public int Date_traitement { get => date_traitement; set => date_traitement = value; }
        public int Prix_traitement { get => prix_traitement; set => prix_traitement = value; }
    }

    
}
