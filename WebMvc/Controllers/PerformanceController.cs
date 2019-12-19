using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Utility;
using System.Data;
using System.Data.SqlClient;

namespace WebMvc.Controllers
{
    public class PerformanceController : Controller
    {
        //
        // GET: /Performance_Factor_Score/
        public ActionResult Performance_Factor_Score()
        {
            return Performance_Factor_Score(null);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Performance_Factor_Score(FormCollection collection)
        {
            string starttime = Request.Form["starttime"];
            string endtime = Request.Form["endtime"];
            ViewBag.starttime = starttime;
            ViewBag.endtime = endtime;
            
            return View();
        }

        public ActionResult StreetPerformance_Factor_Score()
        {
            return View();
        }



       

        //导入万达Excel数据
        public ActionResult ImportPerformance()
        {
           


            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportPerformance(FormCollection collection)
        {


            System.Data.DataTable dtScore = new System.Data.DataTable();
            if (Request.Form["Search"]!=null)
            {
                string starttime = Request.Form["starttime"];
                string endtime = Request.Form["endtime"];
                ViewBag.starttime = starttime;
                ViewBag.endtime = endtime;

                if (!string.IsNullOrEmpty(starttime))
                {
                    starttime = starttime.Substring(0, 4) + starttime.Substring(5, 2);

                }

                if (!string.IsNullOrEmpty(endtime))
                {
                    endtime = endtime.Substring(0, 4) + endtime.Substring(5, 2);

                }
                string sql = @"select * from Performance_Score where startdate>='{0}' and enddate<='{1}'";
                sql = string.Format(sql, starttime, endtime);
                Data.MSSQL.DBHelper dbHelper = new Data.MSSQL.DBHelper();
                dtScore = dbHelper.GetDataTable(sql);
                return View(dtScore);

            }



            HttpPostedFileBase postFile = Request.Files["fileName"];

            if (postFile == null)
            {

                return Content("没有文件！", "text/plain");

            }
            string baseUrl = Server.MapPath("/");
            string uploadPath = baseUrl + @"Content\UploadFiles\";
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetFileName(postFile.FileName);
            if (fileName != "")
            {

                postFile.SaveAs(uploadPath + fileName);
            }


            // uploadStream = postFile.InputStream;




            //    fs = new FileStream(uploadPath + fileName, FileMode.Create, FileAccess.ReadWrite);  
            ExcelToData etd = new ExcelToData();
            System.Data.DataSet ds = etd.GetDataSet(uploadPath, fileName);
            if (ds != null)
            {

                //存入数据库中


                Data.MSSQL.DBHelper dbHelper = new Data.MSSQL.DBHelper();


                string checksql = @"select * from Performance_Score where startdate='{0}'";
                checksql = string.Format(checksql, ds.Tables[0].Rows[0][0].ToString());
                DataTable dt = dbHelper.GetDataTable(checksql);
                if (dt != null && dt.Rows.Count>0)
                {
                    //View.Script = "";
                    return View();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    string sql = @"INSERT INTO Performance_Score
				(StartDate,EndDate,User_Name,Performance_001,Performance_002,Performance_003,Performance_004,Performance_005,Performance_006,Performance_007,Performance_008,Performance_009,Performance_010,Performance_011,Performance_012,Performance_013,Performance_014,Performance_015,Performance_016,Performance_017,Performance_018,Performance_019,Performance_020,Performance_021,Performance_022,Performance_023,Performance_024,Performance_025,Performance_026,Performance_027,Performance_028,Performance_029,Performance_030,Performance_031,Performance_032) 
				VALUES(@StartDate,@EndDate,@User_Name,@Performance_001,@Performance_002,@Performance_003,@Performance_004,@Performance_005,@Performance_006,@Performance_007,@Performance_008,@Performance_009,@Performance_010,@Performance_011,@Performance_012,@Performance_013,@Performance_014,@Performance_015,@Performance_016,@Performance_017,@Performance_018,@Performance_019,@Performance_020,@Performance_021,@Performance_022,@Performance_023,@Performance_024,@Performance_025,@Performance_026,@Performance_027,@Performance_028,@Performance_029,@Performance_030,@Performance_031,@Performance_032)";
                    SqlParameter[] parameters = new SqlParameter[]{
				
				new SqlParameter("@StartDate", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][0].ToString()},
                new SqlParameter("@EndDate", SqlDbType.VarChar,50){ Value =ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@User_Name", SqlDbType.VarChar, 50){ Value = ds.Tables[0].Rows[i][2].ToString()},
				new SqlParameter("@Performance_001", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][3].ToString() },
                new SqlParameter("@Performance_002", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][4].ToString() },
                new SqlParameter("@Performance_003", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][5].ToString() },
                new SqlParameter("@Performance_004", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][6].ToString() },
                new SqlParameter("@Performance_005", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][7].ToString() },
                new SqlParameter("@Performance_006", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][8].ToString() },
                new SqlParameter("@Performance_007", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][9].ToString() },
                new SqlParameter("@Performance_008", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][10].ToString() },
                new SqlParameter("@Performance_009", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][11].ToString() },
                new SqlParameter("@Performance_010", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][12].ToString() },
                new SqlParameter("@Performance_011", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][13].ToString() },
                new SqlParameter("@Performance_012", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][14].ToString() },
                new SqlParameter("@Performance_013", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][15].ToString() },
                new SqlParameter("@Performance_014", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][16].ToString() },
                new SqlParameter("@Performance_015", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][17].ToString() },
                new SqlParameter("@Performance_016", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][18].ToString() },
                new SqlParameter("@Performance_017", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][19].ToString() },
                new SqlParameter("@Performance_018", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][20].ToString() },
                new SqlParameter("@Performance_019", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][21].ToString() },
                new SqlParameter("@Performance_020", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][22].ToString() },
                new SqlParameter("@Performance_021", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][23].ToString() },
                new SqlParameter("@Performance_022", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][24].ToString() },
                new SqlParameter("@Performance_023", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][25].ToString() },
                new SqlParameter("@Performance_024", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][26].ToString() },
                new SqlParameter("@Performance_025", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][27].ToString() },
                new SqlParameter("@Performance_026", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][28].ToString() },
                new SqlParameter("@Performance_027", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][29].ToString() },
                new SqlParameter("@Performance_028", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][30].ToString() },
                new SqlParameter("@Performance_029", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][31].ToString() },
                new SqlParameter("@Performance_030", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][32].ToString() },
                new SqlParameter("@Performance_031", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][33].ToString() },
                new SqlParameter("@Performance_032", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][34].ToString() }
            };

                    dbHelper.Execute(sql, parameters);


                }



                ViewBag.Script = "alert('导入成功!');";


            }







            return View();
        }




        //导入帮困数据
        public ActionResult ImportHelpPoor()
        {
            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ImportHelpPoor(FormCollection collection)
        {

            System.Data.DataTable dt = new System.Data.DataTable();
            if (Request.Form["Search"] != null)
            { 
            
            
            if (!string.IsNullOrEmpty(Request.Form["Search"].ToString()))
            {
                string starttime = Request.Form["starttime"];
                string endtime = Request.Form["endtime"];
                ViewBag.starttime = starttime;
                ViewBag.endtime = endtime;
                string sql = @"select * from HelpPoor where HelpPoorDate>='{0}' and HelpPoorDate<='{1}'";
                sql = string.Format(sql, starttime, endtime);
                Data.MSSQL.DBHelper dbHelper = new Data.MSSQL.DBHelper();
                dt = dbHelper.GetDataTable(sql);
                return View(dt);

            }
            }


           
            HttpPostedFileBase postFile = Request.Files["fileName"];

            if (postFile == null)
            {

                return Content("没有文件！", "text/plain");

            }
            string baseUrl = Server.MapPath("/");
           string uploadPath = baseUrl + @"Content\UploadFiles\";  
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssff")+Path.GetFileName(postFile.FileName); 
            if (fileName != "")
            {

                postFile.SaveAs(uploadPath + fileName);
            }


           // uploadStream = postFile.InputStream;


             
           
       //    fs = new FileStream(uploadPath + fileName, FileMode.Create, FileAccess.ReadWrite);  
            ExcelToData etd=new ExcelToData ();
            System.Data.DataSet ds = etd.GetDataSet(uploadPath, fileName);
            if (ds !=null)
            {

                //存入数据库中


                Data.MSSQL.DBHelper dbHelper = new  Data.MSSQL.DBHelper();

                for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                {

                    string sql = @"INSERT INTO HelpPoor
				(HelpPoorDate,StreetName,StreetAccount) 
				VALUES(@HelpPoorDate,@StreetName,@StreetAccount)";
                    SqlParameter[] parameters = new SqlParameter[]{
				
				new SqlParameter("@HelpPoorDate", SqlDbType.DateTime){ Value =ds.Tables[0].Rows[i][0].ToString().ToDateTime()},
				new SqlParameter("@StreetName", SqlDbType.VarChar, 50){ Value = ds.Tables[0].Rows[i][1].ToString()},
				new SqlParameter("@StreetAccount", SqlDbType.Float){ Value = ds.Tables[0].Rows[i][2].ToString() }
            };

                dbHelper.Execute(sql, parameters);


                }


                ViewBag.Script = "alert('导入成功!');";
     


            }

  



            

            return View();
        }








    }
}
