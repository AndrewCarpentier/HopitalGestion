using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Consultation : TypeConsultation
    {
        private int idConsultation;
        private DateTime date;
        private string synthese;

        public int IdConsultation { get => idConsultation; set => idConsultation = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Synthese { get => synthese; set => synthese = value; }
    }
}
