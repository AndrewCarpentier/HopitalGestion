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
        private int codeRDV;
        private string medecin;
        private DateTime date_RDV;
        private ServiceEnum service;

        public int CodeRDV { get => codeRDV; set => codeRDV = value; }
        public string Medecin { get => medecin; set => medecin = value; }
        public DateTime Date_RDV { get => date_RDV; set => date_RDV = value; }
        public ServiceEnum Service { get => service; set => service = value; }
    }


}
