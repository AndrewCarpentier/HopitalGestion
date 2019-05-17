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
        private OuiNonEnum occupe;
        private decimal[] Tprix = new decimal[] { 50.6m, 60.5m };

        public int Id { get => id; set => id = value; }
        public int Etage { get => etage; set => etage = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public OuiNonEnum Occupe { get => occupe; set => occupe = value; }

        public Chambre()
        {
        }

        public Chambre(int occ)
        {
            if (occ < 4) Prix = Tprix[0];
            else Prix = Tprix[1];
        }
    }
}
