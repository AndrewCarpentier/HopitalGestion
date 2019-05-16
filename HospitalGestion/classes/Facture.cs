﻿using System;
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

        public int Id_facture { get => id_facture; set => id_facture = value; }
        public DateTime Date_facture { get => date_facture; set => date_facture = value; }
        public int IdPatient { get => idPatient; set => idPatient = value; }
        public decimal Prix { get => prix; set => prix = value; }
    }
}
