using FilRouge.CoreWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.CoreWeb.Controllers
{
    public class FilRougeController : Controller
    {
        public string Index1()
        {
            return @"<html><body><h1 style=""color:red"">Hello</h1></body></html>";
        }
        public ActionResult Index2()
        {
            var p1 = new Personne();
            return View(p1);
        }
        public ActionResult Index()
        {
            var admins = FilRouge.Commun.GetAdmins();
            //foreach (var admin in admins)
            //{
            //    Console.WriteLine("{0}. {1}", admin.Id, admin.Nom);
            //    foreach (var etab in admin.LesEtablissements)
            //    {
            //        Console.WriteLine("\t{0}. {1}", etab.Id, etab.Libelle);
            //    }
            //}
            //Console.WriteLine();
            //Console.ForegroundColor = ConsoleColor.Gray;
            return View();
        }
    }
}
