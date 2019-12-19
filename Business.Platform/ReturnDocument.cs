using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Collections;

namespace Business.Platform
{
    public class ReturnDocument
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IReturnDocument dataReturnDocument;
        public ReturnDocument()
        {
            this.dataReturnDocument = Data.Factory.Platform.GetReturnDocumentInstance();
        }
       
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReturnDocument> GetAll()
        {
            return dataReturnDocument.GetAll();

        }




        public List<Data.Model.ReturnDocumentTotal> GetReturnReportAll()
    {
        return dataReturnDocument.GetReturnReportAll();
    }

        public List<Data.Model.ReturnDocumentTotal> GetReturnReportAllPara(string starttime, string endtime)
        {
            return dataReturnDocument.GetReturnReportAllPara(starttime, endtime);
        }




        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReturnDocument> GetTasks(string Code = "", string Province = "", string ReturnAmount = "", string StartDate="",string EndDate="")
        {
            return dataReturnDocument.GetTasks(Code, Province, ReturnAmount, StartDate, EndDate);
        }

        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.ReturnDocument Get(Int32 id)
        {
            return dataReturnDocument.Get(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(Int32 id)
        {
            return dataReturnDocument.Delete(id);
        }
        /// <summary>
        /// 查询记录条数
        /// </summary>
        public long GetCount()
        {
            return dataReturnDocument.GetCount();
        }



        /// <summary>
        /// 查询所有ID和名称
        /// </summary>
        public Dictionary<string, string> GetAllIDAndName()
        {
            return dataReturnDocument.GetAllIDAndName();
        }


        public string GetOptions(string value = "")
        {
            var dicts = GetAllIDAndName();
            StringBuilder options = new StringBuilder();
            foreach (var dict in dicts.OrderBy(p => p.Value))
            {
                options.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", dict.Key,
                    dict.Key.ToString() == value ? "selected=\"selected\"" : "", dict.Value);
            }
            return options.ToString();
        }


    }
}


