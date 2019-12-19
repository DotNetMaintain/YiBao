using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class ReceiveDoc
    {

        private DateTime _AddTime; // 


        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public Guid  ID { get; set; }

        /// <summary>
        /// 收文标题
        /// </summary>
        [DisplayName("DocumentTitle")]
        public string DocumentTitle { get; set; }

        /// <summary>
        /// 收文类型
        /// </summary>
        [DisplayName("DocumentType")]
        public string DocumentType { get; set; }

        /// <summary>
        /// 收文密级
        /// </summary>
        [DisplayName("DocumentLevel")]
        public string DocumentLevel { get; set; }

        /// <summary>
        /// 收文文号
        /// </summary>
        [DisplayName("DocumentCode")]
        public string DocumentCode { get; set; }


        /// <summary>
        /// 收文时间
        /// </summary>
        [DisplayName("ReceiveDate")]
        public string ReceiveDate { get; set; }


        /// <summary>
        /// 收文序号
        /// </summary>
        [DisplayName("DocumentNum")]
        public string DocumentNum { get; set; }


        /// <summary>
        /// 收文附件
        /// </summary>
        [DisplayName("DocumentAttech")]
        public string DocumentAttech { get; set; }


        /// <summary>
        /// 来文单位
        /// </summary>
        [DisplayName("DocumentUnit")]
        public string DocumentUnit { get; set; }

        /// <summary>
        /// 添加文件时间
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
        ///添加文件人员
        /// </summary>
        [DisplayName("UserID")]
        public string UserID { get; set; }

       

    }
}
