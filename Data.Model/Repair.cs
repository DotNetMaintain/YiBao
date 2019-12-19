using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Data.Model
{

    [Serializable]
    public class Repair
    {
        private int _id; //  
        private string _Title; //  
        private string _name; //  
        private string _type; // 
        private string _quantity; // 
        private DateTime _AddTime; //
        private string _UserID; //  
        private string _remark; //  


        /// <summary>
        ///
        /// </summary>  
        public int id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new Exception("id不能为空");
                }
               
                _id = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string Title
        {
            get { return _Title; }
            set
            {

                _Title = value;
            }
        }

        /// <summary>
        ///
        /// </summary>  
        public string name
        {
            get { return _name; }
            set
            {

                _name = value;
            }
        }




        /// <summary>
        ///
        /// </summary>  
        public string type
        {
            get { return _type; }
            set
            {

                _type = value;
            }
        }



        /// <summary>
        ///
        /// </summary>  
        public string quantity
        {
            get { return _quantity; }
            set
            {

                _quantity = value;
            }
        }




        /// <summary>
        ///
        /// </summary>  
        public string UserID
        {
            get { return _UserID; }
            set
            {
                
                _UserID = value;
            }
        }

       
        /// <summary>
        ///
        /// </summary>  
        public DateTime AddTime
        {
            get { return _AddTime; }
            set
            {
                _AddTime = value;
            }
        }



        /// <summary>
        ///
        /// </summary>  
        public string remark
        {
            get { return _remark; }
            set
            {

                _remark = value;
            }
        }



      
    }
}

