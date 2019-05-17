using HospitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion.classes
{
    public class Facture
    {
        private int id_facture;
        private DateTime date_facture;
        private decimal prix;
        private int idPatient;
        private OuiNonEnum payee;

        public int Id_facture { get => id_facture; set => id_facture = value; }
        public DateTime Date_facture { get => date_facture; set => date_facture = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public OuiNonEnum Payee { get => payee; set => payee = value; }


        public override string ToString()
        {
            string result = $"Id de la facture : {IdPatient}";
            result += $"Date de la facture : {Date_facture}";
            result += $"Prix : {Prix} €";
            return base.ToString();
        }
    }
}
