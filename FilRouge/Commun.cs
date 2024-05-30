using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

namespace FilRouge
{
    public static class Commun
    {
        public static void Init()
        {
            Etablissements = Data.GetEtablissements();
            Utilisateurs = Data.GetUtilisateurs();
        }

        internal static List<Admin> GetAdmins()
        {
           var utilisateurs = Commun.Utilisateurs.Where(x=>x.Role == RoleEnum.Admin);
           var admins = new List<Admin>();  
            foreach(var admin in utilisateurs)
            {
                admins.Add(new Admin {
                    Id = admin.Id,
                    Nom = admin.Nom,
                    Role = admin.Role,
                    LesEtablissements = Data.GetEtablissements(admin.Id)
                });
            }
            return admins;
        }

        internal static Admin GetAdmin(string adminId)
        {
            var utilisateur =Commun.Utilisateurs.FirstOrDefault(x => x.Role == RoleEnum.Admin && x.Id == int.Parse(adminId));
            return new Admin
            {
                Id = utilisateur.Id
            };
        }

        public static List<Etablissement> Etablissements = new List<Etablissement>();
        public static List<Utilisateur> Utilisateurs = new List<Utilisateur>();
    }
}
