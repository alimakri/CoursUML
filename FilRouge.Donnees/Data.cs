using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace FilRouge
{
    public static class Data
    {
        private static SqlCommand Cmd;
        public static void Init()
        {
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=FilRouge;Integrated Security=true;TrustServerCertificate=True";
            cnx.Open();

            Cmd = new SqlCommand();
            Cmd.Connection = cnx;
            Cmd.CommandType = CommandType.Text;
        }
        public static void AddEtablissement(Etablissement etablissement)
        {
            Cmd.CommandText = $"insert Etablissement (Libelle) values('{etablissement.Libelle}')";
            Cmd.ExecuteNonQuery();
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
            Cmd.CommandText = $"select e.Id, e.Libelle from Etablissement e inner join Utilisateur u on u.Id={adminId}";
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
        public static List<Utilisateur> GetUtilisateurs(RoleEnum role)
        {
            if (role== RoleEnum.None)
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
    }
}
