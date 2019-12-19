using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class EffectTimerController : Controller
    {
        //
        // GET: /EffectTimer/

        public ActionResult Index()
        {
            return Index(null);
        }


       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            ViewBag.starttime = starttime;
            ViewBag.endtime = endtime;

           

            return View();
        }



    }
}
