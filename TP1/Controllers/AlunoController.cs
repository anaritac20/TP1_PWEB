using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TP1.Models;
using Microsoft.AspNet.Identity;

namespace TP1.Controllers
{
    [Authorize]
    public class AlunoController : Controller
    {
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



        [HttpGet]
        public ActionResult PreenchePerfil()
        {
            //   ViewBag.Perfis = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Aluno")]
        public ActionResult PreenchePerfil(Aluno a)
        {
            var CurrentID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                Aluno f = context.Alunos.Single(x => x.UserId == CurrentID);
            
                f.Nome = a.Nome;
                f.nAluno = a.nAluno;
                f.Curriculo = a.Curriculo;
                f.Ramo = a.Ramo;

            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ListarAlunos()
        {

            return View(context.Alunos);
        }

        //[HttpGet]
        //public ActionResult Delete(int c)
        //{
        //    Aluno a = context.Alunos.Single(x => x.ID == c);
        //    return View(a);
        //}
        //[HttpPost]
        //public ActionResult Delete(Aluno a)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Alunos.Remove(a);
        //    }
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult teste()
        {
            return Content("Ola, isto é o teste em AlunoController");
        }
    }
}