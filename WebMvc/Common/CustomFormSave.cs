using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;



namespace WebMvc.Common
{
    public class CustomFormSave
    {



        public static object GetJson(Data.Model.WorkFlowCustomEventParams eventParams)
        {
            return new Data.MSSQL.DBHelper().GetDataTable("select * from users");
        }
        public static string QianShi(Data.Model.WorkFlowCustomEventParams eventParams)
        {
            string title = System.Web.HttpContext.Current.Request.Form["Title"];
            string Contents = System.Web.HttpContext.Current.Request.Form["Contents"];

            if (eventParams.InstanceID.IsInt())
            {
                string sql = "UPDATE TempTest_CustomForm SET Title=@Title,Contents=@Contents WHERE ID=@ID";
                SqlParameter[] parArray = { 
                             new SqlParameter("@Title", title),
                             new SqlParameter("@Contents", Contents),
                             new SqlParameter("@ID", eventParams.InstanceID.ToString())
                             };
                new Data.MSSQL.DBHelper().Execute(sql, parArray);
                return eventParams.InstanceID.ToString();
            }
            else
            {
                string sql = "INSERT INTO TempTest_CustomForm(Title,Contents,FlowCompleted) VALUES(@Title,@Contents,@FlowCompleted);SELECT SCOPE_IDENTITY();";
                SqlParameter[] parArray = { 
                             new SqlParameter("@Title", title),
                             new SqlParameter("@Contents", Contents),
                             new SqlParameter("@FlowCompleted", "0")
                             };
                return new Data.MSSQL.DBHelper().ExecuteScalar(sql, parArray);
            }
        }


