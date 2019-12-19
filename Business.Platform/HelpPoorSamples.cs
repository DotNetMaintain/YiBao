using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Collections;

namespace Business.Platform
{
    public class HelpPoorSamples
    {
        /// <summary>
        /// ǰ׺
        /// </summary>
        public const string PREFIX = "u_";
        private Data.Interface.IHelpPoorSamples dataHelpPoorSamples;
        public HelpPoorSamples()
        {
            this.dataHelpPoorSamples = Data.Factory.Platform.GetHelpPoorSamplesInstance();
        }
        /// <summary>
        /// ����
        /// </summary>
        public int Add(Data.Model.HelpPoorSamples model)
        {
            return dataHelpPoorSamples.Add(model);
        }
        /// <summary>
        /// ����
        /// </summary>
        public int Update(Data.Model.HelpPoorSamples model)
        {
            return dataHelpPoorSamples.Update(model);
        }
        /// <summary>
        /// ��ѯ���м�¼
        /// </summary>
        public List<Data.Model.HelpPoorSamples> GetAll()
        {
            return dataHelpPoorSamples.GetAll();
        }


        /// <summary>
        /// ��ѯ���м�¼
        /// </summary>
        public List<Data.Model.HelpPoorSamples> GetTasks(string Code = "", string Province = "", string AgentName = "")
        {
            return dataHelpPoorSamples.GetTasks(Code, Province, AgentName);
        }

        /// <summary>
        /// ��ѯ������¼
        /// </summary>
        public Data.Model.HelpPoorSamples Get(Int32 id)
        {
            return dataHelpPoorSamples.Get(id);
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        public int Delete(Guid id)
        {
            return dataHelpPoorSamples.Delete(id);
        }
        /// <summary>
        /// ��ѯ��¼����
        /// </summary>
        public long GetCount()
        {
            return dataHelpPoorSamples.GetCount();
        }



        /// <summary>
        /// ��ѯ����ID������
        /// </summary>
        public Dictionary<string, string> GetAllIDAndName()
        {
            return dataHelpPoorSamples.GetAllIDAndName();
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

