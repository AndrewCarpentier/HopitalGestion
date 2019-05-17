using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Examens_Radiologiques : Traitement
    {
        private int id_examen;
        private int designation;
        private string resultat_examen;

        public int Id_examen { get => id_examen; set => id_examen = value; }
        public int Designation { get => designation; set => designation = value; }
        public string Resultat_examen { get => resultat_examen; set => resultat_examen = value; }

        public Examens_Radiologiques()
        {
            Designation = new Random().Next(0, Int32.MaxValue);
        }
    }
}