        [ValidateInput(false)]
        public static string PetitionLetterForm_Save(Data.Model.WorkFlowCustomEventParams eventParams)
        {

            string title = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitName"];
            string VisitDate = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitDate"];
            if (VisitDate == null)
            {
                VisitDate = "";
            }
            string VisitCode = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitCode"];
            if (VisitCode == null)
            {
                VisitCode = "";
            }
            string VisitName = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitName"];
            string VisitSex = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitSex"];
            string VisitAge = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitAge"];
            string VisitID = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitID"];
            string OtherName = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_OtherName"];
            string OtherSex = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_OtherSex"];
            string OtherAge = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_OtherAge"];
            string OtherID = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_OtherID"];
            string Address = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_Address"];
            string Tel = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_Tel"];
            string Unit = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_Unit"];
            string ContactName = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_ContactName"];
            string ContactTel = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_ContactTel"];
            string VisitSituation = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitSituation"];
            string VisitMatters = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitMatters"];
            string VisitMattersRemark = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitMattersRemark"];
            string VisitRecord = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitRecord"];
            string VisitRecordRemark = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitRecordRemark"];
            string DealResult = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_DealResult"];
            if (DealResult == null)
            {
                DealResult = "";
            }
            string VoiceAccount = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VoiceAccount"];
            if (VoiceAccount == null)
            {
                VoiceAccount = "";
            }
            string VoiceNum = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VoiceNum"];
            if (VoiceNum == null)
            {
                VoiceNum = "";
            }
            string VoiceCopyNum = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VoiceCopyNum"];
            if (VoiceCopyNum == null)
            {
                VoiceCopyNum = "";
            }
            string WorkDate = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_WorkDate"];
            if (WorkDate == null)
            {
                WorkDate = "";
            }
            string PreDate = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_PreDate"];
            if (PreDate == null)
            {
                PreDate = "";
            }
            string Diagnosis = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_Diagnosis"];
            if (Diagnosis == null)
            {
                Diagnosis = "";
            }

            string SignFile = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_SignFile"];


            if (SignFile == null)
            {
                SignFile = "";
            }

            string FileAttech = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_FileAttech"];

            if (FileAttech == null)
            {
                FileAttech = "";
            }


            try
            {


                if (eventParams.InstanceID.IsInt())
                {
                    string sql = @"UPDATE TempTest_CustomForm SET FlowCompleted=0";


                    if (VisitName != "" && VisitName != null)
                    {
                        sql = sql + ",VisitName=@VisitName";
                    }
                    if (VisitSex != "" && VisitSex != null)
                    {
                        sql = sql + ",VisitSex=@VisitSex";
                    }
                    if (VisitAge != "" && VisitAge != null)
                    {
                        sql = sql + ",VisitAge=@VisitAge";
                    }
                    if (VisitID != "" && VisitID != null)
                    {
                        sql = sql + ",VisitID=@VisitID";
                    }
                    if (OtherName != "" && OtherName != null)
                    {
                        sql = sql + ",OtherName=@OtherName";
                    }
                    if (OtherSex != "" && OtherSex != null)
                    {
                        sql = sql + ",OtherSex=@OtherSex";
                    }
                    if (OtherAge != "" && OtherAge != null)
                    {
                        sql = sql + ",OtherAge=@OtherAge";
                    }
                    if (OtherID != "" && OtherID != null)
                    {
                        sql = sql + ",OtherID=@OtherID";
                    }
                    if (Address != "" && Address != null)
                    {
                        sql = sql + ",Address=@Address";
                    }
                    if (Tel != "" && Tel != null)
                    {
                        sql = sql + ",Tel=@Tel";
                    }
                    if (Unit != "" && Unit != null)
                    {
                        sql = sql + ",Unit=@Unit";
                    }
                    if (ContactName != "" && ContactName != null)
                    {
                        sql = sql + ",ContactName=@ContactName";
                    }
                    if (ContactTel != "" && ContactTel != null)
                    {
                        sql = sql + ",ContactTel=@ContactTel";
                    }
                    if (VisitSituation != "" && VisitSituation != null)
                    {
                        sql = sql + ",VisitSituation=@VisitSituation";
                    }
                    if (VisitMatters != "" && VisitMatters != null)
                    {
                        sql = sql + ",VisitMatters=@VisitMatters";
                    }
                    if (VisitMattersRemark != "" && VisitMattersRemark != null)
                    {
                        sql = sql + ",VisitMattersRemark=@VisitMattersRemark";
                    }
                    if (VisitRecord != "" && VisitRecord != null)
                    {
                        sql = sql + ",VisitRecord=@VisitRecord";
                    }
                    if (VisitRecordRemark != "" && VisitRecordRemark != null)
                    {
                        sql = sql + ",VisitRecordRemark=@VisitRecordRemark";
                    }
                    if (DealResult != "" && DealResult != null)
                    {
                        sql = sql + ",DealResult=@DealResult";
                    }
                    if (VoiceAccount != "" && VoiceAccount != null)
                    {
                        sql = sql + ",VoiceAccount=@VoiceAccount";
                    }
                    if (VoiceNum != "" && VoiceNum != null)
                    {
                        sql = sql + ",VoiceNum=@VoiceNum";
                    }
                    if (VoiceCopyNum != "" && VoiceCopyNum != null)
                    {
                        sql = sql + ",VoiceCopyNum=@VoiceCopyNum";
                    }
                    if (WorkDate != "" && WorkDate != null)
                    {
                        sql = sql + ",WorkDate=@WorkDate";
                    }
                    if (PreDate != "" && PreDate != null)
                    {
                        sql = sql + ",PreDate=@PreDate";
                    }
                    if (Diagnosis != "" && Diagnosis != null)
                    {
                        sql = sql + ",Diagnosis=@Diagnosis";
                    }
                    if (SignFile != "" && SignFile != null)
                    {
                        sql = sql + ",SignFile=@SignFile";
                    }
                    if (FileAttech != "" && FileAttech != null)
                    {
                        sql = sql + ",FileAttech=@FileAttech";
                    }

                    sql = sql + " WHERE ID=@ID";
                    List<SqlParameter> paralst = new List<SqlParameter>();

                    SqlParameter[] parArray = { };
                    paralst.Add(new SqlParameter("@ID", eventParams.InstanceID));

                    if (VisitName != "" && VisitName != null)
                    {
                        paralst.Add(new SqlParameter("@VisitName", VisitName));
                    }
                    if (VisitSex != "" && VisitSex != null)
                    {
                        paralst.Add(new SqlParameter("@VisitSex", VisitSex));
                    }
                    if (VisitAge != "" && VisitAge != null)
                    {
                        paralst.Add(new SqlParameter("@VisitAge", VisitAge));
                    }
                    if (VisitID != "" && VisitID != null)
                    {
                        paralst.Add(new SqlParameter("@VisitID", VisitID));
                    }
                    if (OtherName != "" && OtherName != null)
                    {
                        paralst.Add(new SqlParameter("@OtherName", OtherName));
                    }
                    if (OtherSex != "" && OtherSex != null)
                    {
                        paralst.Add(new SqlParameter("@OtherSex", OtherSex));
                    }
                    if (OtherAge != "" && OtherAge != null)
                    {
                        paralst.Add(new SqlParameter("@OtherAge", OtherAge));
                    }
                    if (OtherID != "" && OtherID != null)
                    {
                        paralst.Add(new SqlParameter("@OtherID", OtherID));
                    }
                    if (Address != "" && Address != null)
                    {
                        paralst.Add(new SqlParameter("@Address", Address));
                    }
                    if (Tel != "" && Tel != null)
                    {
                        paralst.Add(new SqlParameter("@Tel", Tel));
                    }
                    if (Unit != "" && Unit != null)
                    {
                        paralst.Add(new SqlParameter("@Unit", Unit));
                    }
                    if (ContactName != "" && ContactName != null)
                    {
                        paralst.Add(new SqlParameter("@ContactName", ContactName));
                    }
                    if (ContactTel != "" && ContactTel != null)
                    {
                        paralst.Add(new SqlParameter("@ContactTel", ContactTel));
                    }
                    if (VisitSituation != "" && VisitSituation != null)
                    {
                        paralst.Add(new SqlParameter("@VisitSituation", VisitSituation));
                    }
                    if (VisitMatters != "" && VisitMatters != null)
                    {
                        paralst.Add(new SqlParameter("@VisitMatters", VisitMatters));
                    }
                    if (VisitMattersRemark != "" && VisitMattersRemark != null)
                    {
                        paralst.Add(new SqlParameter("@VisitMattersRemark", VisitMattersRemark));
                    }
                    if (VisitRecord != "" && VisitRecord != null)
                    {
                        paralst.Add(new SqlParameter("@VisitRecord", VisitRecord));
                    }
                    if (VisitRecordRemark != "" && VisitRecordRemark != null)
                    {
                        paralst.Add(new SqlParameter("@VisitRecordRemark", VisitRecordRemark));
                    }
                    if (DealResult != "" && DealResult != null)
                    {
                        paralst.Add(new SqlParameter("@DealResult", DealResult));
                    }
                    if (VoiceAccount != "" && VoiceAccount != null)
                    {
                        paralst.Add(new SqlParameter("@VoiceAccount", VoiceAccount));
                    }
                    if (VoiceNum != "" && VoiceNum != null)
                    {
                        paralst.Add(new SqlParameter("@VoiceNum", VoiceNum));
                    }
                    if (VoiceCopyNum != "" && VoiceCopyNum != null)
                    {
                        paralst.Add(new SqlParameter("@VoiceCopyNum", VoiceCopyNum));
                    }
                    if (WorkDate != "" && WorkDate != null)
                    {
                        paralst.Add(new SqlParameter("@WorkDate", WorkDate));
                    }
                    if (PreDate != "" && PreDate != null)
                    {
                        paralst.Add(new SqlParameter("@PreDate", PreDate));
                    }
                    if (Diagnosis != "" && Diagnosis != null)
                    {
                        paralst.Add(new SqlParameter("@Diagnosis", Diagnosis));
                    }
                    if (SignFile != "" && SignFile != null)
                    {
                        paralst.Add(new SqlParameter("@SignFile", SignFile));
                    }
                    if (FileAttech != "" && FileAttech != null)
                    {
                        paralst.Add(new SqlParameter("@FileAttech", FileAttech));
                    }

                    parArray = paralst.ToArray();



                    new Data.MSSQL.DBHelper().Execute(sql, parArray);
                    return eventParams.InstanceID.ToString();
                }
                else
                {
                    string sql = "INSERT INTO TempTest_CustomForm(VisitDate,VisitCode,Title,VisitName,VisitSex,VisitAge,VisitID,OtherName,OtherSex,OtherAge,OtherID,Address,Tel,Unit,ContactName,ContactTel,VisitSituation,VisitMatters,VisitMattersRemark,VisitRecord,VisitRecordRemark,DealResult,FlowCompleted,VoiceAccount,VoiceNum,VoiceCopyNum,WorkDate,PreDate,Diagnosis,SignFile,FileAttech) VALUES(@VisitDate,@VisitCode,@Title,@VisitName,@VisitSex,@VisitAge,@VisitID,@OtherName,@OtherSex,@OtherAge,@OtherID,@Address,@Tel,@Unit,@ContactName,@ContactTel,@VisitSituation,@VisitMatters,@VisitMattersRemark,@VisitRecord,@VisitRecordRemark,@DealResult,@FlowCompleted,@VoiceAccount,@VoiceNum,@VoiceCopyNum,@WorkDate,@PreDate,@Diagnosis,@SignFile,@FileAttech);SELECT SCOPE_IDENTITY();";
                    SqlParameter[] parArray = { 
                             new SqlParameter("@VisitDate", VisitDate),
                             new SqlParameter("@VisitCode", VisitCode),
                             new SqlParameter("@Title", title),  
                             new SqlParameter("@VisitName", VisitName),
                             new SqlParameter("@VisitSex", VisitSex),
                             new SqlParameter("@VisitAge", VisitAge),
                             new SqlParameter("@VisitID", VisitID),
                             new SqlParameter("@OtherName", OtherName),
                             new SqlParameter("@OtherSex", OtherSex),
                             new SqlParameter("@OtherAge", OtherAge),
                             new SqlParameter("@OtherID", OtherID),
                             new SqlParameter("@Address", Address),
                             new SqlParameter("@Tel", Tel),
                             new SqlParameter("@Unit", Unit),
                             new SqlParameter("@ContactName", ContactName),
                             new SqlParameter("@ContactTel", ContactTel),
                             new SqlParameter("@VisitSituation", VisitSituation),
                             new SqlParameter("@VisitMatters", VisitMatters),
                             new SqlParameter("@VisitMattersRemark", VisitMattersRemark),
                             new SqlParameter("@VisitRecord", VisitRecord),
                             new SqlParameter("@VisitRecordRemark", VisitRecordRemark),
                             new SqlParameter("@DealResult", DealResult),
                             new SqlParameter("@FlowCompleted", "0"),
                             new SqlParameter("@VoiceAccount", VoiceAccount),
                             new SqlParameter("@VoiceNum", VoiceNum),
                             new SqlParameter("@VoiceCopyNum", VoiceCopyNum),
                             new SqlParameter("@WorkDate", WorkDate),
                             new SqlParameter("@PreDate", PreDate),
                             new SqlParameter("@Diagnosis", Diagnosis),
                             new SqlParameter("@SignFile", SignFile),
                             new SqlParameter("@FileAttech", FileAttech)
                            
                             };
                    return new Data.MSSQL.DBHelper().ExecuteScalar(sql, parArray);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }



        public static string EffectTimer(Data.Model.WorkFlowCustomEventParams eventParams)
        {
            string title = System.Web.HttpContext.Current.Request.Form["Title"];
            string UserID = System.Web.HttpContext.Current.Request.Form["EffectTimer.UserID"];
            string BunessType = System.Web.HttpContext.Current.Request.Form["EffectTimer.BunessType"];
            string StartTime = System.Web.HttpContext.Current.Request.Form["EffectTimer.StartTime"];
            string EndTime = System.Web.HttpContext.Current.Request.Form["EffectTimer.EndTime"];

            if (eventParams.InstanceID.IsInt())
            {
                string sql = "UPDATE EffectTimer SET Title=@Title,UserID=@UserID,BunessType=@BunessType,StartTime=@StartTime,EndTime=@EndTime WHERE ID=@ID";
                SqlParameter[] parArray = { 
                             new SqlParameter("@Title", title),
                             new SqlParameter("@UserID", UserID),
                             new SqlParameter("@BunessType", BunessType),
                             new SqlParameter("@StartTime", StartTime),
                             new SqlParameter("@EndTime", EndTime),
                             new SqlParameter("@ID", eventParams.InstanceID.ToString())
                             };
                new Data.MSSQL.DBHelper().Execute(sql, parArray);
                return eventParams.InstanceID.ToString();
            }
            else
            {
                string sql = "INSERT INTO EffectTimer(Title,UserID,BunessType,StartTime,EndTime) VALUES(@Title,@UserID,@BunessType,@StartTime,@EndTime);SELECT SCOPE_IDENTITY();";
                SqlParameter[] parArray = { 
                             new SqlParameter("@Title", title),
                             new SqlParameter("@UserID", UserID),
                             new SqlParameter("@BunessType", BunessType),
                             new SqlParameter("@StartTime", StartTime),
                             new SqlParameter("@EndTime", EndTime),
                             new SqlParameter("@ID", eventParams.InstanceID.ToString())
                             };
                return new Data.MSSQL.DBHelper().ExecuteScalar(sql, parArray);
            }
        }






        [ValidateInput(false)]
        public static string InjuryTotal_Save(Data.Model.WorkFlowCustomEventParams eventParams)
        {

            string title = System.Web.HttpContext.Current.Request.Form["TempTest_CustomForm_VisitName"];
            string AddTime = System.Web.HttpContext.Current.Request.Form["AddTime"];

            string num = string.Empty;
            string name = string.Empty;
            string numname = string.Empty;
            string n_name = string.Empty;
            for (int i = 1; i < 7; i++)
            {

                numname = "InjuryTotal.num" + i.ToString();
                num = System.Web.HttpContext.Current.Request.Form[numname];
                n_name = "InjuryTotal.name" + i.ToString();
                name = System.Web.HttpContext.Current.Request.Form[n_name];


                try
                {
                    string sql = "INSERT INTO dbo.InjuryTotal(AddTime,username,num) VALUES(@AddTime,@username,@num);";
                    SqlParameter[] parArray = { 
                             new SqlParameter("@AddTime", AddTime),
                             new SqlParameter("@username", name),
                             new SqlParameter("@num", num)
                            
                             };
                    return new Data.MSSQL.DBHelper().ExecuteScalar(sql, parArray);
                }



                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }



            }


            return "0";



        }








    }
}