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
        private int idPatient;

        public int IdConsultation { get => idConsultation; set => idConsultation = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Synthese { get => synthese; set => synthese = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }

        public override string ToString()
        {
            string ts = $"Consultation n°{IdConsultation}";
            ts = $"\nDate : {Date}";
            ts = $"\nSynthese de la consultation :{Synthese}";
            return base.ToString();
        }
    }
}
