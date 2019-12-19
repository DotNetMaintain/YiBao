using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Platform
{
    public class Repair
    {
        /// <summary>
        /// 前缀
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IRepair dataNews;
        public Repair()
        {
            this.dataNews = Data.Factory.Platform.GetRepairInstance();

        }
       
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Repair> GetAll()
        {
            return dataNews.GetAll();
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        public Data.Model.Repair Get(Int32 id)
        {
            return dataNews.Get(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public int Delete(Int32 id)
        {
            return dataNews.Delete(id);
        }
        /// <summary>
        /// 查询记录条数
        /// </summary>
        public long GetCount()
        {
            return dataNews.GetCount();
        }


    }
}



