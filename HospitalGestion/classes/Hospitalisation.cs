using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    class Hospitalisation
    {
        private int idHopitalisation;
        private DateTime dateAdmission;
        private string typeAdmission;
        private string motifAdmission;
        private string medecinTraitant;
        private string nomAccompagnant;
        private string preNomAccompagnant;
        private LienParenteEnum lienParente;
        private DateTime dateEntreeAcc;
        private DateTime dateSortieAcc;
        private DateTime dateSortie;
        private string motifSortie;
        private string resultatSortie;
        private DateTime dateDeces;
        private string motifDeces;

        public int IdHopitalisation { get => idHopitalisation; set => idHopitalisation = value; }
        public DateTime DateAdmission { get => dateAdmission; set => dateAdmission = value; }
        public string TypeAdmission { get => typeAdmission; set => typeAdmission = value; }
        public string MotifAdmission { get => motifAdmission; set => motifAdmission = value; }
        public string MedecinTraitant { get => medecinTraitant; set => medecinTraitant = value; }
        public string NomAccompagnant { get => nomAccompagnant; set => nomAccompagnant = value; }
        public string PreNomAccompagnant { get => preNomAccompagnant; set => preNomAccompagnant = value; }
        public LienParenteEnum LienParente { get => lienParente; set => lienParente = value; }
        public DateTime DateEntreeAcc { get => dateEntreeAcc; set => dateEntreeAcc = value; }
        public DateTime DateSortieAcc { get => dateSortieAcc; set => dateSortieAcc = value; }
        public DateTime DateSortie { get => dateSortie; set => dateSortie = value; }
        public string MotifSortie { get => motifSortie; set => motifSortie = value; }
        public string ResultatSortie { get => resultatSortie; set => resultatSortie = value; }
        public DateTime DateDeces { get => dateDeces; set => dateDeces = value; }
        public string MotifDeces { get => motifDeces; set => motifDeces = value; }
    }

}
