using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Prescription
    {
        private int id;
        private DateTime date;
        private string nomPatient;
        private string prenomPatient;
        private string note;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string NomPatient { get => nomPatient; set => nomPatient = value; }
        public string PrenomPatient { get => prenomPatient; set => prenomPatient = value; }
        public string Note { get => note; set => note = value; }
    }
}
