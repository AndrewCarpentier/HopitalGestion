using HospitalGestion.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalGestion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quel est le nom de l'hopital ?");
            string nameHospital = Console.ReadLine();
            Hopital h = new Hopital();
            bool success;
            if (GetHospital(nameHospital) != undifined)
                h = GetHospital(nameHospital);
            else
            {
                success = false;
                Console.Write("entrez le nom de l'hôpital :");
                string name = Console.ReadLine();
                Console.Write("Nombre de chambres de l'hopital :");
                int n;
                do
                {
                    success = Int32.TryParse(Console.ReadLine(), out n);
                } while (!success);
                h = new Hopital(name, n);
            }
        }
        static void MenuPatient()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("---------- Bienvenue dans la gestion de l'hopital ------------");
            Console.WriteLine("-------------- Quel est le nom du client ? -------------------");
            string nomclient = Console.ReadLine();
            Patient p = new Patient();
            p = GetPatientFromServer(nomclient);
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
        static Patient GetPatientFromServer(string nomClient)
        {
            Patient p = new Patient();
            return p;
        }

        static void PrendreRDV()
        {
            Console.WriteLine("Prendre rdv");
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
            Console.WriteLine("liste rdv");
        }

        static void ListeConsultation()
        {
            Console.WriteLine("liste consult");
        }

        static void ListeHospitalisation()
        {
            Console.WriteLine("Liste Hospitalisation");
        }

        static void ListeTraitement()
        {
            Console.WriteLine("Liste traitement");
        }

        static void ListeFacture()
        {
            Console.WriteLine("Liste facture");
        }



    }
}
