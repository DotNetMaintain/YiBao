using System;
using System.Collections.Generic;

namespace Data.Interface
{
    public interface IHelpPoorSamples
    {
        /// <summary>
        /// ����
        /// </summary>
        int Add(Data.Model.HelpPoorSamples model);

        /// <summary>
        /// ����
        /// </summary>
        int Update(Data.Model.HelpPoorSamples model);

        /// <summary>
        /// ��ѯ���м�¼
        /// </summary>
        List<Data.Model.HelpPoorSamples> GetAll();

        List<Data.Model.HelpPoorSamples> GetTasks(string Code = "", string Province = "", string AgentName = "");

        /// <summary>
        /// ��ѯ������¼
        /// </summary>
        Model.HelpPoorSamples Get(Int32 id);

        /// <summary>
        /// ɾ��
        /// </summary>
        int Delete(Guid id);

        /// <summary>
        /// ��ѯ��¼����
        /// </summary>
        long GetCount();


        /// <summary>
        /// ��ѯ����ID������
        /// </summary>
        Dictionary<string, string> GetAllIDAndName();

    }
}

