using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class HelpPoorSamples
    {

        private DateTime _AddTime; // 


        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public Int32  ID { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [DisplayName("Code")]
        public string Code { get; set; }

        /// <summary>
        /// Account
        /// </summary>
        [DisplayName("Province")]
        public string Province { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [DisplayName("AgentName")]
        public string AgentName { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [DisplayName("AttechFile")]
        public string AttechFile { get; set; }

        /// <summary>
        /// ϵͳ��ע
        /// </summary>
        [DisplayName("AddTime")]
        public DateTime AddTime
        {
            get { return _AddTime; }
            set
            {
                _AddTime = value;
            }
        }

        /// <summary>
        /// ״̬ 0 ���� 1 ����
        /// </summary>
        [DisplayName("UserID")]
        public string UserID { get; set; }

       

    }
}
