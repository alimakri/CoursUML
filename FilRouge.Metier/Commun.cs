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
        public static List<Admin> GetAdmins()
        {
            var utilisateurs = Data.GetUtilisateurs(RoleEnum.Admin);
            var admins = new List<Admin>();
            foreach (var admin in utilisateurs)
            {
                admins.Add(new Admin
                {
                    Id = admin.Id,
                    Nom = admin.Nom,
                    Role = admin.Role,
                    LesEtablissements = Data.GetEtablissementsByAdmin(admin.Id)
                });
            }
            return admins;
        }
        public static Admin GetAdmin(long id)
        {
            var utilisateurs = Data.GetUtilisateurs(RoleEnum.Admin);
            var utilisateur = utilisateurs.FirstOrDefault(x=>x.Id==id);
            var admin = new Admin
                {
                    Id = utilisateur.Id,
                    Nom = utilisateur.Nom,
                    Role = utilisateur.Role,
                    LesEtablissements = Data.GetEtablissements(utilisateur.Id)
                };            
            return admin;
        }

        //public static Admin GetAdmin(string adminId)
        //{
        //    var utilisateur =Commun.Utilisateurs.FirstOrDefault(x => x.Role == RoleEnum.Admin && x.Id == int.Parse(adminId));
        //    return new Admin
        //    {
        //        Id = utilisateur.Id
        //    };
        //}

        public static List<Etablissement> GetEtablissements()
        {
            return Data.GetEtablissements();
        }

        public static Etablissement GetEtablissement(int id)
        {
            return Data.GetEtablissement(id);
        }

        public static void DeleteEtablissement(int id)
        {
            Data.DeleteEtablissement(id);
        }

        public static void DeleteAdmin(int id)
        {
            Data.DeleteUtilisateur(id);
        }

        public static Admin GetAdmin( int id)
        {
            return Data.GetAdmin(id);
        }

        public static void AssocierEtabAdmin(Etablissement etab, Admin admin)
        {
            Data.AssocierEtabAdmin(etab, admin);
        }

        public static void DissocierEtabAdmin(Etablissement etab, Admin admin)
        {
            Data.DissocierEtabAdmin(etab, admin);
        }

        public static SuperAdmin SuperAdmin = new SuperAdmin("","", RoleEnum.SuperAdmin);
    }
}
