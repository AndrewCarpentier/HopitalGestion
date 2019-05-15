using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Examens_Biologiques : Traitement
    {
        protected int id_examen;
        protected int designation;
        protected int resultat_examen;

        protected int Id_examen { get => id_examen; set => id_examen = value; }
        protected int Designation { get => designation; set => designation = value; }
        protected int Resultat_examen { get => resultat_examen; set => resultat_examen = value; }
    }
}
