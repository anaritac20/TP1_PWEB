using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class EmpresaController : Controller
    {
        private Context db = Context.Db;
        // GET: Empresas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListasEmpresas()
        {
            return View(db.LEmpresas);
        }

        public ActionResult Submit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Submit(Proposta s)
        {
            if (!ModelState.IsValid)
            {
                s.Livre = true;
                s.Student = null;

                db.LPropostas.Add(s);

            }

            return RedirectToAction("Home/Submetido");

        }
    }
}