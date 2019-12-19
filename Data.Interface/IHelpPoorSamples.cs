using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IHelpPoorSamples
    {
        /// <summary>
        /// 新增
        /// </summary>
        int Add(Data.Model.HelpPoorSamples model);

        /// <summary>
        /// 更新
        /// </summary>
        int Update(Data.Model.HelpPoorSamples model);

        /// <summary>
        /// 查询所有记录
        /// </summary>
        List<Data.Model.HelpPoorSamples> GetAll();

        List<Data.Model.HelpPoorSamples> GetTasks(string Code = "", string Province = "", string AgentName = "");

        /// <summary>
        /// 查询单条记录
        /// </summary>
        Model.HelpPoorSamples Get(Int32 id);

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

