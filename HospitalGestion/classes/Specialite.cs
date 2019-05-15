using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public abstract class Specialite : Service
    {
        protected int idSpecialite;
        protected SpecialiteEnum specialite;
    }
}
