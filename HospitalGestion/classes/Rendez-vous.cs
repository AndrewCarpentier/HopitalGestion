using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Rendez_vous
    {
        private int id;
        private int codeRDV;
        private int idMedecin;
        private DateTime date_RDV;
        private ServiceEnum service;
        private int idPatient;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public int IdMedecin { get => idMedecin; set => idMedecin = value; }
        public DateTime Date_RDV { get => date_RDV; set => date_RDV = value; }
        public ServiceEnum Service { get => service; set => service = value; }
        public int Id { get => id; set => id = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }

        public Rendez_vous()
        {
            CodeRDV = new Random().Next(0, Int32.MaxValue);
        }

        public override string ToString()
        {
            string ts = $"Rendez - vous du {Date_RDV}";
            ts = $"\nAvec le docteur {IdMedecin}";
            ts = $"\nDans le service {Service}";
            ts = $"\nCode : {CodeRDV}";
            return ts;
        }
    }


}
