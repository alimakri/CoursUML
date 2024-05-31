using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace FilRouge
{
    public static class Data
    {
        private static bool ConnectionOk = false;
        private static SqlCommand Cmd;
        public static void Init()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FilRouge;Integrated Security=true;TrustServerCertificate=True";
            try
            {
                cnx.Open();
                ConnectionOk = true;
            }
            catch (Exception ex)
            {

            }

            Cmd = new SqlCommand();
            Cmd.Connection = cnx;
            Cmd.CommandType = CommandType.Text;
        }
        public static bool AddEtablissement(Etablissement etablissement)
        {
            if (!ConnectionOk) return false;

            Cmd.CommandText = $"insert Etablissement (Libelle) values('{etablissement.Libelle}')";
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static void AddUtilisateur(Admin admin)
        {
            Cmd.CommandText = $"insert Utilisateur (Nom, Password, Role) values('{admin.Nom}', '{admin.Password}', {(int)admin.Role})";
            Cmd.ExecuteNonQuery();
        }

        public static void AssocierEtabAdmin(Etablissement etab, Utilisateur admin)
        {
            Cmd.CommandText = $"update Etablissement set Admin={admin.Id} where Id={etab.Id}";
            Cmd.ExecuteNonQuery();
        }
        public static void DissocierEtabAdmin(Etablissement etab, Utilisateur admin)
        {
            Cmd.CommandText = $"update Etablissement set Admin=NULL where Id={etab.Id}";
            Cmd.ExecuteNonQuery();
        }

        public static List<Etablissement> GetEtablissements(long id = 0)
        {
            Cmd.CommandText = "select * from Etablissement";
            if (id != 0) Cmd.CommandText += $" where Id={id}";
            SqlDataReader rd = Cmd.ExecuteReader();

            var liste = new List<Etablissement>();
            while (rd.Read())
            {
                liste.Add(new Etablissement { Id = rd.GetInt64("Id"), Libelle = rd.GetString("Libelle"), LesSessions = new List<Session>() });
            }
            rd.Close();
            return liste;
        }
        public static List<Etablissement> GetEtablissementsByAdmin(long adminId)
        {
            Cmd.CommandText = $"select e.Id, e.Libelle from Etablissement e inner join Utilisateur u on e.Admin=u.Id where u.Id={adminId}";
            SqlDataReader rd = Cmd.ExecuteReader();

            var liste = new List<Etablissement>();
            while (rd.Read())
            {
                liste.Add(new Etablissement { Id = rd.GetInt64("Id"), Libelle = rd.GetString("Libelle"), LesSessions = new List<Session>() });
            }
            rd.Close();
            return liste;
        }
        public static Etablissement GetEtablissement(long id)
        {
            Cmd.CommandText = $"select * from Etablissement where id={id}";
            SqlDataReader rd = Cmd.ExecuteReader();
            Etablissement etab = null;
            if (rd.Read())
            {
                etab = new Etablissement { Id = rd.GetInt64("Id"), Libelle = rd.GetString("Libelle") };
            }
            rd.Close();
            return etab;
        }
        public static Module GetModule(long id)
        {
            Cmd.CommandText = $"select * from Module where id={id}";
            SqlDataReader rd = Cmd.ExecuteReader();
            Module module = null;
            if (rd.Read())
            {
                module = new Module { Id = rd.GetInt64("Id"), Libelle = rd.GetString("Libelle") };
            }
            rd.Close();
            return module;
        }
        public static Admin GetAdmin(long id)
        {
            Cmd.CommandText = $"select * from Utilisateur where Role=4 and id={id}";
            SqlDataReader rd = Cmd.ExecuteReader();
            Admin admin = null;
            if (rd.Read())
            {
                admin = new Admin { Id = rd.GetInt64("Id"), Nom = rd.GetString("Nom") };
            }
            rd.Close();
            return admin;
        }
        public static List<Eleve> GetElevesByModule(int sessionId, int moduleId)
        {
            Cmd.CommandText = $@"select u.Id, u.Nom 
                                    from SessionEleve se
                                    inner join Utilisateur u on se.Eleve=u.Id
                                    where Role={(int)RoleEnum.Eleve} and se.Session = {sessionId}";

            SqlDataReader rd = Cmd.ExecuteReader();
            List<Eleve> eleves = new List<Eleve>();
            while (rd.Read())
            {
                eleves.Add(new Eleve { Id = rd.GetInt64("Id"), Nom = rd.GetString("Nom") });
            }
            rd.Close();
            return eleves;
        }

        public static List<Utilisateur> GetUtilisateurs(RoleEnum role)
        {
            if (role == RoleEnum.None)
                Cmd.CommandText = $"select * from Utilisateur";
            else
                Cmd.CommandText = $"select * from Utilisateur where Role={(int)role}";
            SqlDataReader rd = Cmd.ExecuteReader();

            var liste = new List<Utilisateur>();
            while (rd.Read())
            {
                liste.Add(new Utilisateur
                {
                    Id = rd.GetInt64("Id"),
                    Nom = rd.GetString("Nom"),
                    Role = (RoleEnum)rd.GetByte("Role")
                });
            }
            rd.Close();
            return liste;
        }

        public static void DeleteEtablissement(int id)
        {
            Cmd.CommandText = $"delete Etablissement where id={id})";
            Cmd.ExecuteNonQuery();
        }

        public static void DeleteUtilisateur(object id)
        {
            Cmd.CommandText = $"delete Utilisateur where id={id})";
            Cmd.ExecuteNonQuery();
        }

        public static void AffecterNote(string moduleId, long eleveId, string? noteval, string? commentaire)
        {

            Cmd.CommandText = $"insert Note (DateNotation, Module, Eleve, Valeur, Commentaire) values (getdate(), {moduleId}, {eleveId}, {noteval}, '{commentaire}')";
            Cmd.ExecuteNonQuery();
        }
        public static void ModifierNote(string moduleId, long eleveId, string noteVal, string? commentaire)
        {
            Cmd.CommandText = $"update Note set Valeur={noteVal}, Commentaire='{commentaire}' where Eleve={eleveId} and Module={moduleId}";
            Cmd.ExecuteNonQuery();
        }
        public static Note GetNote(string moduleId, long eleveId)
        {
            Cmd.CommandText = $"select Id, Valeur from Note where Module={moduleId} and Eleve={eleveId}";
            SqlDataReader rd = Cmd.ExecuteReader(); Note note = null;
            if (rd.Read())
            {
                note = new Note { Id = rd.GetInt64("Id"), Valeur = rd.GetByte("Valeur") };
            }
            rd.Close();
            return note;
        }


    }
}
