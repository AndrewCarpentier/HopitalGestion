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
        private OuiNonEnum annule;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public int IdMedecin { get => idMedecin; set => idMedecin = value; }
        public DateTime Date_RDV { get => date_RDV; set => date_RDV = value; }
        public ServiceEnum Service { get => service; set => service = value; }
        public int Id { get => id; set => id = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public OuiNonEnum Annule { get => annule; set => annule = value; }

        public Rendez_vous()
        {
            CodeRDV = new Random().Next(0, Int32.MaxValue);
        }
    }


}
