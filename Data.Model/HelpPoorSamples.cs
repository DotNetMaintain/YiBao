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
        /// 排序
        /// </summary>
        [DisplayName("AttechFile")]
        public string AttechFile { get; set; }

        /// <summary>
        /// 系统备注
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
        /// 状态 0 正常 1 冻结
        /// </summary>
        [DisplayName("UserID")]
        public string UserID { get; set; }

       

    }
}
