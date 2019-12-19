using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class IndustrialInjuryController : Controller
    {
        //
        // GET: /IndustrialInjury/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult InjuryTotal()
        {
            return View();
        }

    }
}
