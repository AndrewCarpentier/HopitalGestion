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
            Assert.IsTrue(p.IdPatient > 0);
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
            Medecin m = db.GetMedecinByService(ServiceEnum.chirurgie);
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
        public void AnnuleRendezVous_DBCommand_Bool()
        {
            int rdvId = 1019;
            Assert.IsTrue(db.AnnuleRendezVous(rdvId));
        }

        [TestMethod]
        public void AddRdv_DBCommand_Bool()
        {
            Rendez_vous rdv = new Rendez_vous()
            {
                IdMedecin = idMedecin,
                Date_RDV = new DateTime(633896886277130000),
                Service = ServiceEnum.chirurgie,
                IdPatient = idPatient
            };
            Assert.IsTrue(db.AddRdv(rdv));
        }

        [TestMethod]
        public void AjouterTraitement_DBCommand_Int()
        {
            Traitement t = new Traitement()
            {
                Date_traitement = new DateTime(633896886277130000),
                Prix_traitement = 100,
                IdPatient = idPatient,
                IdMedecin = idMedecin
            };
            int id = db.AjouterTraitement(t);
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
                specialite = SpecialiteEnum.generaliste,
                nomService = ServiceEnum.generaliste
            };
            Assert.IsTrue(db.AddMedecin(m));
        }

        [TestMethod]
        public void AddBiologie_DBCommand_Bool()
        {
            Examens_Biologiques eb = new Examens_Biologiques()
            {
                Resultat_examen = "resultat test",
                Id_traitement = idTraitement,
                IdMedecin = idMedecin
            };
            Assert.IsTrue(db.AddBiologie(eb));
        }

        [TestMethod]
        public void AddRadiologue_DBCommand_Bool()
        {
            Examens_Radiologiques er = new Examens_Radiologiques()
            {
                Resultat_examen = "resultat test",
                Id_traitement = idTraitement,
                IdMedecin = idMedecin
            };
            Assert.IsTrue(db.AddRadiologue(er));
        }
    }
}
