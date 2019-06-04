using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public abstract class TypeConsultation
    {
        private string typeConsultation;
        private decimal prix;

        public string TypeConsult { get => typeConsultation; set => typeConsultation = value; }
        public decimal Prix { get => prix; set => prix = value; }
    }
}
