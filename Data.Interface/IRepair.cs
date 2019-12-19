using System;
using System.Collections.Generic;


namespace Data.Interface
{
    public interface IRepair
    {
     

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.Repair> GetAll();

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.Repair Get(Int32 id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Int32 id);

        /// <summary>
        /// 查询记录条数
        /// </summary>
        long GetCount();




    }
}



