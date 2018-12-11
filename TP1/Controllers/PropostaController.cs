using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class PropostaController : Controller
    {
        private TP1Context context;

        public PropostaController()
        {
            context = new TP1Context();
        }

        // GET: Propostas
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        //  [Authorize(Roles = "Empresa")]
        public ActionResult SubmitE()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Empresa")]
        public ActionResult SubmitE(Proposta s)
        {
            var CurrentID = User.Identity.GetUserId();
            Empresa emp = context.Empresas.Single(x => x.UserId == CurrentID);
            if (ModelState.IsValid)
            {
                if (emp.Nome == null)
                {
                    return RedirectToAction("../Home/PerfilIncompleto");
                }

                s.Livre = true;
                s.Student = null;
                s.Empresas = emp;
                emp.Propostas.Add(s);
            }
            context.SaveChanges();
            return RedirectToAction("../Home/Submetido");
        }


        public ActionResult ListaPropostas()
        {
            var CurrentID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                if (User.IsInRole("Empresa"))
                {
                    Empresa emp = context.Empresas.Include("Propostas").Single(x => x.UserId == CurrentID);
                    if (emp.Propostas.Count == 0)
                        return View("NoPropostas");
                    return View(emp.Propostas);
                }
                else
                {
                    if (User.IsInRole("Docente"))
                    {
                        Docente doc = context.Docentes.Include("Propostas").Single(x => x.UserId == CurrentID);
                        if (doc.Propostas.Count == 0)
                            return View("NoPropostas");
                        return View(doc.Propostas);
                    }
                    else
                    {
                        if (User.IsInRole("Aluno"))
                        {
                            return View(context.Propostas);
                        }
                    }
                }
            }
            return View(context.Propostas);
        }

        public ActionResult ListaPropostasEmp(int id)
        {

            Empresa emp = context.Empresas.Include("Propostas").Single(x => x.ID == id);
            if (emp.Propostas.Count == 0)
                return View("NoPropostas");
            return View(emp.Propostas);
        }

        [HttpGet]
        [Authorize(Roles = "Docente")]
        [Authorize(Roles = "Comissao")]
        public ActionResult SubmitP()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Docente")]
        [Authorize(Roles = "Comissao")]
        public ActionResult SubmitP(Proposta s, int orientadores)
        {
            var CurrentID = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                Docente doc = context.Docentes.Single(x => x.UserId == CurrentID);
                if (doc.Nome == null)
                {
                    return RedirectToAction("Home/PerfilIncompleto");
                }

                s.Livre = true;
                s.Student = null;

                if (doc.Nome != null)
                    doc.Propostas.Add(s);
            }
            context.SaveChanges();
            return RedirectToAction("Home/Submetido");
        }

        public ActionResult NoPropostas()
        {
            return View();
        }

        public ActionResult EscolherOri(int num)
        {

            context.SaveChanges();
            return RedirectToAction("Home/Submetido");
        }
    }
}