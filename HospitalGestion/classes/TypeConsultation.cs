using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public abstract class TypeConsultation
    {
        private int idTypeConsultation;
        private string typeConsultation;
        private decimal prix;

        protected int IdTypeConsultation { get => idTypeConsultation; set => idTypeConsultation = value; }
        protected string TypeConsultation { get => typeConsultation; set => typeConsultation = value; }
        protected decimal Prix { get => prix; set => prix = value; }
    }
}
