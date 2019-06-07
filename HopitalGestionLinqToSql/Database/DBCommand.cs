using HopitalGestionLinqToSql;
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
    public class DBCommand //: IDB
    {
        private static Mutex m = new Mutex();
        private static SqlCommand command;
        HopitalDataContext data = new HopitalDataContext();

        public bool AddHopital(Hopital hopital)
        {
            bool res = true;
            Task t = Task.Run(() =>
            {
                //command = new SqlCommand("INSERT INTO HOPITAL (nom) VALUES(@n)", Connection.Instance);
                //command.Parameters.Add(new SqlParameter("@n", hopital.Nom));
                //m.WaitOne();
                //Connection.Instance.Open();
                //command.ExecuteNonQuery();
                //command.Dispose();
                //Connection.Instance.Close();
                //m.ReleaseMutex();
                data.Hopital.InsertOnSubmit(hopital);
                data.SubmitChanges();
            });
            t.Wait();

            return res;
        }

        //public Hopital GetHopital(string name)
        //{
        //    Hopital h = new Hopital();
        //    Task.Run(() =>
        //    {
        //        command = new SqlCommand("SELECT * FROM HOPITAL WHERE nom = @n", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@n", name));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            h.Nom = reader.GetString(1);
        //            h.Id = reader.GetInt32(0);
        //        }
        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });

        //    return h;
        //}


        //public void AddChambres(Chambre chambre)
        //{
        //    Random r = new Random();
        //    Task t = Task.Run(() =>
        //    {
        //        m.WaitOne();
        //        command = new SqlCommand("INSERT INTO CHAMBRE (etage, capacite, prix, occupe,Idhopital) VALUES(@e,@c,@p,@o,@i)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@e", chambre.Etage));
        //        command.Parameters.Add(new SqlParameter("@c", chambre.Capacite));
        //        command.Parameters.Add(new SqlParameter("@p", chambre.Prix));
        //        command.Parameters.Add(new SqlParameter("@o", chambre.Occupe));
        //        command.Parameters.Add(new SqlParameter("@i", chambre.IdHopital));
        //        Connection.Instance.Open();
        //        command.ExecuteNonQuery();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //    });
        //    t.Wait();
        //}

        //public void AddHospitalisation(Hospitalisation hospitalisation)
        //{
        //    Task hospitalisationT = Task.Run(() =>
        //    {
        //        command = new SqlCommand(
        //            "INSERT INTO hospitalisation (dateAdmission, typeAdmission, motifAdmission," +
        //            "idMedecin, nomAccompagnant, prenomAccompagnant, lientParente, dateEntreeAcc," +
        //            "idPatient) VALUES (@da, @ta, @ma, @im, @na, @pa, @lp, @dea, @ip)" , Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@da", hospitalisation.DateAdmission));
        //        command.Parameters.Add(new SqlParameter("@ta", hospitalisation.TypeAdmission));
        //        command.Parameters.Add(new SqlParameter("@ma", hospitalisation.MotifAdmission));
        //        command.Parameters.Add(new SqlParameter("@im", hospitalisation.IdMedecin));
        //        command.Parameters.Add(new SqlParameter("@na", hospitalisation.NomAccompagnant));
        //        command.Parameters.Add(new SqlParameter("@pa", hospitalisation.PreNomAccompagnant));
        //        command.Parameters.Add(new SqlParameter("@lp", hospitalisation.LienParente));
        //        command.Parameters.Add(new SqlParameter("@dea", hospitalisation.DateEntreeAcc));
        //        command.Parameters.Add(new SqlParameter("@ip", hospitalisation.IdPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        command.ExecuteNonQuery();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    hospitalisationT.Wait();
        //}

        //public bool AddPatient(Patient patient)
        //{
        //    bool b = false;
        //    Task t = Task.Run(() =>
        //    {
        //        command = new SqlCommand(
        //            "INSERT INTO patient (nom, prenom, dateNaissance, sexe, adresse, situationFamilliale, " +
        //            "assuranceMedical, codeAssurance, tel, nomPere, nomMere, nomPersonnePrevenir," +
        //            "telPersonnePrevenir) VALUES (@n,@p,@dn,@s,@a,@sf,@am,@ca,@t,@np,@nm,@npp,@tpp)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@n", patient.Nom));
        //        command.Parameters.Add(new SqlParameter("@p", patient.Prenom));
        //        command.Parameters.Add(new SqlParameter("@dn", patient.DateNaissance));
        //        command.Parameters.Add(new SqlParameter("@s", patient.Sexe));
        //        command.Parameters.Add(new SqlParameter("@a", patient.Adresse));
        //        command.Parameters.Add(new SqlParameter("@sf", patient.Situation));
        //        command.Parameters.Add(new SqlParameter("@am", patient.AssuranceMedicale));
        //        command.Parameters.Add(new SqlParameter("@ca", patient.CodeAssurance));
        //        command.Parameters.Add(new SqlParameter("@t", patient.Tel));
        //        command.Parameters.Add(new SqlParameter("@np", patient.NomPere));
        //        command.Parameters.Add(new SqlParameter("@nm", patient.NomMère));
        //        command.Parameters.Add(new SqlParameter("@npp", patient.NomPersonnePrevenir));
        //        command.Parameters.Add(new SqlParameter("@tpp", patient.TelPersAPrevenir));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            b = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    t.Wait();
        //    return b;
        //}

        //public bool AddRdv(Rdv rdv)
        //{
        //    bool result = false;
        //    Task rdvT = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO rdv (code, idMedecin, date, service, " +
        //            "idPatient) VALUES (@c,@im,@d,@s,@ip)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@c", rdv.Code));
        //        command.Parameters.Add(new SqlParameter("@im", rdv.IdMedecin));
        //        command.Parameters.Add(new SqlParameter("@d", rdv.Date));
        //        command.Parameters.Add(new SqlParameter("@s", rdv.Service));
        //        command.Parameters.Add(new SqlParameter("@ip", rdv.IdPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            result = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    rdvT.Wait();
        //    return result;
        //}

        //public List<Consultation> GetConsultationsByIdPatient(int idPatient)
        //{
        //    Task<List<Consultation>> consultationsT = Task<List<Consultation>>.Factory.StartNew(() =>
        //    {
        //        List<Consultation> consultations = new List<Consultation>();
        //        command = new SqlCommand(
        //            "SELECT * FROM consultation WHERE idPatient = @idP", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@idP", idPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            consultations.Add(new Consultation()
        //            {
        //                IdConsultation = reader.GetInt32(0),
        //                Date = reader.GetDateTime(1),
        //                Synthese = reader.GetString(2),
        //                TypeConsult = reader.GetString(3),
        //                Prix = reader.GetDecimal(4),
        //                IdPatient = reader.GetInt32(5)
        //            });
        //        }

        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return consultations;
        //    });

        //    return consultationsT.Result;
            
        //}

        //public List<Facture> GetFacturesByIdPatient(int idPatient)
        //{
        //    Task<List<Facture>> facturesT = Task<List<Facture>>.Factory.StartNew(() =>
        //    {
        //        List<Facture> fs = new List<Facture>();

        //        command = new SqlCommand("SELECT * FROM facture WHERE idPatient = @idP", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@idP", idPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            fs.Add(new Facture()
        //            {
        //                Id = reader.GetInt32(0),
        //                Date = reader.GetDateTime(1),
        //                Prix = reader.GetDecimal(2),
        //                IdPatient = reader.GetInt32(3),
        //                Payee = (OuiNonEnum) reader.GetInt32(4)
        //            });
        //        }

        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return fs;
        //    });
        //    facturesT.Wait();
        //    return facturesT.Result;
        //}

        //public List<Hospitalisation> GetHospitalisationsByIdPatient(int idPatient)
        //{
        //    Task<List<Hospitalisation>> hospitalisationsT = Task<List<Hospitalisation>>.Factory.StartNew(() =>
        //    {
        //        List<Hospitalisation> hs = new List<Hospitalisation>();

        //        command = new SqlCommand("SELECT * FROM hospitalisation WHERE idPatient = @idP", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@idP", idPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Hospitalisation h = new Hospitalisation()
        //            {
        //                Id = reader.GetInt32(0),
        //                DateAdmission = reader.GetDateTime(1),
        //                TypeAdmission = reader.GetString(2),
        //                MotifAdmission = reader.GetString(3),
        //                IdMedecin = reader.GetInt32(4),
        //                NomAccompagnant = reader.GetString(5),
        //                PreNomAccompagnant = reader.GetString(6),
        //                LienParente = (LienParenteEnum)reader.GetInt32(7),
        //                DateEntreeAcc = reader.GetDateTime(8),
        //                IdPatient = reader.GetInt32(14),
        //            };
        //            if (!reader.IsDBNull(9))
        //                h.DateSortieAcc = reader.GetDateTime(9);
        //            if (!reader.IsDBNull(10))
        //                h.MotifSortie = reader.GetString(10);
        //            if (!reader.IsDBNull(11))
        //                h.ResultatSortie = reader.GetString(11);
        //            if (!reader.IsDBNull(12))
        //                h.DateDeces = reader.GetDateTime(12);
        //            if (!reader.IsDBNull(13))
        //                h.MotifDeces = reader.GetString(13);
        //            if (!reader.IsDBNull(15))
        //                h.DateSortie = reader.GetDateTime(15);
        //            hs.Add(h);
        //        }

        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return hs;
        //    });
        //    hospitalisationsT.Wait();
        //    return hospitalisationsT.Result;
        //}

        //public Patient GetPatientByName(string name, string surname)
        //{
        //    if (name != null && surname != null)
        //    {
        //        Task<Patient> patient = Task<Patient>.Factory.StartNew(() =>
        //        {
        //            Patient p = null;
        //            command = new SqlCommand("SELECT * FROM patient WHERE nom=@nom AND prenom=@prenom", Connection.Instance);
        //            command.Parameters.Add(new SqlParameter("@nom", name));
        //            command.Parameters.Add(new SqlParameter("@prenom", surname));
        //            m.WaitOne();
        //            Connection.Instance.Open();

        //            SqlDataReader reader = command.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                p = new Patient()
        //                {
        //                    Id = reader.GetInt32(0),
        //                    Nom = name,
        //                    Prenom = surname,
        //                    DateNaissance = reader.GetDateTime(3),
        //                    Sexe = (SexeEnum)reader.GetInt32(4),
        //                    Adresse = reader.GetString(5),
        //                    Situation = (SituationFamillialeEnum)reader.GetInt32(6),
        //                    AssuranceMedicale = reader.GetString(7),
        //                    CodeAssurance = reader.GetString(8),
        //                    Tel = reader.GetString(9),
        //                    NomPere = reader.GetString(10),
        //                    NomMère = reader.GetString(11),
        //                    NomPersonnePrevenir = reader.GetString(12),
        //                    TelPersAPrevenir = reader.GetString(13)
        //                };
        //            }
        //            reader.Close();
        //            command.Dispose();
        //            Connection.Instance.Close();
        //            m.ReleaseMutex();

        //            return p;
        //        });
        //        patient.Wait();
        //        return patient.Result;
        //    }
        //    else
        //        return null;
        //}

        //public Medecin GetMedecinByService(ServiceEnum service)
        //{
        //    Task<Medecin> medecinT = Task<Medecin>.Factory.StartNew(() =>
        //    {
        //        Medecin me = new Medecin();

        //        command = new SqlCommand("SELECT * FROM medecin WHERE serviceNom = @s", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@s", service));

        //        m.WaitOne();
        //        Connection.Instance.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            me = new Medecin()
        //            {
        //                Id = reader.GetInt32(0),
        //                Nom = reader.GetString(1),
        //                Prenom = reader.GetString(2),
        //                Tel = reader.GetString(3),
        //                specialite = (SpecialiteEnum)reader.GetInt32(4),
        //                service = (ServiceEnum) reader.GetInt32(5)
        //            };
        //        }

        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return me;
        //    });
        //    medecinT.Wait();
        //    return medecinT.Result;
        //}

        //public List<Rdv> GetRdvsByIdPatient(int idPatient)
        //{
        //    Task<List<Rdv>> rendezsT = Task<List<Rdv>>.Factory.StartNew(() =>
        //    {
        //        List<Rdv> rdvs = new List<Rdv>();

        //        command = new SqlCommand("SELECT * FROM rdv WHERE idPatient = @idP AND date > GETDATE() " +
        //            "AND annule = @a ORDER BY date DESC", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@idP", idPatient));
        //        command.Parameters.Add(new SqlParameter("@a", OuiNonEnum.Non));
        //        m.WaitOne();
        //        Connection.Instance.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            rdvs.Add(new Rdv()
        //            {
        //                Id = reader.GetInt32(0),
        //                Code = reader.GetInt32(1),
        //                IdMedecin = reader.GetInt32(2),
        //                Date = reader.GetDateTime(3),
        //                Service = (ServiceEnum)reader.GetInt32(4),
        //                IdPatient = reader.GetInt32(5)
        //            });
        //        }

        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return rdvs;
        //    });
        //    rendezsT.Wait();
        //    return rendezsT.Result;
            
        //}

        //public List<Traitement> GetTraitementsByIdPatient(int idPatient)
        //{

        //    Task<List<Traitement>> traitementsT = Task<List<Traitement>>.Factory.StartNew(() =>
        //    {
        //        List<Traitement> ts = new List<Traitement>();

        //        command = new SqlCommand("SELECT * FROM traitement WHERE idPatient = @idP", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@idP", idPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();

        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ts.Add(new Traitement()
        //            {
        //                IdTraitement = reader.GetInt32(0),
        //                Date = reader.GetDateTime(1),
        //                Prix = reader.GetDecimal(2),
        //                IdPatient = reader.GetInt32(3)
        //            });
        //        }

        //        reader.Close();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return ts;
        //    });


        //    return traitementsT.Result;
        //}

        //public bool AddConsultation(Consultation consultation)
        //{
        //    bool b = false;
        //    Task t = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO consultation (date, synthese, typeConsultation," +
        //            "prix, idPatient) VALUES (@d,@s,@tc,@p,@ip)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@d", consultation.Date));
        //        command.Parameters.Add(new SqlParameter("@s", consultation.Synthese));
        //        command.Parameters.Add(new SqlParameter("@tc", consultation.TypeConsult));
        //        command.Parameters.Add(new SqlParameter("@p", consultation.Prix));
        //        command.Parameters.Add(new SqlParameter("ip", consultation.IdPatient));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            b = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    t.Wait();
        //    return b;
        //}

        //public bool AddPrescription(Prescription prescription)
        //{
        //    bool result = false;
        //    Task prescriptionT = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO prescription (date, idPatient, note) VALUES " +
        //            "(@d,@ip,@n)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@d", prescription.Date));
        //        command.Parameters.Add(new SqlParameter("@ip", prescription.IdPatient));
        //        command.Parameters.Add(new SqlParameter("@n", prescription.Note));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            result = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    prescriptionT.Wait();
        //    return result;
        //}

        //public bool AnnuleRdv(int idRdv)
        //{
        //    bool result = false;
        //    Task annuleRdvT = Task.Run(() =>
        //    {
        //        command = new SqlCommand("UPDATE rdv SET annule=@a WHERE id=@i", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@a", OuiNonEnum.Oui));
        //        command.Parameters.Add(new SqlParameter("@i", idRdv));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            result = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    annuleRdvT.Wait();
        //    return result;
        //}

        //public bool AddChirurgie(Chirurgie chirurgie)
        //{
        //    bool b = false;
        //    Task t = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO chirurgie (idChirurgien, idAnesthesiste, idTraitement) VALUES (@c, @a, @t)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@c", chirurgie.IdChirurgien));
        //        command.Parameters.Add(new SqlParameter("@a", chirurgie.IdAnesthesiste));
        //        command.Parameters.Add(new SqlParameter("@t", chirurgie.Id));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            b = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    t.Wait();
        //    return b;
        //}

        //public int AddTraitement(Traitement traitement)
        //{
        //    Task<int> traitementT = Task<int>.Run(() =>
        //    {
        //        command = new SqlCommand(
        //            "INSERT INTO traitement (date, prix, idPatient, idMedecin) " +
        //            "OUTPUT INSERTED.ID VALUES (@d,@p,@ip,@im)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@d", traitement.Date));
        //        command.Parameters.Add(new SqlParameter("@p", traitement.Prix));
        //        command.Parameters.Add(new SqlParameter("@ip", traitement.IdPatient));
        //        command.Parameters.Add(new SqlParameter("@im", traitement.IdMedecin));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int id = (int)command.ExecuteScalar();
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return id;
        //    });
        //    traitementT.Wait();
        //    return traitementT.Result;
        //}

        //public bool AddMedecin(Medecin medecin)
        //{
        //    bool result = false;
        //    Task medecinT = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO medecin (nom, prenom, tel, specialite, serviceNom) VALUES (@n, @p, @t, @sp, @sn)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@n", medecin.Nom));
        //        command.Parameters.Add(new SqlParameter("@p", medecin.Prenom));
        //        command.Parameters.Add(new SqlParameter("t", medecin.Tel));
        //        command.Parameters.Add(new SqlParameter("@sp", medecin.specialite));
        //        command.Parameters.Add(new SqlParameter("@sn", medecin.service));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            result = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    medecinT.Wait();
        //    return result;
        //}
        //public bool AddBiologie(ExamenBiologique biologiques)
        //{
        //    bool result = false;
        //    Task bioT = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO examenBiologique (designation, resultat, idTraitement," +
        //            "idMedecin) VALUES (@d, @r, @it, @im)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@d", biologiques.Designation));
        //        command.Parameters.Add(new SqlParameter("@r", biologiques.Resultat));
        //        command.Parameters.Add(new SqlParameter("@it", biologiques.IdTraitement));
        //        command.Parameters.Add(new SqlParameter("@im", biologiques.IdMedecin));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            result = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    bioT.Wait();
        //    return result;
        //}

        //public bool AddRadiologue(ExamenRadiologique radiologiques)
        //{
        //    bool result = false;
        //    Task radioT = Task.Run(() =>
        //    {
        //        command = new SqlCommand("INSERT INTO examenRadiologique (designation, resultat," +
        //            "idTraitement, idMedecin) VALUES (@d, @r, @it, @im)", Connection.Instance);
        //        command.Parameters.Add(new SqlParameter("@d", radiologiques.Designation));
        //        command.Parameters.Add(new SqlParameter("@r", radiologiques.Resultat));
        //        command.Parameters.Add(new SqlParameter("@it", radiologiques.IdTraitement));
        //        command.Parameters.Add(new SqlParameter("@im", radiologiques.IdMedecin));
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        int i = command.ExecuteNonQuery();
        //        if (i > 0)
        //            result = true;
        //        command.Dispose();
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();
        //    });
        //    radioT.Wait();
        //    return result;
        //}

        //public List<Patient> GetPatients()
        //{
        //    Task<List<Patient>> patientsT = Task<List<Patient>>.Run(() =>
        //   {
        //       List<Patient> patients = new List<Patient>();
        //       command = new SqlCommand("SELECT * FROM patient", Connection.Instance);
        //       m.WaitOne();
        //       Connection.Instance.Open();
        //       SqlDataReader reader = command.ExecuteReader();
        //       while (reader.Read())
        //       {
        //            patients.Add(new Patient()
        //            {
        //                Id = reader.GetInt32(0),
        //                Nom = reader.GetString(1),
        //                Prenom = reader.GetString(2),
        //                DateNaissance = reader.GetDateTime(3),
        //                Sexe = (SexeEnum)reader.GetInt32(4),
        //                Adresse = reader.GetString(5),
        //                Situation = (SituationFamillialeEnum)reader.GetInt32(6),
        //                AssuranceMedicale = reader.GetString(7),
        //                CodeAssurance = reader.GetString(8),
        //                Tel = reader.GetString(9),
        //                NomPere = reader.GetString(10),
        //                NomMère = reader.GetString(11),
        //                NomPersonnePrevenir = reader.GetString(12),
        //                TelPersAPrevenir = reader.GetString(13)
        //           });
        //       }
        //       Connection.Instance.Close();
        //       m.ReleaseMutex();

        //       return patients;
        //   });

        //    return patientsT.Result;
        //}

        //public List<Facture> GetFactures()
        //{
        //    Task<List<Facture>> facturesT = Task<List<Facture>>.Run(() =>
        //    {
        //        List<Facture> factures = new List<Facture>();
        //        command = new SqlCommand("SELECT * FROM facture", Connection.Instance);
        //        m.WaitOne();
        //        Connection.Instance.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            factures.Add(new Facture()
        //            {
        //                Id = reader.GetInt32(0),
        //                Date = reader.GetDateTime(1),
        //                Prix = reader.GetDecimal(2),
        //                IdPatient = reader.GetInt32(3),
        //                Payee = (OuiNonEnum)reader.GetInt32(4)
        //            });
        //        }
        //        Connection.Instance.Close();
        //        m.ReleaseMutex();

        //        return factures;
        //    });
        //    return facturesT.Result;
        //}
    }
}
