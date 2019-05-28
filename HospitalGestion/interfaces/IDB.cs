using HospitalGestion.classes;
using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.interfaces
{
    public interface IDB 
    {
        bool AddHopital(string name);
        Hopital GetHopital(string name);
        void AddChambres(int n, int id);
        List<Rendez_vous> GetRendez_VoussByIdPatient(int idPatient);
        List<Consultation> GetConsultationsByIdPatient(int idPatient);
        List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient);
        List<Traitement> GetTraitementsByIdPatient(int idPatient);
        List<Facture> GetFacturesByIdPatient(int idPatient);
        bool AddConsultation(Consultation consultation);
        void AddPrescription(Prescription prescription);
        void AnnuleRendezVous(int id);
        int AjouterTraitement(Traitement traitement);
        Patient GetPatientByName(string name, string surname);
        bool AddPatient(Patient patient);
        Medecin GetMedecinByService(ServiceEnum service);
        void AddRdv(Rendez_vous rdv);
        void AddHospitalisation(Hospitalisation hospitalisation);
        void AddBiologie(Examens_Biologiques biologiques);
        void AddRadiologue(Examens_Radiologiques radiologiques);
        bool AddChirurgie(Chirurgie chirurgie);
        List<Patient> GetPatients();

        List<Facture> GetFactures();

        void AddMedecin(Medecin medecin);
    }
}
