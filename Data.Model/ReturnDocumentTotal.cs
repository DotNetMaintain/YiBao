using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    [Serializable]
    public class ReturnDocumentTotal
    {

        private DateTime _AddTime; // 
        private DateTime _Begintime; // 
        private DateTime _Endtime; // 
      


       
        /// <summary>
        /// Title
        /// </summary>
        [DisplayName("Name")]
        public string Name { get; set; }

       


        /// <summary>
        /// 系统时间
        /// </summary>
        [DisplayName("Begintime")]
        public DateTime Begintime
        {
            get { return _Begintime; }
            set
            {
                _Begintime = value;
            }
        }


        /// <summary>
        /// 系统时间
        /// </summary>
        [DisplayName("Endtime")]
        public DateTime Endtime
        {
            get { return _Endtime; }
            set
            {
                _Endtime = value;
            }
        }

        /// <summary>
        /// StreetName
        /// </summary>
        [DisplayName("StreetName")]
        public string StreetName { get; set; }



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
        [DisplayName("Fresequence")]
        public Int32 Fresequence { get; set; }



    }
}
