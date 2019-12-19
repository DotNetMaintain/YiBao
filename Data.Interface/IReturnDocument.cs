using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IReturnDocument
    {
        
        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.ReturnDocument> GetAll();

        List<Data.Model.ReturnDocumentTotal> GetReturnReportAll();

        List<Data.Model.ReturnDocumentTotal> GetReturnReportAllPara(string starttime, string endtime);

        List<Data.Model.ReturnDocument> GetTasks(string streetname = "", string ReturnName = "", string ReturnAmount = "", string StartDate="", string EndDate="");

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.ReturnDocument Get(Int32 id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Int32 id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();


        /// <summary>
        /// 查询所有ID和名称
        /// </summary>
        Dictionary<string, string> GetAllIDAndName();

    }
}


