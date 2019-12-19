using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace WebMvc.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PetitionLetterForm(FormCollection collection)
        {

            var content = collection["editor"];

           return View();
        }

        public ActionResult PetitionLetterForm()
        {
            return PetitionLetterForm(null);
        }




        public ActionResult PetitionLetterList()
        {
            return PetitionLetterList(null);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult PetitionLetterList(FormCollection collection)
        {

            

            return View();
        }


    }
}
