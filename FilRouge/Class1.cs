using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge
{
    public class Eleve
    {
        public string Libelle;
        public List<Session> LesSessions;
    }
    public class Cours
    {
        public string Libelle;
        public string Description;

    }
    public class Session
    {
        public string Libelle; 
        public List<Module> LesModules;
        public List<Eleve> LesEleves;

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
        public string Libelle;
        // ....
        public List<Session> LesSessions;
    }
    public class Formateur
    {
        public string Libelle;
    }
}
