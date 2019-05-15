using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Chambre
    {
        private int id;
        private int etage;
        private int capacite;
        private decimal prix;
        private OccupeEnum occupe;

        public int Id { get => id; set => id = value; }
        public int Etage { get => etage; set => etage = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public OccupeEnum Occupe { get => occupe; set => occupe = value; }
    }
}
