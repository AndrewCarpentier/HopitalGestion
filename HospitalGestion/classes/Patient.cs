using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    class Patient
    {
        private string idPatient;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private SexeEnum sex;
        private int adresse;
        private string situation;
        private string assuranceMedicale;
        private string codeAssurance;
        private string tel;
        private string nomPere;
        private string nomMère;
        private string telPersAprevenir;


        public string Nom { get => nom; set => nom = value; }
        public string Prenom1 { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public int Adresse { get => adresse; set => adresse = value; }
        public string Situation { get => situation; set => situation = value; }
        public string AssuranceMedicale { get => assuranceMedicale; set => assuranceMedicale = value; }
        public string CodeAssurance { get => codeAssurance; set => codeAssurance = value; }
        public string Tel { get => tel; set => tel = value; }
        public string NomPere { get => nomPere; set => nomPere = value; }
        public string NomMère { get => nomMère; set => nomMère = value; }
        public string TelPersAprevenir { get => telPersAprevenir; set => telPersAprevenir = value; }
        public string IdPatient { get => idPatient; set => idPatient = value; }
        public SexeEnum Sex { get => sex; set => sex = value; }
    }

    public enum SexeEnum
    {
        homme,
        femme
    }
}
