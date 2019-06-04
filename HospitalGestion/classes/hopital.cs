using HospitalGestion.bdd;
using HospitalGestion.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Hopital
    {
        private int id;
        private string nom;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public Hopital()
        {
        }

        public Hopital(string n)
        {
            Nom = n;
        }
    }
}
