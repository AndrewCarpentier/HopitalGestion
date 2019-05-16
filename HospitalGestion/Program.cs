using HospitalGestion.bdd;
using HospitalGestion.classes;
using HospitalGestion.enums;
using HospitalGestion.Regexs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion
{
    class Program
    {
        private static DBCommand db = new DBCommand();
        private static Patient p = new Patient();
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Quel est le nom de l'hopital ?");
            string nameHospital = Console.ReadLine();
            Hopital h = new Hopital();
            bool success;
            ////if (gethospital(namehospital) != undifined)
            //    h = gethospital(namehospital);
            //else
            //{
            //    success = false;
            //    console.write("entrez le nom de l'hôpital :");
            //    string name = console.readline();
            //    console.write("nombre de chambres de l'hopital 
            //    int n;
            //    do
            //    {
            //        success = int32.tryparse(console.readline(), out n);
            //    } while (!success);
            //    h = new hopital(name, n);
            //}
            MenuPatient();
        }
        static void MenuPatient()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("---------- Bienvenue dans la gestion de l'hopital ------------");
            Console.WriteLine("-------------- Quel est le nom du client ? -------------------");
            string nompatient = Console.ReadLine();
            Console.WriteLine("-------------- Quel est le prenom du client ? ----------------");
            string prenompatient = Console.ReadLine();
            if (db.GetPatientByName(nompatient, prenompatient) != null)
                p = db.GetPatientByName(nompatient, prenompatient);
            else
            {
                AddPatient();
            }
            MenuMedecinSecretaire();
        }
        static void MenuMedecinSecretaire()
        {
            List<Action> medecin = new List<Action>();
            medecin.Add(PrendreRDV);
            medecin.Add(ListeRDV);
            medecin.Add(ListeConsultation);
            medecin.Add(ListeHospitalisation);
            medecin.Add(ListeTraitement);
            medecin.Add(MenuPatient);

            List<Action> secretaire = new List<Action>();
            secretaire.Add(PrendreRDV);
            secretaire.Add(AllerRDV);
            secretaire.Add(SansRDV);
            secretaire.Add(ListeRDV);
            secretaire.Add(ListeFacture);
            secretaire.Add(MenuPatient);


            Console.WriteLine("Entrer le code d'accés :");
            string codeAcces = Console.ReadLine();

            do
            {
                if (!codeAcces.ToLower().Equals("medecin") && !codeAcces.ToLower().Equals("secretaire"))
                {
                    Console.WriteLine("Code d'accès érronée");
                    codeAcces = Console.ReadLine();
                }

                if (codeAcces == "medecin")
                    Menu(medecin, "- Prendre un rendez-vous :",
                        "- Afficher la liste des rendez-vous du patient :",
                        "- Afficher la liste des consultations du patient :",
                        "- Afficher la liste des hospitalisation :",
                        "- Afficher la liste des traitements :",
                        "- Quittez");
                else if (codeAcces == "secretaire")
                    Menu(secretaire, "- Prendre un rendez-vous :",
                        "- Se rendre au rendez-vous :",
                        "- Consultation sans rendez-vous :",
                        "- Afficher la liste des rendez-vous :",
                        "- Afficher la liste des factures :",
                        "- Quittez");

            } while (!codeAcces.ToLower().Equals("medecin") && !codeAcces.ToLower().Equals("secretaire"));

        }

        static void Menu(List<Action> actions, params string[] affichage)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int position = 0;
            int nbMax = affichage.Length - 1;
            Console.Clear();
            int i = 0;
            foreach (string s in affichage)
            {
                if (i == 0)
                    Console.Write(">");
                else
                    Console.Write(" ");

                Console.WriteLine(s);
                i++;
            }

            do
            {
                while (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);

                    switch (cki.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (position != nbMax)
                                position++;
                            break;
                        case ConsoleKey.UpArrow:
                            if (position != 0)
                                position--;
                            break;
                    }

                    Console.Clear();
                    i = 0;

                    foreach (string s in affichage)
                    {
                        if (i == position)
                            Console.Write(">");
                        else
                            Console.Write(" ");
                        Console.WriteLine(s);
                        i++;
                    }
                }
            } while (cki.Key != ConsoleKey.Enter);

            try
            {
                actions[position]();
            }
            catch
            {
                Console.WriteLine("Aucune méthode à cette position");
            }
        }

        static void PrendreRDV()
        {
            Rendez_vous rdv = new Rendez_vous();
            rdv.IdPatient = 1;//patient.IdPatient;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int position = 1;
            int nbMax = 6;
            Console.Clear();
            Console.WriteLine("Nom du service");
            Console.WriteLine(">chirurgie");
            Console.WriteLine(" radiologie");
            Console.WriteLine(" biologie");
            Console.WriteLine(" generaliste");

            do
            {
                while (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    Console.Clear();
                    switch (cki.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (position != nbMax)
                            {
                                position++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (position != 0)
                            {
                                position--;
                            }
                            break;
                    }

                    if (position == 1)
                    {
                        Console.WriteLine("Nom du service");
                        Console.WriteLine(">chirurgie");
                        Console.WriteLine(" radiologie");
                        Console.WriteLine(" biologie");
                        Console.WriteLine(" generaliste");
                    }
                    else if (position == 2)
                    {
                        Console.WriteLine("Nom du service");
                        Console.WriteLine(" chirurgie");
                        Console.WriteLine(">radiologie");
                        Console.WriteLine(" biologie");
                        Console.WriteLine(" generaliste");
                    }
                    else if (position == 3)
                    {
                        Console.WriteLine("Nom du service");
                        Console.WriteLine(" chirurgie");
                        Console.WriteLine(" radiologie");
                        Console.WriteLine(">biologie");
                        Console.WriteLine(" generaliste");
                    }
                    else if (position == 4)
                    {
                        Console.WriteLine("Nom du service");
                        Console.WriteLine(" chirurgie");
                        Console.WriteLine(" radiologie");
                        Console.WriteLine(" biologie");
                        Console.WriteLine(">generaliste");
                    }
                }
            } while (cki.Key != ConsoleKey.Enter);


            if (position == 1)
                rdv.Service = ServiceEnum.chirurgie;
            else if (position == 2)
                rdv.Service = ServiceEnum.radiologie;
            else if (position == 3)
                rdv.Service = ServiceEnum.biologie;
            else if (position == 4)
                rdv.Service = ServiceEnum.generaliste;

            rdv.IdMedecin = db.GetMedecinByService(rdv.Service).Id;

            Console.Write("Pour quel date voulez-vous réservée : ");
            string date = Console.ReadLine();
            string temp = "";
            do
            {
                int d = 0, m = 0, y = 0;
                if (MyRegex.DateNaissanceMatch(date))
                {
                    int b = 0;
                    temp = "";
                    for (int i = 0; i < date.Length; i++)
                    {
                        if (date[i].ToString() == "/")
                        {
                            b++;
                            temp = "";
                        }
                        else
                        {
                            temp += date[i];
                        }

                        if (b == 0)
                        {
                            Int32.TryParse(temp, out d);
                        }
                        else if (b == 1)
                        {
                            Int32.TryParse(temp, out m);
                        }
                        else
                        {
                            Int32.TryParse(temp, out y);
                        }
                    }
                    rdv.Date_RDV = new DateTime(y, m, d);
                    break;
                }
                else
                {
                    Console.WriteLine("Entrez une date de naissance valide : ");
                    date = Console.ReadLine();
                }
            } while (true);

            db.AddRdv(rdv);
        }

        static void SansRDV()
        {
            Console.WriteLine("Sans rdv");
        }
        static void AllerRDV()
        {
            Console.WriteLine("Aller rdv");
        }
        static void ListeRDV()
        {
            List<Rendez_vous> listRDV = new List<Rendez_vous>();
            listRDV = db.GetRendez_VoussByIdPatient(p.IdPatient);
            if(listRDV != null)
            {
                foreach (Rendez_vous r in listRDV)
                    Console.WriteLine(r.ToString()); 
            }
            else
                Console.WriteLine("Aucun rendez-vous pour ce client");
        }

        static void ListeConsultation()
        {
            List<Consultation> listConsultation = new List<Consultation>();
            listConsultation = db.GetConsultationsByIdPatient(p.IdPatient);
            if(listConsultation != null)
            {
                foreach (Consultation c in listConsultation)
                    Console.WriteLine(c.ToString()); 
            }
            else
                Console.WriteLine("Aucune consultation pour ce client");
        }

        static void ListeHospitalisation()
        {
            List<Hospitalisation> listHospitalisation = new List<Hospitalisation>();
            listHospitalisation = db.GetHospitalisationsByIdPatient(p.IdPatient);
            if(listHospitalisation != null)
            {
                foreach (Hospitalisation h in listHospitalisation)
                    h.ToString();
            }
            else
                Console.WriteLine("Aucune hospitalisation pour ce patient");
        }

        static void ListeTraitement()
        {
            List<Traitement> listTraitement = new List<Traitement>();
            listTraitement = db.GetTraitementsByIdPatient(p.IdPatient);
            if(listTraitement != null)
            {
                foreach (Traitement t in listTraitement)
                    t.ToString();
            }
            else
                Console.WriteLine("Aucun traitement pour ce patient");
        }

        static void ListeFacture()
        {
            List<Facture> listFacture = new List<Facture>();
            listFacture = db.GetFacturesByIdPatient(p.IdPatient);
            if(listFacture != null)
            {
                foreach (Facture f in listFacture)
                    f.ToString();
            }
            else
                Console.WriteLine("Aucune facture pour ce patient");
        }

        static void AddPatient()
        {
            Console.Clear();
            Console.Write("Quel est votre nom et prénom ? : ");
            string nomPrenom = Console.ReadLine();
            string temp = "";
            bool nomB = true;
            for (int i = 0; i < nomPrenom.Length ; i++)
            {
                if (nomPrenom[i].ToString() == " ")
                {
                    nomB = false;
                    temp = "";
                }

                temp += nomPrenom[i];

                if (nomB)
                {
                    p.Nom = temp;
                }
                else
                {
                    p.Prenom = temp;
                }
            }
            Console.Clear();
            Console.Write("Quel est votre date de naissance ? : ");
            string date = Console.ReadLine();
            do
            {
                int d = 0, m = 0, y = 0;
                if (MyRegex.DateNaissanceMatch(date))
                {
                    int b = 0;
                    temp = "";
                    for (int i = 0; i < date.Length; i++)
                    {
                        if (date[i].ToString() == "/")
                        {
                            b++;
                            temp = "";
                        }
                        else
                        {
                            temp += date[i];
                        }

                        if (b == 0)
                        {
                            Int32.TryParse(temp, out d);
                        }
                        else if(b == 1)
                        {
                            Int32.TryParse(temp, out m);
                        }
                        else
                        {
                            Int32.TryParse(temp, out y);
                        }
                    }
                    p.DateNaissance = new DateTime(y,m,d);
                    break;
                }
                else
                {
                    Console.WriteLine("Entrez une date de naissance valide : ");
                    date = Console.ReadLine();
                }
            } while (true);

            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int position = 0;
            int nbMax = 2;
            Console.Clear();
            Console.WriteLine("Etes vous un homme ou une femme");
            Console.WriteLine(">Homme");
            Console.WriteLine(" Femme");

            do
            {
                while (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    Console.Clear();
                    switch (cki.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (position != nbMax)
                            {
                                Console.WriteLine("Etes vous un homme ou une femme");
                                Console.WriteLine(" Homme");
                                Console.WriteLine(">Femme");
                                position++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (position != 0)
                            {
                                Console.WriteLine("Etes vous un homme ou une femme");
                                Console.WriteLine(">Homme");
                                Console.WriteLine(" Femme");
                                position--;
                            }
                            break;
                    }
                }
            } while (cki.Key != ConsoleKey.Enter);

            p.Sex = (SexeEnum)position;

            Console.WriteLine("Quel est votre adresse ? : ");
            p.Adresse = Console.ReadLine();

            cki = new ConsoleKeyInfo();
            position = 1;
            nbMax = 6;
            Console.Clear();
            Console.WriteLine("Quel est votre situation familliale ? : ");
            Console.WriteLine(">Marié");
            Console.WriteLine(" Pacsé");
            Console.WriteLine(" Divorcé");
            Console.WriteLine(" Séparé");
            Console.WriteLine(" Célibataire");
            Console.WriteLine(" Veuf");

            do
            {
                while (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    Console.Clear();
                    switch (cki.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (position != nbMax)
                            {
                                
                                position++;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (position != 0)
                            {
                                position--;
                            }
                            break;
                    }

                    if(position == 1)
                    {
                        Console.WriteLine("Quel est votre situation familliale ? : ");
                        Console.WriteLine(">Marié");
                        Console.WriteLine(" Pacsé");
                        Console.WriteLine(" Divorcé");
                        Console.WriteLine(" Séparé");
                        Console.WriteLine(" Célibataire");
                        Console.WriteLine(" Veuf");
                    }
                    else if(position == 2)
                    {
                        Console.WriteLine("Quel est votre situation familliale ? : ");
                        Console.WriteLine(" Marié");
                        Console.WriteLine(">Pacsé");
                        Console.WriteLine(" Divorcé");
                        Console.WriteLine(" Séparé");
                        Console.WriteLine(" Célibataire");
                        Console.WriteLine(" Veuf");
                    }
                    else if (position == 3)
                    {
                        Console.WriteLine("Quel est votre situation familliale ? : ");
                        Console.WriteLine(" Marié");
                        Console.WriteLine(" Pacsé");
                        Console.WriteLine(">Divorcé");
                        Console.WriteLine(" Séparé");
                        Console.WriteLine(" Célibataire");
                        Console.WriteLine(" Veuf");
                    }
                    else if (position == 4)
                    {
                        Console.WriteLine("Quel est votre situation familliale ? : ");
                        Console.WriteLine(" Marié");
                        Console.WriteLine(" Pacsé");
                        Console.WriteLine(" Divorcé");
                        Console.WriteLine(">Séparé");
                        Console.WriteLine(" Célibataire");
                        Console.WriteLine(" Veuf");
                    }
                    else if (position == 5)
                    {
                        Console.WriteLine("Quel est votre situation familliale ? : ");
                        Console.WriteLine(" Marié");
                        Console.WriteLine(" Pacsé");
                        Console.WriteLine(" Divorcé");
                        Console.WriteLine(" Séparé");
                        Console.WriteLine(">Célibataire");
                        Console.WriteLine(" Veuf");
                    }
                    else if (position == 6)
                    {
                        Console.WriteLine("Quel est votre situation familliale ? : ");
                        Console.WriteLine(" Marié");
                        Console.WriteLine(" Pacsé");
                        Console.WriteLine(" Divorcé");
                        Console.WriteLine(" Séparé");
                        Console.WriteLine(" Célibataire");
                        Console.WriteLine(">Veuf");
                    }

                }
            } while (cki.Key != ConsoleKey.Enter);

            if (position == 1)
                p.Situation = SituationFamillialeEnum.marié;
            else if (position == 2)
                p.Situation = SituationFamillialeEnum.pacsé;
            else if (position == 3)
                p.Situation = SituationFamillialeEnum.divorcé;
            else if (position == 4)
                p.Situation = SituationFamillialeEnum.séparé;
            else if (position == 5)
                p.Situation = SituationFamillialeEnum.célibataire;
            else if (position == 6)
                p.Situation = SituationFamillialeEnum.veuf;

            Console.Write("Votre assurance médical ? : ");
            p.AssuranceMedicale = Console.ReadLine();

            Console.Write("Votre code d'assurance ? : ");
            p.CodeAssurance = Console.ReadLine();

            Console.Write("Votre numéro de téléphone ? : ");
            string phone = Console.ReadLine();
            do
            {
                if (MyRegex.PhoneMatch(phone))
                {
                    p.Tel = phone;
                    break;
                }
                else
                {
                    Console.Write("Entrez un numéro de téléphone correct : ");
                    phone = Console.ReadLine();
                }
            } while (true);

            Console.WriteLine("Le nom de votre père ? : ");
            p.NomPere = Console.ReadLine();

            Console.WriteLine("Le nom de votre mère ? : ");
            p.NomMère = Console.ReadLine();

            Console.WriteLine("Le nom de la personne à prévenir ? : ");
            p.NomPersonnePrevenir = Console.ReadLine();

            Console.Write("Le numéro de téléphone de la personne à prévenir ? : ");
            string phonePrev = Console.ReadLine();
            do
            {
                if (MyRegex.PhoneMatch(phone))
                {
                    p.TelPersAPrevenir = phonePrev;
                    break;
                }
                else
                {
                    Console.Write("Entrez un numéro de téléphone correct : ");
                    phonePrev = Console.ReadLine();
                }
            } while (true);

            db.AddPatient(p);
        }
    }
}
