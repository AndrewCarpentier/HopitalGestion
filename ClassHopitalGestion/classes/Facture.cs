using ClassHopitalGestion.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHopitalGestion.classes
{
    public class Facture
    {
        private int id;
        private DateTime date;
        private decimal prix;
        private int idPatient;
        private OuiNonEnum payee;

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Prix { get => prix; set => prix = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public OuiNonEnum Payee { get => payee; set => payee = value; }

        public override string ToString()
        {
            string result = $"Id de la facture : {IdPatient}";
            result += $"Date de la facture : {Date}";
            result += $"Prix : {Prix} €";
            return base.ToString();
        }
    }
}
