using HospitalGestionWPF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestionWPF.Models
{
    public abstract class Specialite : Service
    {
        public int idSpecialite;
        public SpecialiteEnum specialite;
    }
}
