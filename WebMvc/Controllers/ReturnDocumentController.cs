using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class ReturnDocumentController : Controller
    {
        //
        // GET: /ReturnDocument/

        public ActionResult Index()
        {
            return Index(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {

            string StreetName = string.Empty;
            string ReturnName = string.Empty;
            string ReturnAmount = string.Empty;
            string StartDate = string.Empty;
            string EndDate = string.Empty;

           
            
            Business.Platform.ReturnDocument bReturnDoc = new Business.Platform.ReturnDocument();

            List<Data.Model.ReturnDocument> lstReturnDoc = new List<Data.Model.ReturnDocument>();
            Business.Platform.Dictionary BDictionary = new Business.Platform.Dictionary();


            if (collection != null)
            {

                if (!Request.Form["Search"].IsNullOrEmpty())
                {


                    StreetName = Request.Form["StreetName"];

                    ReturnName = Request.Form["ReturnName"];

                    ReturnAmount = Request.Form["ReturnAmount"];

                    StartDate = Request.Form["StartDate"];

                    EndDate = Request.Form["EndDate"];

                    if (string.IsNullOrEmpty(StreetName) || string.IsNullOrEmpty(ReturnName) || string.IsNullOrEmpty(ReturnAmount) || string.IsNullOrEmpty(StartDate) || string.IsNullOrEmpty(EndDate))
                    {
                        lstReturnDoc = bReturnDoc.GetTasks(StreetName, ReturnName, ReturnAmount, StartDate, EndDate);
                    }
                    else
                    {
                        lstReturnDoc = bReturnDoc.GetAll();
                    }

                   
                }



            }
            else
            {
                lstReturnDoc = bReturnDoc.GetAll();
            }


            ViewBag.StreetName = StreetName;
            ViewBag.ReturnName = ReturnName;
            ViewBag.ReturnAmount = ReturnAmount;
            ViewBag.StartDate = StartDate;
            ViewBag.EndDate = EndDate;


            return View(lstReturnDoc);
        }





        public ActionResult ReturnDocumentTotal()
        {
            return ReturnDocumentTotal(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnDocumentTotal(FormCollection collection)
        {


            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            List<Data.Model.ReturnDocumentTotal> lstReturnDoc = new List<Data.Model.ReturnDocumentTotal>();
            Business.Platform.ReturnDocument bReturnDoc = new Business.Platform.ReturnDocument();

            if (collection != null && starttime != null && starttime!="")
            {
                lstReturnDoc = bReturnDoc.GetReturnReportAllPara(starttime, endtime);
            }
            else
            {
                lstReturnDoc = bReturnDoc.GetReturnReportAll();
            }







            ViewBag.starttime = starttime;
            ViewBag.endtime = endtime;
  

            return View(lstReturnDoc);
        }




    }
}
