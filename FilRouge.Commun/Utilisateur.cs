using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    public enum RoleEnum { None = 0, Eleve = 1, Formateur = 2, Admin = 4, SuperAdmin = 8 }
    public class Utilisateur
    {
        public long Id;
        public string Nom = "";
        public string Password = "";
        public bool Autorise = false;
        public RoleEnum Role = RoleEnum.None;
    }
    public class Eleve : Utilisateur
    {
        public List<Session> LesSessions;
    }
    public class Formateur : Utilisateur
    {
    }
    public class Admin : Utilisateur
    {
        public List<Etablissement> LesEtablissements = new List<Etablissement>();
    }
    public class SuperAdmin : Admin
    {
        public SuperAdmin(string nom, string password, RoleEnum role)
        {
            Nom = nom;
            Password = password;
            Role = role;
            Login(nom, password);
            LesEtablissements = new List<Etablissement>();
        }

        // Todo : Recherche dans la BD
        private void Login(string nom, string password)
        {
            Autorise = nom == "Ali" && password == "P@ssw0rd" && Role == RoleEnum.SuperAdmin;
        }
    }
}
