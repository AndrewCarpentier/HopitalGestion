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
        bool AddMedecin(Medecin medecin);
        bool AddHopital(Hopital hopital);
        void AddChambres(Chambre chambre);
        bool AddPrescription(Prescription prescription);
        bool AnnuleRdv(int idRdv);
        bool AddConsultation(Consultation consultation);
        bool AddPatient(Patient patient);
        bool AddRdv(RendezVous rdv);
        void AddHospitalisation(Hospitalisation hospitalisation);
        bool AddBiologie(ExamensBiologiques biologiques);
        bool AddRadiologue(ExamensRadiologiques radiologiques);
        bool AddChirurgie(Chirurgie chirurgie);
        int AddTraitement(Traitement traitement);

        Patient GetPatientByName(string name, string surname);
        Medecin GetMedecinByService(ServiceEnum service);
        Hopital GetHopital(string name);

        List<RendezVous> GetRdvsByIdPatient(int idPatient);
        List<Consultation> GetConsultationsByIdPatient(int idPatient);
        List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient);
        List<Traitement> GetTraitementsByIdPatient(int idPatient);
        List<Facture> GetFacturesByIdPatient(int idPatient);
        List<Patient> GetPatients();
        List<Facture> GetFactures();
    }
}
