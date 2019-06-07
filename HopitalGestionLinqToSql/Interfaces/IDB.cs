using HopitalGestionLinqToSql;
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
        bool AddRdv(Rdv rdv);
        void AddHospitalisation(Hospitalisation hospitalisation);
        bool AddBiologie(ExamenBiologique biologiques);
        bool AddRadiologue(ExamenRadiologique radiologiques);
        bool AddChirurgie(Chirurgie chirurgie);
        int AddTraitement(Traitement traitement);

        Patient GetPatientByName(string name, string surname);
        Medecin GetMedecinByService(ServiceEnum service);
        Hopital GetHopital(string name);

        List<Rdv> GetRdvsByIdPatient(int idPatient);
        List<Consultation> GetConsultationsByIdPatient(int idPatient);
        List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient);
        List<Traitement> GetTraitementsByIdPatient(int idPatient);
        List<Facture> GetFacturesByIdPatient(int idPatient);
        List<Patient> GetPatients();
        List<Facture> GetFactures();
    }
}
