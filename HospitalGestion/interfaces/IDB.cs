﻿using HospitalGestion.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.interfaces
{
    public interface IDB 
    {   
        void CrerChambres(int n);
        List<Rendez_vous> GetRendez_VoussByIdPatient(int idPatient);
        List<Consultation> GetConsultationsByIdPatient(int idPatient);
        List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient);
    }
}
