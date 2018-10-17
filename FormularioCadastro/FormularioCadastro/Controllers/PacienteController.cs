using FormularioCadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormularioCadastro.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteEntities db = new PacienteEntities();
        // GET: Paciente
        public ActionResult Index()
        {

            return View();
        }
    }
}