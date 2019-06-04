using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HospitalGestion.bdd;
using HospitalGestionWPF.Enums;
using HospitalGestionWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalGestionWPF.ViewModels
{
    public class NouveauPatientViewModel : ViewModelBase
    {
        public Patient nouveauPatient { get; set; }

        public string Nom {
            get => nouveauPatient.Nom;
            set {
                nouveauPatient.Nom = value;
                RaisePropertyChanged(); } }
        public string Prenom {
            get => nouveauPatient.Prenom;
            set { nouveauPatient.Prenom = value;
                RaisePropertyChanged();
            } }
        public DateTime DateNaissance { get => nouveauPatient.DateNaissance; set{
                nouveauPatient.DateNaissance = value;
                RaisePropertyChanged(); }}
        public SexeEnum Sexe { get => nouveauPatient.Sexe; set {
                nouveauPatient.Sexe = value;
                RaisePropertyChanged(); }}

        public string Adresse { get => nouveauPatient.Adresse; set {
                nouveauPatient.Adresse = value;
                RaisePropertyChanged();}}
        public SituationFamillialeEnum Situation { get => nouveauPatient.Situation; set {
                nouveauPatient.Situation = value;
                RaisePropertyChanged();}}
        public string AssuranceMedicale { get => nouveauPatient.AssuranceMedicale; set {
                nouveauPatient.AssuranceMedicale = value;
                RaisePropertyChanged();
            }
        }
        public string CodeAssurance { get => nouveauPatient.CodeAssurance; set {
                nouveauPatient.CodeAssurance = value;
                RaisePropertyChanged();
            }
        }
        public string Tel { get => nouveauPatient.Tel; set {
                nouveauPatient.Tel = value;
                RaisePropertyChanged();
            }
        }
        public string NomPere { get => nouveauPatient.NomPere; set
            {
                nouveauPatient.NomPere = value;
                RaisePropertyChanged();
            }
            }
        public string NomMère { get => nouveauPatient.NomMère; set
            {
                nouveauPatient.NomMère = value;
                RaisePropertyChanged();
            }
            }
        public string NomPersonnePrevenir { get => nouveauPatient.NomPersonnePrevenir; set
            {
                nouveauPatient.NomPersonnePrevenir = value;
                RaisePropertyChanged();
            }
        }
        public string TelPersAPrevenir { get => nouveauPatient.TelPersAPrevenir; set
            {
                nouveauPatient.TelPersAPrevenir = value;
                RaisePropertyChanged();
            }
        }

        public ICommand addCommand { get; set; }

        public void AddPatient()
        {
            DBCommand db = new DBCommand();
            db.AddPatient(nouveauPatient);
        }

        public NouveauPatientViewModel()
        {
            nouveauPatient = new Patient();
            addCommand = new RelayCommand(AddPatient);
        }
    }
}
