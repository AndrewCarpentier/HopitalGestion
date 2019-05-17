﻿using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Patient
    {
        private int idPatient;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private SexeEnum sex;
        private string adresse;
        private SituationFamillialeEnum situation;
        private string assuranceMedicale;
        private string codeAssurance;
        private string tel;
        private string nomPere;
        private string nomMère;
        private string nomPersonnePrevenir;
        private string telPersAPrevenir;


        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; set => dateNaissance = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public SituationFamillialeEnum Situation { get => situation; set => situation = value; }
        public string AssuranceMedicale { get => assuranceMedicale; set => assuranceMedicale = value; }
        public string CodeAssurance { get => codeAssurance; set => codeAssurance = value; }
        public string Tel { get => tel; set => tel = value; }
        public string NomPere { get => nomPere; set => nomPere = value; }
        public string NomMère { get => nomMère; set => nomMère = value; }
        public string TelPersAPrevenir { get => telPersAPrevenir; set => telPersAPrevenir = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public SexeEnum Sex { get => sex; set => sex = value; }
        public string NomPersonnePrevenir { get => nomPersonnePrevenir; set => nomPersonnePrevenir = value; }

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
            result += $"Sexe : {Sex}";
            result += $"Id du patient : {IdPatient}";
            return result;
        }
    }
}
