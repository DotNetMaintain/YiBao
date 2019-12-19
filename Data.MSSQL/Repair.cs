using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class Repair : Data.Interface.IRepair
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public Repair()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Repair实体类</param>
        /// <returns>操作所影响的行数</returns>
     
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Repair实体类</param>
    
       
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Int32 id)
        {
            string sql = "DELETE FROM Repair WHERE id=@id";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@id",SqlDbType.Int,-1) { Value =id} 
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.Repair> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.Repair> List = new List<Data.Model.Repair>();
            Data.Model.Repair model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.Repair();
                model.id = dataReader.GetInt32(0);
                model.Title = dataReader.GetString(1);
                model.name = dataReader.GetString(2);
                model.type = dataReader.GetString(3);

                if (!dataReader.IsDBNull(4))
                    model.quantity = dataReader.GetString(4);
                
               
                model.AddTime = dataReader.GetDateTime(5);

                if (!dataReader.IsDBNull(6))
                    model.UserID = dataReader.GetString(6);

                if (!dataReader.IsDBNull(7))
                    model.remark = dataReader.GetString(7);

                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.Repair> GetAll()
        {
            string sql = "SELECT * from Repair order by AddTime desc";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.Repair> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM Repair";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.Repair Get(Int32 id)
        {
            string sql = "SELECT * FROM Repair WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,4){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.Repair> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }

      
    }
}

