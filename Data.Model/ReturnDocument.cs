using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class ReturnDocument
    {

        private DateTime _AddTime; // 
        private DateTime _ReturnDateTime; // 


        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public Int32  ID { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [DisplayName("Title")]
        public string Title { get; set; }

        /// <summary>
        /// UserDept
        /// </summary>
        [DisplayName("UserDept")]
        public string UserDept { get; set; }

        /// <summary>
        /// StreetName
        /// </summary>
        [DisplayName("StreetName")]
        public string StreetName { get; set; }

        /// <summary>
        /// ReturnName
        /// </summary>
        [DisplayName("ReturnName")]
        public string ReturnName { get; set; }


        /// <summary>
        /// 系统时间
        /// </summary>
        [DisplayName("ReturnDateTime")]
        public DateTime ReturnDateTime
        {
            get { return _ReturnDateTime; }
            set
            {
                _ReturnDateTime = value;
            }
        }


        /// <summary>
        /// ReturnAmount
        /// </summary>
        [DisplayName("ReturnAmount")]
        public double ReturnAmount { get; set; }


        /// <summary>
        /// Reason
        /// </summary>
        [DisplayName("Reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Remark
        /// </summary>
        [DisplayName("Remark")]
        public string Remark { get; set; }

        /// <summary>
        /// 系统时间
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
