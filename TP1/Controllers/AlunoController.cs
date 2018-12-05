using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP1.Controllers
{
    public class AlunoController : Controller
    {
        private Context db = Context.Db;
        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarPropostas()
        {
            //var go = db.LPropostas.Where(x => x.Check == false);

            return View(db.LPropostas);
        }
    }
}