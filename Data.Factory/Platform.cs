using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Factory
{
    public class Platform
    {
        public static Data.Interface.IAppLibrary GetAppLibraryInstance()
        {
            return new Data.MSSQL.AppLibrary();
        }

        public static Data.Interface.IDBConnection GetDBConnectionInstance()
        {
            return new Data.MSSQL.DBConnection();
        }

        public static Data.Interface.IDictionary GetDictionaryInstance()
        {
            return new Data.MSSQL.Dictionary();
        }

        public static Data.Interface.IRead_Log GetRead_LogInstance()
        {
            return new Data.MSSQL.Read_Log();
        }

        public static Data.Interface.ILog GetLogInstance()
        {
            return new Data.MSSQL.Log();
        }

        public static Data.Interface.IOrganize GetOrganizeInstance()
        {
            return new Data.MSSQL.Organize();
        }

        public static Data.Interface.IRole GetRoleInstance()
        {
            return new Data.MSSQL.Role();
        }

        public static Data.Interface.IRoleApp GetRoleAppInstance()
        {
            return new Data.MSSQL.RoleApp();
        }

        public static Data.Interface.IUsersApp GetUsersAppInstance()
        {
            return new Data.MSSQL.UsersApp();
        }

       
       

        public static Data.Interface.IUsers GetUsersInstance()
        {
            return new Data.MSSQL.Users();
        }

        public static Data.Interface.IReceiveDoc GetReceiveDocInstance()
        {
            return new Data.MSSQL.ReceiveDoc();
        }


        public static Data.Interface.INews GetNewsInstance()
        {
            return new Data.MSSQL.News();
        }


        public static Data.Interface.INewsArticle GetNewsArticleInstance()
        {
            return new Data.MSSQL.NewsArticle();
        }

        public static Data.Interface.INoteBook GetNoteBookInstance()
        {
            return new Data.MSSQL.NoteBook();
        }

        public static Data.Interface.IStickyNotes GetStickyNotesInstance()
        {
            return new Data.MSSQL.StickyNotes();
        }

      

        public static Data.Interface.IMeeting GetMeetingInstance()
        {
            return new Data.MSSQL.Meeting();
        }

        public static Data.Interface.IReports GetReportsInstance()
        {
            return new Data.MSSQL.Reports();
        }

        public static Data.Interface.IUsersInfo GetUsersInfoInstance()
        {
            return new Data.MSSQL.UsersInfo();
        }

        public static Data.Interface.IUsersRelation GetUsersRelationInstance()
        {
            return new Data.MSSQL.UsersRelation();
        }

        public static Data.Interface.IUsersRole GetUsersRoleInstance()
        {
            return new Data.MSSQL.UsersRole();
        }

        public static Data.Interface.IWorkFlow GetWorkFlowInstance()
        {
            return new Data.MSSQL.WorkFlow();
        }

        public static Data.Interface.IWorkFlowButtons GetWorkFlowButtonsInstance()
        {
            return new Data.MSSQL.WorkFlowButtons();
        }

        public static Data.Interface.IWorkFlowTask GetWorkFlowTaskInstance()
        {
            return new Data.MSSQL.WorkFlowTask();
        }

        public static Data.Interface.IWorkFlowData GetWorkFlowDataInstance()
        {
            return new Data.MSSQL.WorkFlowData();
        }

        public static Data.Interface.IWorkFlowComment GetWorkFlowCommentInstance()
        {
            return new Data.MSSQL.WorkFlowComment();
        }

        public static Data.Interface.IWorkFlowForm GetWorkFlowFormInstance()
        {
            return new Data.MSSQL.WorkFlowForm();
        }

        public static Data.Interface.IWorkGroup GetWorkGroupInstance()
        {
            return new Data.MSSQL.WorkGroup();
        }

        public static Data.Interface.IWorkFlowDelegation GetWorkFlowDelegationInstance()
        {
            return new Data.MSSQL.WorkFlowDelegation();
        }

        public static Data.Interface.IWorkFlowArchives GetWorkFlowArchivesInstance()
        {
            return new Data.MSSQL.WorkFlowArchives();
        }



        public static Data.Interface.IHelpPoorSamples GetHelpPoorSamplesInstance()
        {
            return new Data.MSSQL.HelpPoorSamples();
        }



        public static Data.Interface.IRepair GetRepairInstance()
        {
            return new Data.MSSQL.Repair();
        }

        public static Data.Interface.IReturnDocument GetReturnDocumentInstance()
        {
            return new Data.MSSQL.ReturnDocument();
        }

    }
}
