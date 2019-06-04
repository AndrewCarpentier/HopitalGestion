using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestionWPF.Models
{
    public class Prescription
    {
        private int id;
        private DateTime date;
        private int idPatient;
        private string note;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Note { get => note; set => note = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
    }
}
