using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    #region Autres
    public class Session
    {
        public string Libelle;
        public List<Module> LesModules;
        public List<Eleve> LesEleves;
        public DateTime DateDebut;
        public DateTime DateFin;
    }
    public class Note
    {
        public DateTime DateNotation;
        public Module LeModule;
        public Eleve LEleve;
        public int Valeur;
        public string Commentaire;
    }
    public class Module
    {
        public string Libelle;
        public List<DemiJournee> LesJours;
        public Formateur LeFormateur;
    }
    public class DemiJournee
    {
        public DateTime HeureDebut;
        public DateTime HeureFin;
    }
    public class Etablissement
    {
        public long Id;
        public string Libelle;
        // ....
        public List<Session> LesSessions;
    }
    #endregion
}
