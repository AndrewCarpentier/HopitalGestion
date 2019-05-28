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
        bool AddPrescription(Prescription prescription);
        bool AnnuleRendezVous(int id);
        bool AddConsultation(Consultation consultation);
        int AjouterTraitement(Traitement traitement);
        Patient GetPatientByName(string name, string surname);
        bool AddPatient(Patient patient);
        Medecin GetMedecinByService(ServiceEnum service);
        bool AddRdv(Rendez_vous rdv);
        void AddHospitalisation(Hospitalisation hospitalisation);
        bool AddBiologie(Examens_Biologiques biologiques);
        bool AddRadiologue(Examens_Radiologiques radiologiques);
        bool AddChirurgie(Chirurgie chirurgie);
        List<Patient> GetPatients();

        List<Facture> GetFactures();

        bool AddMedecin(Medecin medecin);
    }
}
