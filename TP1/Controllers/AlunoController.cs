using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class AlunoController : Controller
    {
        //private Context db = Context.Db;
        private TP1Context context;

        public AlunoController()
        {
            context = new TP1Context();
        }



        // GET: Aluno
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult teste()
        {
            return Content("Ola, isto é o teste em AlunoController");
        }

        [HttpGet]
        public ActionResult PreenchePerfil()
        {
            //  ViewBag.Ramo = new SelectList(context. .Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            // context.Alunos.Find( )
            return View();
        }

        [HttpPost]
        public ActionResult PreenchePerfil(int c)
        {

            if (ModelState.IsValid)
            {
                //  Aluno a = context.Alunos.Find(Userid)

            }
            context.SaveChanges();
            return View();
        }

        public ActionResult ListarPropostas()
        {
            //var go = db.LPropostas.Where(x => x.Check == false);

            return View(context.Propostas);
        }

        public ActionResult ListarAlunos()
        {
            //var go = db.LPropostas.Where(x => x.Check == false);

            return View(context.Alunos);
        }
    }
}