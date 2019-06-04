using HospitalGestionWPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestionWPF.Models
{
    public class Chambre
    {
        private int id;
        private int etage;
        private int capacite;
        private decimal prix;
        private OuiNonEnum occupe;
        private int idHopital;

        public int Id { get => id; set => id = value; }
        public int Etage { get => etage; set => etage = value; }
        public int Capacite { get => capacite; set => capacite = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public OuiNonEnum Occupe { get => occupe; set => occupe = value; }
        public int IdHopital { get => idHopital; set => idHopital = value; }

        public Chambre()
        {
            etage = 1;
            capacite = new Random().Next(1, 3);
            prix = 30;
            occupe = OuiNonEnum.Non;
        }

        public Chambre(int idHopital) : this()
        {
            this.idHopital = idHopital;
        }
    }
}
