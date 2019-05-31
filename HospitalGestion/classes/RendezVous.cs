using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class RendezVous
    {
        private int id;
        private int code;
        private int idMedecin;
        private DateTime date;
        private ServiceEnum service;
        private int idPatient;
        private OuiNonEnum annule;


        public RendezVous()
        {
            Code = new Random().Next(0, Int32.MaxValue);
        }

        public int Id { get => id; set => id = value; }
        public int Code { get => code; set => code = value; }
        public int IdMedecin { get => idMedecin; set => idMedecin = value; }
        public DateTime Date { get => date; set => date = value; }
        public ServiceEnum Service { get => service; set => service = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public OuiNonEnum Annule { get => annule; set => annule = value; }

        public override string ToString()
        {
            string ts = $"Rendez - vous du {Date}";
            ts += $"\nAvec le docteur {IdMedecin}";
            ts += $"\nDans le service {Service}";
            ts += $"\nCode : {Code}";
            return ts;
        }
    }


}
