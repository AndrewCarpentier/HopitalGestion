﻿using HospitalGestion.bdd;
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

                if (codeAcces == "medecin")
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
            AddPatient();
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

        static void AddPatient()
        {
            Patient p = new Patient();
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
