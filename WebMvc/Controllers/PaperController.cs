using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class PaperController : MyController
    {
        //
        // GET: /Paper/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PaperManage()
        {
            return View();
        }

    }
}
