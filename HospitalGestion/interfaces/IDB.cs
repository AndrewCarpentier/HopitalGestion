﻿using HospitalGestion.classes;
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
        void AddConsultation(Consultation consultation);
        void AddPrescription(Prescription prescription);
        void AnnuleRendezVous(int id);
        int AjouterTraitement(Traitement traitement);
        Patient GetPatientByName(string name, string surname);
        void AddPatient(Patient patient);
        Medecin GetMedecinByService(ServiceEnum service);
        void AddRdv(Rendez_vous rdv);
        void AddHospitalisation(Hospitalisation hospitalisation);
        void AddBiologie(Examens_Biologiques biologiques);
        void AddRadiologue(Examens_Radiologiques radiologiques);
        void AddChirurgie(Chirurgie chirurgie);
    }
}
