using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal static void AddEtablissement(Etablissement etablissement)
        {
            Cmd.CommandText = $"insert Etablissement (Libelle) values('{etablissement.Libelle}')";
            Cmd.ExecuteNonQuery();
        }

        internal static void AddUtilisateur(Admin admin)
        {
            Cmd.CommandText = $"insert Utilisateur (Nom, Password, Role) values('{admin.Nom}', '{admin.Password}', {(int)admin.Role})";
            Cmd.ExecuteNonQuery();
        }

        internal static void AssocierEtabAdmin(Etablissement etab, Utilisateur admin)
        {
            Cmd.CommandText = $"update Etablissement set Admin={admin.Id} where Id={etab.Id}";
            Cmd.ExecuteNonQuery();
        }
        internal static void DissocierEtabAdmin(Etablissement etab, Utilisateur admin)
        {
            Cmd.CommandText = $"update Etablissement set Admin=NULL where Id={etab.Id}";
            Cmd.ExecuteNonQuery();
        }

        internal static List<Etablissement> GetEtablissements(long adminId = 0)
        {
            Cmd.CommandText = "select * from Etablissement";
            if (adminId != 0) Cmd.CommandText += $" where Id={adminId}";
            SqlDataReader rd = Cmd.ExecuteReader();

            var liste = new List<Etablissement>();
            while (rd.Read())
            {
                liste.Add(new Etablissement { Id = rd.GetInt64("Id"), Libelle = rd.GetString("Libelle"), LesSessions = new List<Session>() });
            }
            rd.Close();
            return liste;
        }
        internal static List<Utilisateur> GetUtilisateurs()
        {
            Cmd.CommandText = "select * from Utilisateur";
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
    }
}
