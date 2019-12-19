using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IReceiveDoc
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.ReceiveDoc model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.ReceiveDoc model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.ReceiveDoc> GetAll();

        List<Data.Model.ReceiveDoc> GetTasks(string DocumentType = "", string DocumentLevel = "", string DocumentTitle = "", string DocumentCode = "", string DocumentUnit = "", string AddTime = "");

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.ReceiveDoc Get(Int32 id);

        /// <summary>
        /// 删除
        /// </summary>
        int Delete(Guid id);

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

