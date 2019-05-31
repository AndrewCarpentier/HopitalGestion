using HospitalGestion.bdd;
using HospitalGestion.classes;
using HospitalGestion.enums;
using HospitalGestion.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Test_Hopital_Gestion
{
    [TestClass]
    public class TestDBCommand
    {
        private IDB db = new DBCommand();
        private int idPatient = 4, idMedecin = 1, idTraitement = 1;
        private string patientLastname = "carpentier", patientFirstname = "andrew";

        [TestMethod]
        public void GetFacturesByIdPatient_DBCommand_List()
        {
            List<Facture> fs = db.GetFacturesByIdPatient(idPatient);
            Assert.IsTrue(fs.Count >= 0);
        }

        [TestMethod]
        public void GetFacturesByIdPatient_DBCommand_NotNull()
        {
            List<Facture> fs = db.GetFacturesByIdPatient(idPatient);
            Assert.IsNotNull(fs);
        }

        [TestMethod]
        public void GetHospitalisationsByIdPatient_DBCommand_List()
        {
            List<Hospitalisation> hs = db.GetHospitalisationsByIdPatient(idPatient);
            Assert.IsTrue(hs.Count >= 0);
        }

        [TestMethod]
        public void GetHospitalisationsByIdPatient_DBCommand_NotNull()
        {
            List<Hospitalisation> hs = db.GetHospitalisationsByIdPatient(idPatient);
            Assert.IsNotNull(hs);
        }

        [TestMethod]
        public void GetPatientByName_DBCommand_Patient()
        {
            Patient p = db.GetPatientByName(patientLastname, patientFirstname);
            Assert.IsTrue(p.Id > 0);
        }

        [TestMethod]
        public void GetPatientByName_DBCommand_Default()
        {
            Patient p = db.GetPatientByName(default(string), default(string));
            Assert.IsNull(p);
        }

        [TestMethod]
        public void GetMedecinByService_DBCommand_Medecin()
        {
            Medecin m = db.GetMedecinByService(ServiceEnum.Chirurgie);
            Assert.IsTrue(m.Id > 0);
        }

        [TestMethod]
        public void AddPrescription_DBCommand_Bool()
        {
            Prescription p = new Prescription()
            {
                IdPatient = idPatient,
                Date = new DateTime(633896886277130000),
                Note = "Ceci est une note"
            };
            Assert.IsTrue(db.AddPrescription(p));
        }

        [TestMethod]
        public void AnnuleRdv_DBCommand_Bool()
        {
            int rdvId = 6019;
            Assert.IsTrue(db.AnnuleRdv(rdvId));
        }

        [TestMethod]
        public void AddRdv_DBCommand_Bool()
        {
            RendezVous rdv = new RendezVous()
            {
                IdMedecin = idMedecin,
                Date = new DateTime(633896886277130000),
                Service = ServiceEnum.Chirurgie,
                IdPatient = idPatient
            };
            Assert.IsTrue(db.AddRdv(rdv));
        }

        [TestMethod]
        public void AddTraitement_DBCommand_Int()
        {
            Traitement t = new Traitement()
            {
                Date = new DateTime(633896886277130000),
                Prix = 100,
                IdPatient = idPatient,
                IdMedecin = idMedecin
            };
            int id = db.AddTraitement(t);
            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void AddMedecin_DBCommand_Bool()
        {
            Medecin m = new Medecin()
            {
                Nom = "test",
                Prenom = "test",
                Tel = "0636477245",
                specialite = SpecialiteEnum.Generaliste,
                service = ServiceEnum.Generaliste
            };
            Assert.IsTrue(db.AddMedecin(m));
        }

        [TestMethod]
        public void AddBiologie_DBCommand_Bool()
        {
            ExamensBiologiques eb = new ExamensBiologiques()
            {
                Resultat = "resultat test",
                IdTraitement = idTraitement,
                IdMedecin = idMedecin
            };
            Assert.IsTrue(db.AddBiologie(eb));
        }

        [TestMethod]
        public void AddRadiologue_DBCommand_Bool()
        {
            ExamensRadiologiques er = new ExamensRadiologiques()
            {
                Resultat = "resultat test",
                IdTraitement = idTraitement,
                IdMedecin = idMedecin
            };
            Assert.IsTrue(db.AddRadiologue(er));
        }
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

        public void GetRdvsByIdPatient_DBCommand_ListRendezVous()
        {
            List<RendezVous> c = db.GetRdvsByIdPatient(idPatient);
            Assert.IsTrue(c.Count >= 0);
                
        }

        [TestMethod]
        public void GetRdvsByIdPatient_DBCommand_NotNull()
        {
            List<RendezVous> c = db.GetRdvsByIdPatient(idPatient);
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
                IdChirurgien = 1,
                IdAnesthesiste = 1,
                IdTraitement = 1
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
                Sexe = SexeEnum.Homme,
                Adresse = "RBX",
                Situation = SituationFamillialeEnum.Célibataire,
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
        
        [TestMethod]
        public void GetFactures_DBCommand_NotNull()
        {
            List<Facture> f = db.GetFactures();
            Assert.IsNotNull(f);
        }

    }
}
