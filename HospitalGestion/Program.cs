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
        private static Random rdm = new Random();
        private static Medecin m = new Medecin();

        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.DarkCyan;
            //Console.ForegroundColor = ConsoleColor.Black;
            //Console.Clear();
            //Console.WriteLine("Quel est le nom de l'hopital ?");
            //string nameHospital = Console.ReadLine();
            //Hopital h = new Hopital();
            //bool success;
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
                AddPatient();

            MenuMedecinSecretaire();
        }
        static void MenuMedecinSecretaire()
        {
            AnnuleRendezVous();

            List<Action> medecin = new List<Action>();
            medecin.Add(PrendreRDV);
            medecin.Add(AddConsultation);
            medecin.Add(ListeRDV);
            medecin.Add(ListeConsultation);
            medecin.Add(ListeHospitalisation);
            medecin.Add(MenuPatient);

            List<Action> specialiste = new List<Action>();
            specialiste.Add(PrendreRDV);
            specialiste.Add(AddTraitementMethode);
            specialiste.Add(ListeRDV);
            specialiste.Add(ListeHospitalisation);
            specialiste.Add(ListeTraitement);
            specialiste.Add(MenuPatient);

            List<Action> secretaire = new List<Action>();
            secretaire.Add(PrendreRDV);
            secretaire.Add(SansRDV);
            secretaire.Add(ListeRDV);
            secretaire.Add(ListeFacture);
            secretaire.Add(MenuPatient);

            List<Action> administration = new List<Action>();
            administration.Add(AddMedecin);
            administration.Add(ListeFactureHopital);
            administration.Add(ListePatient);


            Console.WriteLine("Entrer le code d'accés :");
            string codeAcces = Console.ReadLine();

            do
            {
                if (!codeAcces.ToLower().Equals("medecin")
                    && !codeAcces.ToLower().Equals("secretaire")
                    && !codeAcces.ToLower().Equals("chirurgien")
                    && !codeAcces.ToLower().Equals("radiologue")
                    && !codeAcces.ToLower().Equals("biologiste")
                    && !codeAcces.ToLower().Equals("administration"))
                {
                    Console.WriteLine("Code d'accès érronée");
                    codeAcces = Console.ReadLine();
                }

                if (codeAcces == "generaliste")
                    Menu(medecin,
                        "- Prendre un rendez-vous :",
                        "- Consultation :",
                        "- Afficher la liste des rendez-vous du patient :",
                        "- Afficher la liste des consultations du patient :",
                        "- Afficher la liste des hospitalisation :",
                        "- Quittez");
                else if (codeAcces == "chirurgien" || codeAcces == "radiologue" || codeAcces == "biologiste")
                    Menu(specialiste,
                        "- Prendre un rendez-vous :",
                        "- Traitement :",
                        "- Afficher la liste des rendez-vous du patient :",
                        "- Afficher la liste des hospitalisation :",
                        "- Afficher la liste des traitements :",
                        "- Quittez");
                else if (codeAcces == "secretaire")
                    Menu(secretaire,
                        "- Prendre un rendez-vous :",
                        "- Consultation sans rendez-vous :",
                        "- Afficher la liste des rendez-vous :",
                        "- Afficher la liste des factures :",
                        "- Quittez");
                else if (codeAcces == "administration")
                    Menu(administration,
                        "Ajouter un medecin :",
                        "Liste Facture :",
                        "Liste Patient :");

            } while (!(!codeAcces.ToLower().Equals("medecin")
                    && !codeAcces.ToLower().Equals("secretaire")
                    && !codeAcces.ToLower().Equals("chirurgien")
                    && !codeAcces.ToLower().Equals("radiologue")
                    && !codeAcces.ToLower().Equals("biologiste")
                    && !codeAcces.ToLower().Equals("administration")));
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
            rdv.IdPatient = p.IdPatient;

            rdv.Service = (ServiceEnum)AfficherEnum<ServiceEnum>("Nom du service");

            rdv.IdMedecin = db.GetMedecinByService(rdv.Service).Id;

            Console.Write("Pour quel date voulez-vous réservée : ");
            string date = Console.ReadLine();
            rdv.Date_RDV = DateVerif(date, "Entrez une date de réservation valide :");

            db.AddRdv(rdv);

            if (rdv.Service != ServiceEnum.generaliste)
            {
                Hospitalisation h = new Hospitalisation();
                h.DateAdmission = rdv.Date_RDV;
                h.DateEntreeAcc = rdv.Date_RDV;
                h.IdPatient = p.IdPatient;

                Console.Write("Type d'admission : ");
                h.TypeAdmission = Console.ReadLine();

                Console.Write("Motif d'admission : ");
                h.MotifAdmission = Console.ReadLine();

                Console.Write("Nom de l'accompagnant : ");
                h.NomAccompagnant = Console.ReadLine();

                Console.Write("Prenom de l'accompagnant : ");
                h.PreNomAccompagnant = Console.ReadLine();

                h.LienParente = (LienParenteEnum)AfficherEnum<LienParenteEnum>("Lien parenté de l'accompagnant");

                db.AddHospitalisation(h);
            }
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
            if (listRDV != null)
            {
                foreach (Rendez_vous r in listRDV)
                {
                    Console.WriteLine(r.ToString());
                    Console.WriteLine("\n-----------------------------------------\n");
                }
            }
            else
                Console.WriteLine("Aucun rendez-vous pour ce client");
        }

        static void ListeConsultation()
        {
            List<Consultation> listConsultation = new List<Consultation>();
            listConsultation = db.GetConsultationsByIdPatient(p.IdPatient);
            if (listConsultation != null)
            {
                foreach (Consultation c in listConsultation)
                {
                    Console.WriteLine(c.ToString());
                    Console.WriteLine("\n-----------------------------------------\n");
                }
            }
            else
                Console.WriteLine("Aucune consultation pour ce client");
        }

        static void ListeHospitalisation()
        {
            List<Hospitalisation> listHospitalisation = new List<Hospitalisation>();
            listHospitalisation = db.GetHospitalisationsByIdPatient(p.IdPatient);
            if (listHospitalisation != null)
            {
                foreach (Hospitalisation h in listHospitalisation)
                {
                    Console.WriteLine(h.ToString());
                    Console.WriteLine("\n-----------------------------------------\n");
                }
            }
            else
                Console.WriteLine("Aucune hospitalisation pour ce patient");
        }

        static void ListeTraitement()
        {
            List<Traitement> listTraitement = new List<Traitement>();
            listTraitement = db.GetTraitementsByIdPatient(p.IdPatient);
            if (listTraitement != null)
            {
                foreach (Traitement t in listTraitement)
                {
                    Console.WriteLine(t.ToString());
                    Console.WriteLine("\n-----------------------------------------\n");
                }
            }
            else
                Console.WriteLine("Aucun traitement pour ce patient");
        }

        static void ListeFacture()
        {
            List<Facture> listFacture = new List<Facture>();
            listFacture = db.GetFacturesByIdPatient(p.IdPatient);
            if (listFacture != null)
            {
                foreach (Facture f in listFacture)
                {
                    Console.WriteLine(f.ToString());
                    Console.WriteLine("\n-----------------------------------------\n");
                }
            }
            else
                Console.WriteLine("Aucune facture pour ce patient");
        }
        static void ListeFactureHopital()
        {
            List<Facture> listeFactureHopital = new List<Facture>();
            listeFactureHopital = db.GetFactures();
            if (listeFactureHopital != null)
            {
                foreach (Facture f in listeFactureHopital)
                {
                    Console.WriteLine(f.ToString());
                    Console.WriteLine("\n-----------------------------------------\n");
                }
            }
        }
        static void ListePatient()
        {
            List<Patient> listePatient = new List<Patient>();
            listePatient = db.GetPatients();
            if(listePatient != null)
            {
                foreach(Patient p in listePatient)
                {
                    Console.WriteLine(p.ToString());
                    Console.WriteLine("\n-----------------------------\n");
                }
            }
            else
                Console.WriteLine("Pas de patient dans cet hopital !");
        }

        static void AddPatient()
        {
            Console.Clear();
            Console.Write("Quel est votre nom et prénom ? : ");
            string nomPrenom = Console.ReadLine();
            string temp = "";
            bool nomB = true;
            for (int i = 0; i < nomPrenom.Length; i++)
            {
                if (nomPrenom[i].ToString() == " ")
                {
                    nomB = false;
                    temp = "";
                }
                else
                {
                    temp += nomPrenom[i];
                }


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
            p.DateNaissance = DateVerif(date, "Entrez une date de naissance valide : ");

            Console.Clear();
            p.Sex = (SexeEnum)AfficherEnum<SexeEnum>("Etes vous un homme ou une femme");

            Console.WriteLine("Quel est votre adresse ? : ");
            p.Adresse = Console.ReadLine();

            p.Situation = (SituationFamillialeEnum)AfficherEnum<SituationFamillialeEnum>("Quel est votre situation familliale ? : ");

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

        static void AddConsultation()
        {
            Consultation c = new Consultation()
            {
                IdPatient = p.IdPatient
            };
            Console.Write("Date de la consultation : ");
            string date = Console.ReadLine();
            c.Date = DateVerif(date, "Entrez une date de consultation valide : ");

            Console.Write("Type de consultation : ");
            c.TypeConsult = Console.ReadLine();

            Console.WriteLine("Synthese : ");
            c.Synthese = Console.ReadLine();

            Console.WriteLine("Prix de la consultation : ");
            decimal prix = 0;
            Decimal.TryParse(Console.ReadLine(), out prix);
            c.Prix = prix;

            db.AddConsultation(c);

            AddPrescription(c.Date);
        }

        static void AddPrescription(DateTime date)
        {
            Prescription pr = new Prescription()
            {
                IdPatient = p.IdPatient,
                Date = date
            };

            Console.WriteLine("Note de la prescription : ");
            pr.Note = Console.ReadLine();

            db.AddPrescription(pr);
        }

        static void AnnuleRendezVous()
        {
            List<Rendez_vous> rdvs = db.GetRendez_VoussByIdPatient(p.IdPatient);
            if (rdvs.Count > 0)
            {
                int i = 1;
                foreach (var v in rdvs)
                {
                    Console.WriteLine($"{i}-{v.Date_RDV}");
                    i++;
                }
                int position = 0;
                Int32.TryParse(Console.ReadLine(), out position);

                if (position != 0)
                    db.AnnuleRendezVous(rdvs[position - 1].Id);
            }
            else
                Console.WriteLine("Aucune réservation");

        }

        static void AddTraitementMethode()
        {
            Console.WriteLine("Quel est le nom du service ?");
            Console.WriteLine("1 - chirurgien\n2 - anethesiste\n3 - radiologue\n4 - biologiste\n5 - generaliste");
            ServiceEnum serviceName = (ServiceEnum)Convert.ToInt32(Console.ReadLine());
            m = db.GetMedecinByService(serviceName);
            AddTraitement(m.Id);
        }
        static void AddTraitement(int idMedecin)
        {

            int idTraitement = 0;
            if (m.nomService == ServiceEnum.biologie || m.nomService == ServiceEnum.radiologie || m.nomService == ServiceEnum.chirurgie)
            {
                Traitement traitement = new Traitement()
                {
                    IdMedecin = idMedecin
                };

                Console.Write("Date du traitement : ");
                string date = Console.ReadLine();
                traitement.Date_traitement = DateVerif(date, "Entrez une date de traitement valide :");

                Console.WriteLine("Prix du traitement : ");
                decimal price = 0;
                Decimal.TryParse(Console.ReadLine(), out price);
                traitement.Prix_traitement = price;

                idTraitement = db.AjouterTraitement(traitement);
            }
            else
            {
                throw new Exception("Un imposteur ce fait passer pour un médecin");
            }

            if (m.nomService == ServiceEnum.chirurgie)
            {
                Chirurgie chirurgie = new Chirurgie()
                {
                    IdMedecin = m.Id,
                    Id_traitement = idTraitement
                };
                Medecin medecin = db.GetMedecinByService(ServiceEnum.anesthesiste);
                chirurgie.Id_chirurgie = medecin.Id;
                db.AddChirurgie(chirurgie);
            }
            else if (m.nomService == ServiceEnum.biologie)
            {
                Examens_Biologiques biologiques = new Examens_Biologiques()
                {
                    Id_traitement = idTraitement,
                    IdMedecin = m.Id
                };
                Console.WriteLine("Resultat : ");
                biologiques.Resultat_examen = Console.ReadLine();
            }
            else if (m.nomService == ServiceEnum.radiologie)
            {
                Examens_Radiologiques radiologiques = new Examens_Radiologiques()
                {
                    Id_traitement = idTraitement,
                    IdMedecin = m.Id
                };
                Console.WriteLine("Resultat : ");
                radiologiques.Resultat_examen = Console.ReadLine();
            }

        }

        static Enum AfficherEnum<T>(string s)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            int i = 0, position = 0, nbMax;
            List<Enum> e = new List<Enum>();
            if (!typeof(T).IsEnum)
                throw new Exception("Entrez une enum");

            Console.WriteLine(s);
            foreach (Enum v in Enum.GetValues(typeof(T)))
            {
                if (i == 0)
                    Console.Write(">");
                else
                    Console.Write(" ");
                Console.WriteLine(v);
                e.Add(v);
                i++;
            }
            nbMax = i - 1;
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
                    Console.WriteLine(s);
                    foreach (Enum v in Enum.GetValues(typeof(T)))
                    {
                        if (i == position)
                            Console.Write(">");
                        else
                            Console.Write(" ");
                        Console.WriteLine(v);
                        i++;
                    }
                }

            } while (cki.Key != ConsoleKey.Enter);

            return e[position];
        }

        static DateTime DateVerif(string date, string error)
        {
            DateTime datetime = new DateTime();
            do
            {
                int d = 0, m = 0, y = 0;
                if (MyRegex.DateNaissanceMatch(date))
                {
                    int b = 0;
                    string temp = "";
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
                    datetime = new DateTime(y, m, d);
                    break;
                }
                else
                {
                    Console.WriteLine(error);
                    date = Console.ReadLine();
                }
            } while (true);

            return datetime;
        }

        static void AddMedecin()
        {
            Medecin medecin = new Medecin();

            Console.WriteLine("Nom du medecin :");
            medecin.Nom = Console.ReadLine();
            Console.WriteLine("Prenom du medecin : ");
            medecin.Prenom = Console.ReadLine();
            Console.WriteLine("Telephone du medecin : ");
            string tel = Console.ReadLine();
            do
            {
                if (MyRegex.PhoneMatch(tel))
                {
                    medecin.Tel = tel;
                    break;
                }
                else
                {
                    Console.Write("Entrez un numéro de téléphone correct : ");
                    tel = Console.ReadLine();
                }
            } while (true);
            medecin.specialite = (SpecialiteEnum)AfficherEnum<SpecialiteEnum>("Aucune spécialité !");
            medecin.nomService = (ServiceEnum)AfficherEnum<ServiceEnum>("Aucun Service");
            db.AddMedecin(medecin);

        }


    }

}
