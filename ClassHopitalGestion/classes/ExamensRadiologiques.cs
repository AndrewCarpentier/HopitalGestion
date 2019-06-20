using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHopitalGestion.classes
{
    public class ExamensRadiologiques : Traitement
    {
        private int idExamenRadiologique;
        private int designation;
        private string resultat;


        public ExamensRadiologiques()
        {
            Designation = new Random().Next(0, Int32.MaxValue);
        }

        public int IdExamenRadiologique { get => idExamenRadiologique; set => idExamenRadiologique = value; }
        public int Designation { get => designation; set => designation = value; }
        public string Resultat { get => resultat; set => resultat = value; }
    }
}
