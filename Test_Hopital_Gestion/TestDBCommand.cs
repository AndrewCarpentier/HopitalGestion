using HospitalGestion.bdd;
using HospitalGestion.classes;
using HospitalGestion.enums;
using HospitalGestion.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Hopital_Gestion
{
    [TestClass]
    public class TestDBCommand
    {
        public DBCommand db = new DBCommand();
        public int idPatient = 5;

        [TestMethod]
        public void GetConsultationByIdPatient_DBCommand_ListConsultation()
        {
            List<Consultation> c = db.GetConsultationsByIdPatient(idPatient);
            Assert.IsTrue(c.Count >= 0);
        }   

        [TestMethod]
        public void GetConsultationByIdPatient_DBCommand_NotNull()
        {
            List<Consultation> c = db.GetConsultationsByIdPatient(idPatient);
            Assert.IsNotNull(c);
        }

        [TestMethod]

        public void GetRendez_VousByIdPatient_DBCommand_ListRendezVous()
        {
            List<Rendez_vous> c = db.GetRendez_VoussByIdPatient(idPatient);
            Assert.IsTrue(c.Count >= 0);
                
        }

        [TestMethod]
        public void GetRendez_VousByIdPatient_DBCommand_NotNull()
        {
            List<Rendez_vous> c = db.GetRendez_VoussByIdPatient(idPatient);
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void GetTraitementsByIdPatient_DbCommand_ListTraitement()
        {
            List<Traitement> c = db.GetTraitementsByIdPatient(idPatient);
            Assert.IsTrue(c.Count >= 0);
        }

        [TestMethod]
        public void GetTraitementsByIdPatient_DbCommand_NotNull()
        {
            List<Traitement> c = db.GetTraitementsByIdPatient(idPatient);
            Assert.IsNotNull(c);
        }

        [TestMethod]
        public void AddConsultation_DBCommand_Bool()
        {
            Consultation c = new Consultation()
            {
                Date = new DateTime(633896886277130000),  
                Synthese = "Synthese",
                TypeConsult = "TypeConsult",
                Prix = 100,
                IdPatient = idPatient
            };
            Assert.IsTrue(db.AddConsultation(c));
        }

        [TestMethod]
        public void AddChirurgie_DBCommand_Bool()
        {
            Chirurgie c = new Chirurgie()
            {
                Chirurgien = 1,
                Anesthesiste = 1,
                Id_traitement = 1
            };
            Assert.IsTrue(db.AddChirurgie(c));
        }

        [TestMethod]
        public void AddPatient_DBCommand_Bool()
        {
            Patient p = new Patient()
            {
                Nom = "Yanbuaban",
                Prenom = "Remi",
                DateNaissance = new DateTime(633896886277130000),
                Sex = SexeEnum.homme,
                Adresse = "RBX",
                Situation = SituationFamillialeEnum.célibataire,
                AssuranceMedicale = "1249",
                CodeAssurance = "2245",
                Tel = "0646455223",
                NomPere = "Papa",
                NomMère = "mama",
                NomPersonnePrevenir = "michel",
                TelPersAPrevenir = "0656565656"
            };
            Assert.IsTrue(db.AddPatient(p));
        }

        [TestMethod]
        public void GetPatients_DBCommand_ListPatient()
        {
            List<Patient> p = db.GetPatients();
            Assert.IsTrue(p.Count >= 0);
        }
        [TestMethod]
        public void GetPatients_DBCommand_NotNull()
        {
            List<Patient> p = db.GetPatients();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void GetFactures_DBCommand_ListFactures()
        {
            List<Facture> f = db.GetFactures();
            Assert.IsTrue(f.Count >= 0);
        }
        
        public void GetFactures_DBCommand_NotNull()
        {
            List<Facture> f = db.GetFactures();
            Assert.IsNotNull(f);
        }

    }
}
