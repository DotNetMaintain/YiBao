using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class HelpPoorSamplesController : Controller
    {



        public ActionResult Index()
        {
            return Index(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {

            string Code = string.Empty;
            string Province = string.Empty;
            string AgentName = string.Empty;

            Business.Platform.HelpPoorSamples bhelppoorsamples = new Business.Platform.HelpPoorSamples();

            List<Data.Model.HelpPoorSamples> lsthelppoorsamples = new List<Data.Model.HelpPoorSamples>();


            if (collection != null)
            {

                if (!Request.Form["Select"].IsNullOrEmpty())
                {


                    Code = Request.Form["Code"];
                    Province = Request.Form["Province"];
                    AgentName = Request.Form["AgentName"];
                    if (string.IsNullOrEmpty(Province) && string.IsNullOrEmpty(AgentName))
                    {
                        lsthelppoorsamples = bhelppoorsamples.GetAll();
                    }
                    else
                    {
                        lsthelppoorsamples = bhelppoorsamples.GetTasks(Code, Province, AgentName);
                    }
                    
                }
                

               
            }
            else
            {
                lsthelppoorsamples = bhelppoorsamples.GetAll();
            }


            ViewBag.Province = Province;
            ViewBag.AgentName = AgentName;
           

            
            return View(lsthelppoorsamples);
        }






        public ActionResult AddHelpPoorSamples()
        {
            return AddHelpPoorSamples(null);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHelpPoorSamples(FormCollection collection)
        {
            string Province = string.Empty;
            string AgentName = string.Empty;
            string AttechFile = string.Empty;
            string Code = string.Empty;
            string txtProvince = string.Empty;

            if (collection != null)
            {


                Province = Request.Form["Province"];
               
            }
            else
            {
                Province = Request.QueryString["Province"];
            }
            ViewBag.Province = Province;
         
            Business.Platform.HelpPoorSamples bhelppoorsamples = new Business.Platform.HelpPoorSamples();
            Data.Model.HelpPoorSamples helppoorsamples = new Data.Model.HelpPoorSamples();
            ViewBag.ProvinceOption = bhelppoorsamples.GetOptions(Province);   // bhelppoorsamples.GetAllIDAndName();

            string id = Request.QueryString["id"];
            if (id != null)
            {


                Data.Model.HelpPoorSamples helppoorsamplesid = bhelppoorsamples.Get(id.ToInt32());
                if (helppoorsamplesid == null)
                {


                    helppoorsamplesid.Code = "";
                    helppoorsamplesid.Province = "";
                    helppoorsamplesid.AgentName = "";
                    helppoorsamplesid.AttechFile = "";
                    helppoorsamplesid.UserID = "";
                    helppoorsamplesid.AddTime = System.DateTime.Now;



                }
                else
                {
                    helppoorsamples = helppoorsamplesid;
                }

            }

            if (collection != null)
            {
                txtProvince = Request.Form["txtProvince"];
               
                AgentName = Request.Form["AgentName"];
                AttechFile = Request.Form["AttechFile"];

                ViewBag.Code = Code;
                ViewBag.txtProvince = txtProvince;
                ViewBag.AgentName = AgentName;
                ViewBag.AttechFile = AttechFile;

               
                if (!Request.Form["Select"].IsNullOrEmpty())
                {
                    List<Data.Model.HelpPoorSamples> lsthelppoorsamples = new List<Data.Model.HelpPoorSamples>();
                    
                    lsthelppoorsamples = bhelppoorsamples.GetTasks(Code, txtProvince, AgentName);
                    if (lsthelppoorsamples.Count > 0)
                    {
                        ViewBag.Script = "alert('该机构已经存在录入的凭据了，无需要再操作!');";
                    }

                }
                else
                {



                    if (!Request.Form["Save"].IsNullOrEmpty() && helppoorsamples != null)
                    {

                        Code = System.DateTime.UtcNow.ToLongTimeString();

                        helppoorsamples.Code = Code;
                        helppoorsamples.Province = txtProvince;
                        helppoorsamples.AgentName = AgentName;
                        helppoorsamples.AttechFile = AttechFile;
                        helppoorsamples.UserID = Business.Platform.Users.CurrentUserID.ToString();
                        helppoorsamples.AddTime = System.DateTime.Now;


                        bhelppoorsamples.Add(helppoorsamples);



                        Business.Platform.Log.Add("修改了凭证信息", helppoorsamples.Serialize());
                        ViewBag.Script = "alert('保存成功!');";
                    }
                    else
                    {
                        bhelppoorsamples.Update(helppoorsamples);
                        Business.Platform.Log.Add("修改了凭证信息", helppoorsamples.Serialize());
                        ViewBag.Script = "alert('保存成功!');";
                    }


                    ViewBag.Result = "OK";


                
                }

                

            }

            return View(bhelppoorsamples);
        }





       


        




    }
}
