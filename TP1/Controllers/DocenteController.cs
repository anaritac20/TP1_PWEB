using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class DocenteController : Controller
    {
        private TP1Context context;

        public DocenteController()
        {
            context = new TP1Context();
        }
        // GET: Docentes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListasDocentes()
        {
            return View(context.Docentes);
        }
    }
}