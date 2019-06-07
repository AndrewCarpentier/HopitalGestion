using HospitalGestionWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopitalGestionWPF.Service
{
    public class ConnectionService
    {
        public bool valider(string  password)
        {
            bool b = true;
            ConnexionPatientWindow mP;
            switch (password)
            {
                case "administration":
                    MenuAdministrationWindow mA = new MenuAdministrationWindow();
                    mA.Show();
                    break;
                case "generaliste":
                    mP = new ConnexionPatientWindow();
                    mP.Show();
                    break;
                case "secretaire":
                    mP = new ConnexionPatientWindow();
                    mP.Show();
                    break;
                case "specialiste":
                    mP = new ConnexionPatientWindow();
                    mP.Show();
                    break;
                default:
                    b = false;
                    break;
            }

            return b;
        }
    }
}
