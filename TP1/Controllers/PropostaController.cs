using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP1.Controllers
{
    public class PropostaController : Controller
    {
        private Context db = Context.Db;
        // GET: Propostas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListasEstagios()
        {
            return View(db.LPropostas);
        }
    }
}