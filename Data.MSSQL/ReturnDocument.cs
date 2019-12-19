using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class ReturnDocument : Data.Interface.IReturnDocument
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReturnDocument()
        {
        }
      
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Int32 id)
        {
            string sql = "DELETE FROM ReturnDocument WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,-1){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.ReturnDocument> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.ReturnDocument> List = new List<Data.Model.ReturnDocument>();
            Data.Model.ReturnDocument model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.ReturnDocument();
                model.ID = dataReader.GetInt32(0);
                model.Title = dataReader.GetString(1);
                model.AddTime = dataReader.GetDateTime(2);
                if (!dataReader.IsDBNull(3))
                    model.UserID = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.UserDept = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.StreetName = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.ReturnName = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.ReturnDateTime = dataReader.GetDateTime(7);
                if (!dataReader.IsDBNull(8))
                    model.ReturnAmount = dataReader.GetDouble(8);
                if (!dataReader.IsDBNull(9))
                    model.Reason = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    model.Remark = dataReader.GetString(10);

                List.Add(model);
            }
            return List;
        }




        private List<Data.Model.ReturnDocumentTotal> DataReaderTotalToList(SqlDataReader dataReader)
        {
            List<Data.Model.ReturnDocumentTotal> List = new List<Data.Model.ReturnDocumentTotal>();
            Data.Model.ReturnDocumentTotal model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.ReturnDocumentTotal();
                model.Name = dataReader.GetString(0);
                model.Begintime = dataReader.GetDateTime(1);
                model.Endtime = dataReader.GetDateTime(2);
                
                if (!dataReader.IsDBNull(3))
                    model.Fresequence = dataReader.GetInt32(3);

                List.Add(model);
            }
            return List;
        }


        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReturnDocument> GetAll()
        {
            string sql = "SELECT * FROM ReturnDocument";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.ReturnDocument> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }



        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReturnDocument> GetTasks(string streetname = "", string ReturnName = "", string ReturnAmount = "", string StartDate="", string EndDate="")
        {
            List<SqlParameter> parList = new List<SqlParameter>();
            StringBuilder sql = new StringBuilder(@"SELECT ReturnDocument.* FROM ReturnDocument 
INNER JOIN dbo.Dictionary ON ReturnDocument.StreetName=Dictionary.ID  WHERE 1=1");

            if (!streetname.IsNullOrEmpty())
            {
                sql.Append(" AND Dictionary.Title like @streetname");
                parList.Add(new SqlParameter("@streetname", SqlDbType.NVarChar, 50) { Value = "%" + streetname + "%" });
            }
            if (!ReturnName.IsNullOrEmpty())
            {


                sql.Append(" AND ReturnName like @ReturnName");
                parList.Add(new SqlParameter("@ReturnName", SqlDbType.NVarChar, 50) { Value = "%" + ReturnName + "%" });
            }

            if (!ReturnAmount.IsNullOrEmpty())
            {


                sql.Append(" AND ReturnAmount=@ReturnAmount");
                parList.Add(new SqlParameter("@ReturnAmount", SqlDbType.Float, 8) { Value = Convert.ToDouble(ReturnAmount) });
            }

            if (!StartDate.IsNullOrEmpty())
            {


                sql.Append(" AND ReturnDateTime>=@StartDate");
                parList.Add(new SqlParameter("@StartDate", SqlDbType.DateTime, -1) { Value = Convert.ToDateTime(StartDate) });
            }

            if (!EndDate.IsNullOrEmpty())
            {


                sql.Append(" AND ReturnDateTime<=@EndDate");
                parList.Add(new SqlParameter("@EndDate", SqlDbType.DateTime, -1) { Value = Convert.ToDateTime(EndDate) });
            }

           
           
            long count;
            int size = Utility.Tools.GetPageSize();
            int number = Utility.Tools.GetPageNumber();
            string sql1 = dbHelper.GetPaerSql(sql.ToString(), size, number, out count, parList.ToArray());
         //   pager = Utility.Tools.GetPagerHtml(count, size, number, query);


            SqlDataReader dataReader = dbHelper.GetDataReader(sql1, parList.ToArray());
            List<Data.Model.ReturnDocument> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }


        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM ReturnDocument";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.ReturnDocument Get(Int32 id)
        {
            string sql = "SELECT * FROM ReturnDocument WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,-1){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.ReturnDocument> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }


        /// <summary>
        /// 查询所有ID和名称
        /// </summary>
        public Dictionary<string, string> GetAllIDAndName()
        {
            string sql = "SELECT distinct Province ID, Province Name FROM dbo.ReturnDocument  ORDER BY Name";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            while (dataReader.Read())
            {
                dict.Add(dataReader.GetString(0), dataReader.GetString(1));
            }
            dataReader.Close();
            return dict;
        }







        /// <summary>
        /// 台帐交接报表
        /// 查询有条件的记录
        /// </summary>
        public List<Data.Model.ReturnDocumentTotal> GetReturnReportAll()
        {
            string sql = @"select dictionary.title as name,record.begintime as begintime,record.endtime as endtime,record.Fresequence as Fresequence
 from(
select StreetName,min(AddTime) as begintime,max(AddTime) as endtime,count(StreetName) as Fresequence from ReturnDocument
group by StreetName) as record inner join 
dictionary on record.StreetName=dictionary.id";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.ReturnDocumentTotal> List = DataReaderTotalToList(dataReader);
            dataReader.Close();
            return List;
        }






        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReturnDocumentTotal> GetReturnReportAllPara(string starttime, string endtime)
        {
            string sql = @"select dictionary.title as name,record.begintime as begintime,record.endtime as endtime,record.Fresequence as Fresequence
 from(
select StreetName,cast('{0}' as datetime) as begintime,cast('{1}' as datetime) as endtime,count(StreetName) as Fresequence from ReturnDocument where AddTime>='{0}' and AddTime<='{1}'
group by StreetName) as record inner join 
dictionary on record.StreetName=dictionary.id";

            sql = string.Format(sql, starttime, endtime);

            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.ReturnDocumentTotal> List = DataReaderTotalToList(dataReader);
            dataReader.Close();
            return List;
        }







      
    }
}

