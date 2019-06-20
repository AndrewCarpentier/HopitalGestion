using ClassHopitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHopitalGestion.classes
{
    public abstract class Specialite : Service
    {
        public int idSpecialite;
        public SpecialiteEnum specialite;
    }
}
