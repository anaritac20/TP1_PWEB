using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP1.Controllers
{
    public class DocenteController : Controller
    {
        private Context db = Context.Db;
        // GET: Docentes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListasDocentes()
        {
            return View(db.LDocentes);
        }
    }
}