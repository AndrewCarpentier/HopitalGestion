using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestionWPF.Models
{
    public class ExamensBiologiques : Traitement
    {
        private int idExamenBiologiques;
        private int designation;
        private string resultat;

        public int IdExamenBiologiques { get => idExamenBiologiques; set => idExamenBiologiques = value; }
        public int Designation { get => designation; set => designation = value; }
        public string Resultat { get => resultat; set => resultat = value; }

        public ExamensBiologiques()
        {
            Designation = new Random().Next(0, Int32.MaxValue);
        }
    }
}
