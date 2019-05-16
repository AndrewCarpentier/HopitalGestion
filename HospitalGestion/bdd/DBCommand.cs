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

        public void CrerChambres(int n)
        {
            //SqlCommand = new SqlCommand()
            //for (int i = 1; i <= n; i++)
            //{

            //}
        }

        public List<Consultation> GetConsultationsByIdPatient(int idPatient)
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
        }

        public List<Facture> GetFacturesByIdPatient(int idPatient)
        {
            List<Facture> fs = new List<Facture>();

            command = new SqlCommand("SELECT * FROM hospitalisation WHERE idPatient = @idP", Connection.Instance);
            command.Parameters.Add(new SqlParameter("@idP", idPatient));
            m.WaitOne();
            Connection.Instance.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                fs.Add(new Facture() {
                    Id_facture = reader.GetInt32(0),
                    Date_facture = reader.GetDateTime(1),
                    Prix = reader.GetDecimal(2),
                    IdPatient = reader.GetInt32(3)
                });
            }

            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            m.ReleaseMutex();

            return fs;
        }

        public List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient)
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
        }

        public List<Rendez_vous> GetRendez_VoussByIdPatient(int idPatient)
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
        }

        public List<Traitement> GetTraitementsByIdPatient(int idPatient)
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
        }
    }
}
