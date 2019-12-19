using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class ScrapCardController : Controller
    {
        //
        // GET: /ScrapCard/

        public ActionResult Index()
        {
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            ViewBag.starttime = starttime;
            ViewBag.endtime = endtime;
            return View();
        }

    }
}
