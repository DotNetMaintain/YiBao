using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Collections;

namespace Business.Platform
{
    public class ReceiveDoc
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IReceiveDoc dataReceiveDoc;
        public ReceiveDoc()
        {
            this.dataReceiveDoc = Data.Factory.Platform.GetReceiveDocInstance();
        }
        /// <summary>
        /// 新增
        /// </summary>
        public int Add(Data.Model.ReceiveDoc model)
        {
            return dataReceiveDoc.Add(model);
        }
        /// <summary>
        /// 更新
        /// </summary>
        public int Update(Data.Model.ReceiveDoc model)
        {
            return dataReceiveDoc.Update(model);
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReceiveDoc> GetAll()
        {
            return dataReceiveDoc.GetAll();
        }


        /// <summary>
        /// 查询所有记录
        /// </summary>
        /// 
        
        public List<Data.Model.ReceiveDoc> GetTasks(string DocumentType = "", string DocumentLevel = "", string DocumentTitle = "",string DocumentCode="",string DocumentUnit="",string AddTime="")
        {
            return dataReceiveDoc.GetTasks(DocumentType, DocumentLevel, DocumentTitle, DocumentCode, DocumentUnit, AddTime);
        }

        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.ReceiveDoc Get(Int32 id)
        {
            return dataReceiveDoc.Get(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(Guid id)
        {
            return dataReceiveDoc.Delete(id);
        }
        /// <summary>
        /// 查询记录条数
        /// </summary>
        public long GetCount()
        {
            return dataReceiveDoc.GetCount();
        }



        /// <summary>
        /// 查询所有ID和名称
        /// </summary>
        public Dictionary<string, string> GetAllIDAndName()
        {
            return dataReceiveDoc.GetAllIDAndName();
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


