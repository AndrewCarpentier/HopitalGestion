using HospitalGestion.classes;
using HospitalGestion.enums;
using HospitalGestion.interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalGestion.bdd
{
    public class DBCommand : IDB
    {
        private static Mutex m = new Mutex();
        private static SqlCommand command;

        public void AddChambres(int nbChambres)
        {
            Random r = new Random();
            Task t = Task.Run(() =>
            {
                m.WaitOne();
                for (int i = 1; i <= nbChambres; i++)
                {
                    int Occupated = r.Next(2, 4);
                    command = new SqlCommand("INSERT INTO CHAMBRE (etage, capacite, prix, occupe) VALUES(@e,@c,@p,@o)", Connection.Instance);
                    command.Parameters.Add(new SqlParameter("@e", 1));
                    command.Parameters.Add(new SqlParameter("@c", Occupated));
                    command.Parameters.Add(new SqlParameter("@p", 50));
                    command.Parameters.Add(new SqlParameter("@o", 2));
                    Connection.Instance.Open();
                    command.ExecuteNonQuery();
                    command.Dispose();
                    Connection.Instance.Close();
                }

                m.ReleaseMutex();

            });
        }

        public void AddHospitalisation(Hospitalisation hospitalisation)
        {
            Task.Run(() =>
            {
                command = new SqlCommand(
                    "INSERT INTO hospitalisation (dateAdmission, typeAdmission, motifAdmission" +
                    "idMedecin, nomAccompagnant, prenomAccompagnant, lientParente, dateEntreeAcc," +
                    "dateSortieAcc, motifSortie, resultatSortie, dateDeces, motifDeces, idPatient," +
                    "dateSortie ) VALUES (@da, @ta, @ma, @im, @na, @pa, @lp, @dea, @dsa, @ms, @rs," +
                    "@audd, @md, @ip, @ds)" , Connection.Instance);
                command.Parameters.Add(new SqlParameter("@da", hospitalisation.DateAdmission));
                command.Parameters.Add(new SqlParameter("@ta", hospitalisation.TypeAdmission));
                command.Parameters.Add(new SqlParameter("@ma", hospitalisation.MotifAdmission));
                command.Parameters.Add(new SqlParameter("@im", hospitalisation.IdMedecin));
                command.Parameters.Add(new SqlParameter("@na", hospitalisation.NomAccompagnant));
                command.Parameters.Add(new SqlParameter("@pa", hospitalisation.PreNomAccompagnant));
                command.Parameters.Add(new SqlParameter("@lp", hospitalisation.LienParente));
                command.Parameters.Add(new SqlParameter("@dea", hospitalisation.DateEntreeAcc));
                command.Parameters.Add(new SqlParameter("@dsa", hospitalisation.DateSortieAcc));
                command.Parameters.Add(new SqlParameter("@ms", hospitalisation.MotifSortie));
                command.Parameters.Add(new SqlParameter("@rs", hospitalisation.ResultatSortie));
                command.Parameters.Add(new SqlParameter("@audd", hospitalisation.DateDeces));
                command.Parameters.Add(new SqlParameter("@md", hospitalisation.MotifDeces));
                command.Parameters.Add(new SqlParameter("@ip", hospitalisation.IdPatient));
                command.Parameters.Add(new SqlParameter("@ds", hospitalisation.DateSortie));
                m.WaitOne();
                Connection.Instance.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();
            });
        }

        public void AddPatient(Patient patient)
        {
            Task.Run(() =>
            {
                command = new SqlCommand(
                    "INSERT INTO patient (nom, prenom, dateNaissance, sexe, adresse, situationFamilliale, " +
                    "assuranceMedical, codeAssurance, tel, nomPere, nomMere, nomPersonnePrevenir," +
                    "telPersonnePrevenir) VALUES (@n,@p,@dn,@s,@a,@sf,@am,@ca,@t,@np,@nm,@npp,@tpp)", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@n", patient.Nom));
                command.Parameters.Add(new SqlParameter("@p", patient.Prenom));
                command.Parameters.Add(new SqlParameter("@dn", patient.DateNaissance));
                command.Parameters.Add(new SqlParameter("@s", patient.Sex));
                command.Parameters.Add(new SqlParameter("@a", patient.Adresse));
                command.Parameters.Add(new SqlParameter("@sf", patient.Situation));
                command.Parameters.Add(new SqlParameter("@am", patient.AssuranceMedicale));
                command.Parameters.Add(new SqlParameter("@ca", patient.CodeAssurance));
                command.Parameters.Add(new SqlParameter("@t", patient.Tel));
                command.Parameters.Add(new SqlParameter("@np", patient.NomPere));
                command.Parameters.Add(new SqlParameter("@nm", patient.NomMère));
                command.Parameters.Add(new SqlParameter("@npp", patient.NomPersonnePrevenir));
                command.Parameters.Add(new SqlParameter("@tpp", patient.TelPersAPrevenir));
                m.WaitOne();
                Connection.Instance.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();
            });
        }

        public void AddRdv(Rendez_vous rdv)
        {
            Task.Run(() =>
            {
                command = new SqlCommand("INSERT INTO rdv (code, idMedecin, date, service, " +
                    "idPatient) VALUES (@c,@im,@d,@s,@ip)", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@c", rdv.CodeRDV));
                command.Parameters.Add(new SqlParameter("@im", rdv.IdMedecin));
                command.Parameters.Add(new SqlParameter("@d", rdv.Date_RDV));
                command.Parameters.Add(new SqlParameter("@s", rdv.Service));
                command.Parameters.Add(new SqlParameter("@ip", rdv.IdPatient));
                m.WaitOne();
                Connection.Instance.Open();
                command.ExecuteNonQuery();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();
            });
        }

        public List<Consultation> GetConsultationsByIdPatient(int idPatient)
        {
            Task<List<Consultation>> consultationsT = Task<List<Consultation>>.Factory.StartNew(() =>
            {
                List<Consultation> consultations = new List<Consultation>();
                command = new SqlCommand(
                    "SELECT * FROM consultation WHERE idPatient = @idP", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@idP", idPatient));
                m.WaitOne();
                Connection.Instance.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    consultations.Add(new Consultation()
                    {
                        IdConsultation = reader.GetInt32(0),
                        Date = reader.GetDateTime(1),
                        Synthese = reader.GetString(2),
                        TypeConsult = reader.GetString(3),
                        Prix = reader.GetDecimal(4),
                        IdPatient = reader.GetInt32(5)
                    });
                }

                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();

                return consultations;
            });

            return consultationsT.Result;
            
        }

        public List<Facture> GetFacturesByIdPatient(int idPatient)
        {
            Task<List<Facture>> facturesT = Task<List<Facture>>.Factory.StartNew(() =>
            {
                List<Facture> fs = new List<Facture>();

                command = new SqlCommand("SELECT * FROM hospitalisation WHERE idPatient = @idP", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@idP", idPatient));
                m.WaitOne();
                Connection.Instance.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    fs.Add(new Facture()
                    {
                        Id_facture = reader.GetInt32(0),
                        Date_facture = reader.GetDateTime(1),
                        Prix = reader.GetDecimal(2),
                        IdPatient = reader.GetInt32(3),
                        Payee = (OuiNonEnum) reader.GetInt32(4)
                    });
                }

                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();

                return fs;
            });

            return facturesT.Result;
        }

        public List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient)
        {
            Task<List<Hospitalisation>> hospitalisationsT = Task<List<Hospitalisation>>.Factory.StartNew(() =>
            {
                List<Hospitalisation> hs = new List<Hospitalisation>();

                command = new SqlCommand("SELECT * FROM hospitalisation WHERE idPatient = @idP", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@idP", idPatient));
                m.WaitOne();
                Connection.Instance.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    hs.Add(new Hospitalisation()
                    {
                        IdHopitalisation = reader.GetInt32(0),
                        DateAdmission = reader.GetDateTime(1),
                        TypeAdmission = reader.GetString(2),
                        MotifAdmission = reader.GetString(3),
                        IdMedecin = reader.GetInt32(4),
                        NomAccompagnant = reader.GetString(5),
                        PreNomAccompagnant = reader.GetString(6),
                        LienParente = (LienParenteEnum)reader.GetInt32(7),
                        DateEntreeAcc = reader.GetDateTime(8),
                        DateSortieAcc = reader.GetDateTime(9),
                        MotifSortie = reader.GetString(10),
                        ResultatSortie = reader.GetString(11),
                        DateDeces = reader.GetDateTime(12),
                        MotifDeces = reader.GetString(13),
                        IdPatient = reader.GetInt32(14),
                        DateSortie = reader.GetDateTime(15)
                    });
                }

                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();

                return hs;
            });

            return hospitalisationsT.Result;
        }

        public Medecin GetMedecinByService(ServiceEnum service)
        {
            Task<Medecin> medecinT = Task<Medecin>.Factory.StartNew(() =>
            {
                Medecin me = new Medecin();

                command = new SqlCommand("SELECT * FROM medecin WHERE serviceNom = @s", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@s", service));

                m.WaitOne();
                Connection.Instance.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    me = new Medecin()
                    {
                        Id = reader.GetInt32(0),
                        Nom = reader.GetString(1),
                        Prenom = reader.GetString(2),
                        Tel = reader.GetString(3),
                        specialite = (SpecialiteEnum)reader.GetInt32(4),
                        nomService = (ServiceEnum) reader.GetInt32(5)
                    };
                }

                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();

                return me;
            });
            medecinT.Wait();
            return medecinT.Result;
        }

        public Patient GetPatientByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Rendez_vous> GetRendez_VoussByIdPatient(int idPatient)
        {
            Task<List<Rendez_vous>> rendezsT = Task<List<Rendez_vous>>.Factory.StartNew(() =>
            {
                List<Rendez_vous> rdvs = new List<Rendez_vous>();

                command = new SqlCommand("SELECT * FROM rdv WHERE idPatient = @idP", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@idP", idPatient));
                m.WaitOne();
                Connection.Instance.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    rdvs.Add(new Rendez_vous()
                    {
                        Id = reader.GetInt32(0),
                        CodeRDV = reader.GetInt32(1),
                        IdMedecin = reader.GetInt32(2),
                        Date_RDV = reader.GetDateTime(3),
                        Service = (ServiceEnum)reader.GetInt32(4),
                        IdPatient = reader.GetInt32(5)
                    });
                }

                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();

                return rdvs;
            });

            return rendezsT.Result;
            
        }

        public List<Traitement> GetTraitementsByIdPatient(int idPatient)
        {

            Task<List<Traitement>> traitementsT = Task<List<Traitement>>.Factory.StartNew(() =>
            {
                List<Traitement> ts = new List<Traitement>();

                command = new SqlCommand("SELECT * FROM rdv WHERE idPatient = @idP", Connection.Instance);
                command.Parameters.Add(new SqlParameter("@idP", idPatient));
                m.WaitOne();
                Connection.Instance.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ts.Add(new Traitement()
                    {
                        Id_traitement = reader.GetInt32(0),
                        Date_traitement = reader.GetDateTime(1),
                        Prix_traitement = reader.GetDecimal(2),
                        IdPatient = reader.GetInt32(3)
                    });
                }

                reader.Close();
                command.Dispose();
                Connection.Instance.Close();
                m.ReleaseMutex();

                return ts;
            });


            return traitementsT.Result;
        }


    }
}
