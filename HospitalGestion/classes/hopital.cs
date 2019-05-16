using HospitalGestion.bdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Hopital
    {
        private static Hopital _instance = null;
        private static object _lock = new object();
        private string nom;

        public string Nom { get => nom; set => nom = value; }
        public Hopital(string n)
        {
            Nom = n;
            init();
        }

        private void init()
        {
            
        }
    }
}
