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
        void AddChambres(int n);
        List<Rendez_vous> GetRendez_VoussByIdPatient(int idPatient);
        List<Consultation> GetConsultationsByIdPatient(int idPatient);
        List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient);
        List<Traitement> GetTraitementsByIdPatient(int idPatient);
        List<Facture> GetFacturesByIdPatient(int idPatient);
        Patient GetPatientByName(string name);
        void AddPatient(Patient patient);
        Medecin GetMedecinByService(ServiceEnum service);
        void AddRdv(Rendez_vous rdv);
        void AddHospitalisation(Hospitalisation hospitalisation);
    }
}
