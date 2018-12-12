using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class AdminController : Controller
    {
        private TP1Context context;
        private IList<Docente> docentes;

        public AdminController()
        {
            docentes = new List<Docente>();
            context = new TP1Context();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listComissaoCurso() {

            return View(context.Docentes);
        }
        public ActionResult editarMembrosCC() {
            return View();
        }
        public ActionResult chooseMemberToEdit() {
           
            return View(UserTypeOptions());
        }

        [HttpPost]
        public ActionResult editarMembrosCC(Docente c)
        {
            return View();
        }

        public IEnumerable<SelectListItem> UserTypeOptions() {
            List<SelectListItem> l = new List<SelectListItem>();
            foreach (var d in docentes) {
                l.Add(new SelectListItem { Selected = true, Text = d.Nome, Value = d.ID.ToString()});
            }
            ViewBag.list = l;
            return l;
        }

    }
}