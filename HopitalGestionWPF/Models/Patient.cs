using HospitalGestionWPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestionWPF.Models
{
    public class Patient
    {
        private int id;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private SexeEnum sexe;
        private string adresse;
        private SituationFamillialeEnum situation;
        private string assuranceMedicale;
        private string codeAssurance;
        private string tel;
        private string nomPere;
        private string nomMère;
        private string nomPersonnePrevenir;
        private string telPersAPrevenir;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public SexeEnum Sexe { get => sexe; set => sexe = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public SituationFamillialeEnum Situation { get => situation; set => situation = value; }
        public string AssuranceMedicale { get => assuranceMedicale; set => assuranceMedicale = value; }
        public string CodeAssurance { get => codeAssurance; set => codeAssurance = value; }
        public string Tel { get => tel; set => tel = value; }
        public string NomPere { get => nomPere; set => nomPere = value; }
        public string NomMère { get => nomMère; set => nomMère = value; }
        public string NomPersonnePrevenir { get => nomPersonnePrevenir; set => nomPersonnePrevenir = value; }
        public string TelPersAPrevenir { get => telPersAPrevenir; set => telPersAPrevenir = value; }

        public override string ToString()
        {
            string result = $"{Nom} {Prenom}";
            result += $"Date de naissance : {DateNaissance}";
            result += $"Adresse : {Adresse}";
            result += $"Situation familliale : {Situation}";
            result += $"Assurance Médicale : {AssuranceMedicale}";
            result += $"Code Assurance : {CodeAssurance}";
            result += $"Telephone : {Tel}";
            result += $"Nom du père : {NomPere}";
            result += $"Nom de la mère : {NomMère}";
            result += $"Téléphone de la personne à prevenir : {TelPersAPrevenir}";
            result += $"Nom de la personne à prevenir : {NomPersonnePrevenir}";
            result += $"Sexe : {Sexe}";
            result += $"Id du patient : {Id}";
            return result;
        }
    }
}
