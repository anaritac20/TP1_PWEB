using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    [Authorize]
    public class EmpresaController : Controller
    {
        private TP1Context context;

        public EmpresaController()
        {
            context = new TP1Context();
        }

        // GET: Empresas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListasEmpresas()
        {
            return View(context.Empresas);
        }

     

        [HttpGet]
      //  [Authorize(Roles = "Empresa")]
        public ActionResult PreenchePerfil()
        {
            //   ViewBag.Perfis = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
      //  [Authorize(Roles = "Empresa")]
        public ActionResult PreenchePerfil(Empresa a)
        {
            var CurrentID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                Empresa f = context.Empresas.Single(x => x.UserId == CurrentID);

                f.Nome = a.Nome;
                f.Telefone = a.Telefone;
                f.Propostas = null;

            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}