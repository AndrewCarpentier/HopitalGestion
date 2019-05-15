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
            Console.WriteLine("---------- Bienvenue dans la gestion de l'hopital ------------");
            Console.WriteLine("Entrer le nom du client :");
            string nomClient = Console.ReadLine();
            Patient p = new Patient();
            p = GetPatientFromServer(nomClient);
            MenuMedecinSecretaire();
            Console.ReadLine();
        }

        static void MenuMedecinSecretaire()
        {
            List<Action> medecin = new List<Action>();
            medecin.Add(PrendreRDV);
            medecin.Add(ListeRDV);
            medecin.Add(ListeConsultation);
            medecin.Add(ListeHospitalisation);
            medecin.Add(ListeTraitement);

            List<Action> secretaire = new List<Action>();
            secretaire.Add(PrendreRDV);
            secretaire.Add(SansRDV);
            secretaire.Add(AllerRDV);
            secretaire.Add(ListeRDV);
            secretaire.Add(ListeFacture);


            Console.WriteLine("Entrer le code d'accés :");
            string codeAcces = Console.ReadLine();

            do
            {
                if(!codeAcces.ToLower().Equals("medecin") && !codeAcces.ToLower().Equals("secretaire"))
                {
                    Console.WriteLine("Code d'accès érronée");
                    codeAcces = Console.ReadLine();
                }
                else if (codeAcces == "medecin")
                    Menu(medecin, "Prendre Rdv", "Liste RDV", "Liste Consult", "Liste Hospitalisation", "Liste Traitement");
                else if (codeAcces == "secretaire")
                    Menu(secretaire, "Prendre Rdv", "Sans RDV", "Sans RDv", "Liste RDV", "Liste Facture");
            } while (!codeAcces.ToLower().Equals("medecin") && !codeAcces.ToLower().Equals("secretaire"));
            
        }

        static void Menu(List<Action> actions, params string[] affichage)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int position = 0;
            int nbMax = affichage.Length - 1;
            Console.Clear();
            int i = 0;
            foreach(string s in affichage)
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
