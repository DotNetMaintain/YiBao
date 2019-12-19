using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class RepairController : Controller
    {
        //
        // GET: /Repair/

        public ActionResult Index()
        {
            Business.Platform.Repair brepair = new Business.Platform.Repair();


            List<Data.Model.Repair> lstrepair = new List<Data.Model.Repair>();

            lstrepair = brepair.GetAll();



            return View(lstrepair);
        }

    }
}
