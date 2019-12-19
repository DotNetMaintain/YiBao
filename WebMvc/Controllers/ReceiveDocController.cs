using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebMvc.Controllers
{
    public class ReceiveDocController : Controller
    {



        public ActionResult Index()
        {
            return Index(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {

            string DocumentType = string.Empty;
            string DocumentLevel = string.Empty;
            string DocumentTitle = string.Empty;
            string DocumentCode = string.Empty;
            string AddTime = string.Empty;
            string DocumentUnit = string.Empty;

            Business.Platform.ReceiveDoc bReceiveDoc = new Business.Platform.ReceiveDoc();

            List<Data.Model.ReceiveDoc> lstReceiveDoc = new List<Data.Model.ReceiveDoc>();
            Business.Platform.Dictionary BDictionary = new Business.Platform.Dictionary();
         

            if (collection != null)
            {

                if (!Request.Form["Search"].IsNullOrEmpty())
                {


                    DocumentType = Request.Form["DocumentType"];
                   
                    DocumentLevel = Request.Form["DocumentLevel"];
                    DocumentTitle = Request.Form["DocumentTitle"];
                    DocumentCode = Request.Form["DocumentCode"];
                    DocumentUnit = Request.Form["DocumentUnit"];
                    AddTime = Request.Form["AddTime"];
                    


                    lstReceiveDoc = bReceiveDoc.GetTasks(DocumentType, DocumentLevel, DocumentTitle, DocumentCode, DocumentUnit,AddTime);
                }
                

               
            }
            else
            {
                lstReceiveDoc = bReceiveDoc.GetAll();
            }


            ViewBag.DocumentType = DocumentType;
            ViewBag.DocumentLevel = DocumentLevel;
            ViewBag.DocumentTitle = DocumentTitle;
            ViewBag.DocumentUnit = DocumentUnit;
            ViewBag.DocumentCode = DocumentCode;
            ViewBag.AddTime = AddTime;


            
            return View(lstReceiveDoc);
        }






        public ActionResult AddReceiveDoc()
        {
            return AddReceiveDoc(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReceiveDoc(FormCollection collection)
        {
            string DocumentType = string.Empty;
            string DocumentLevel = string.Empty;
            string DocumentTitle = string.Empty;
            string DocumentCode = string.Empty;
            string DocumentAttech = string.Empty;
            string DocumentUnit = string.Empty;


           
            Business.Platform.ReceiveDoc bReceiveDoc = new Business.Platform.ReceiveDoc();
            Data.Model.ReceiveDoc ReceiveDoc = new Data.Model.ReceiveDoc();
          //  ViewBag.ProvinceOption = bReceiveDoc.GetOptions(Province);   // bReceiveDoc.GetAllIDAndName();

            string id = Request.QueryString["id"];
            if (id != null)
            {


                Data.Model.ReceiveDoc ReceiveDocid = bReceiveDoc.Get(id.ToInt32());
                if (ReceiveDocid == null)
                {


                    ReceiveDocid.DocumentTitle = "";
                    ReceiveDocid.DocumentType = "";
                    ReceiveDocid.DocumentLevel = "";
                    ReceiveDocid.DocumentCode = "";
                    ReceiveDocid.ReceiveDate = "";
                    ReceiveDocid.DocumentNum = "";
                    ReceiveDocid.DocumentAttech = "";
                    ReceiveDocid.UserID = "";
                    ReceiveDocid.AddTime = System.DateTime.Now;



                }
                else
                {
                    ReceiveDoc = ReceiveDocid;
                }

            }

            if (collection != null)
            {
                DocumentType = Request.Form["ReceiveDocument.DocumentType"];

                DocumentLevel = Request.Form["ReceiveDocument.DocumentLevel"];
                DocumentTitle = Request.Form["ReceiveDocument.DocumentTitle"];
                DocumentCode = Request.Form["ReceiveDocument.DocumentCode"];
                DocumentAttech = Request.Form["ReceiveDocument.DocumentAttech"];
                DocumentUnit = Request.Form["ReceiveDocument.DocumentUnit"];
                

                
                    if (!Request.Form["Save"].IsNullOrEmpty() && ReceiveDoc != null)
                    {

                        ReceiveDoc.ID = Guid.NewGuid();
                        ReceiveDoc.DocumentTitle = DocumentTitle;
                        ReceiveDoc.DocumentType = DocumentType;
                        ReceiveDoc.DocumentLevel = DocumentLevel;
                        ReceiveDoc.DocumentUnit = DocumentUnit;
                        ReceiveDoc.DocumentCode = DocumentCode;
                        ReceiveDoc.DocumentAttech = DocumentAttech;
                        ReceiveDoc.ReceiveDate = "";
                        ReceiveDoc.DocumentNum = "";
                        ReceiveDoc.UserID = Business.Platform.Users.CurrentUserID.ToString();
                        ReceiveDoc.AddTime = System.DateTime.Now;

                       
                        bReceiveDoc.Add(ReceiveDoc);



                        Business.Platform.Log.Add("修改了收文信息", ReceiveDoc.Serialize());
                        ViewBag.Script = "alert('保存成功!');";
                    }
                    else
                    {
                        bReceiveDoc.Update(ReceiveDoc);
                        Business.Platform.Log.Add("修改了收文信息", ReceiveDoc.Serialize());
                        ViewBag.Script = "alert('保存成功!');";
                    }


                    ViewBag.Result = "OK";


                
     

                

            }

            return View(bReceiveDoc);
        }





       


        




    }
}
