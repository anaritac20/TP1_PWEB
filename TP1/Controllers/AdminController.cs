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

        public AdminController()
        {
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


    }
}