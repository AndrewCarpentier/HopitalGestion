using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HopitalGestionWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalGestionWPF.ViewModels
{
    public class PageConnexionViewModel: ViewModelBase
    {
        private ConnectionService service = new ConnectionService();

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged();
            }
        }
        private string message;
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
                RaisePropertyChanged();
            }
        }

        public ICommand validerCommand { get; set; }

        public PageConnexionViewModel()
        {
            validerCommand = new RelayCommand(validCommand);
        }

        public void validCommand()
        {
            bool b = true;
            if(password != null)
                b = service.valider(password);

            if (!b)
                Message = "Mauvais mot de passe";
            else
            {
                Message = "";
                Password = "";
            }
        }

    }
}
