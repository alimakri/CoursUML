using FilRouge.CoreWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilRouge.CoreWeb.Controllers
{
    [Authorize]
    public class FilRougeController : Controller
    {
        [AllowAnonymous]
        public string Index1()
        {
            return @"<html><body><h1 style=""color:red"">Hello</h1></body></html>";
        }
        public ActionResult Index2()
        {
            var p1 = new Personne();
            return View(p1);
        }
        [Authorize(Roles =AdminPlus)]
        public ActionResult Index()
        {
            FilRouge.Data.Init();
            var admins = Commun.GetAdmins();
            return View(admins);
        }
    }
}
