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
        private static object _lock = new object();
        private string nom;
        private int id;

        public string Nom { get => nom; set => nom = value; }
        public int Id { get => id; set => id = value; }

        public Hopital()
        {
        }

        public Hopital(string n)
        {
            Nom = n;
        }

        public void Init(int nChambres)
        {
            
            IDB db = new DBCommand();
            db.AddChambres(nChambres, Id);

        }
    }
}
