using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class HelpPoorSamples : Data.Interface.IHelpPoorSamples
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// ���캯��
        /// </summary>
        public HelpPoorSamples()
        {
        }
        /// <summary>
        /// ��Ӽ�¼
        /// </summary>
        /// <param name="model">Data.Model.Usersʵ����</param>
        /// <returns>������Ӱ�������</returns>
        public int Add(Data.Model.HelpPoorSamples model)
        {
            string sql = @"INSERT INTO dbo.HelpPoorSamples
				(Code,Province,AgentName,AttechFile,AddTime,UserID) 
				VALUES(@Code,@Province,@AgentName,@AttechFile,@AddTime,@UserID)";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@Code", SqlDbType.NVarChar, 50){ Value = model.Code },
				new SqlParameter("@Province", SqlDbType.VarChar, 50){ Value = model.Province },
				new SqlParameter("@AgentName", SqlDbType.VarChar, 50){ Value = model.AgentName },
				new SqlParameter("@AttechFile", SqlDbType.VarChar, 500){ Value = model.AttechFile },
				new SqlParameter("@AddTime", SqlDbType.DateTime){ Value = model.AddTime },
                new SqlParameter("@UserID", SqlDbType.VarChar, 50){ Value = model.UserID }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// ���¼�¼
        /// </summary>
        /// <param name="model">Data.Model.Usersʵ����</param>
        public int Update(Data.Model.HelpPoorSamples model)
        {
            string sql = @"UPDATE HelpPoorSamples SET 
				Code=@Code,Province=@Province,AgentName=@AgentName,AttechFile=@AttechFile,AddTime=@AddTime,UserID=@UserID
				WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int, -1){ Value = model.ID },
				new SqlParameter("@Code", SqlDbType.NVarChar, 50){ Value = model.Code },
				new SqlParameter("@Province", SqlDbType.VarChar, 50){ Value = model.Province },
				new SqlParameter("@AgentName", SqlDbType.VarChar, 50){ Value = model.AgentName },
				new SqlParameter("@AttechFile", SqlDbType.VarChar, 500){ Value = model.AttechFile },
				new SqlParameter("@AddTime", SqlDbType.DateTime){ Value = model.AddTime },
                new SqlParameter("@UserID", SqlDbType.VarChar, 50){ Value = model.UserID }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// ɾ����¼
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM HelpPoorSamples WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,-1){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// ��DataRedarת��ΪList
        /// </summary>
        private List<Data.Model.HelpPoorSamples> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.HelpPoorSamples> List = new List<Data.Model.HelpPoorSamples>();
            Data.Model.HelpPoorSamples model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.HelpPoorSamples();
                model.ID = dataReader.GetInt32(0);
                model.Code = dataReader.GetString(1);
                model.Province = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    model.AgentName = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.AttechFile = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.AddTime = dataReader.GetDateTime(5);
                if (!dataReader.IsDBNull(6))
                    model.UserID = dataReader.GetString(6);

                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// ��ѯ���м�¼
        /// </summary>
        public List<Data.Model.HelpPoorSamples> GetAll()
        {
            string sql = "SELECT * FROM HelpPoorSamples";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.HelpPoorSamples> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }



        /// <summary>
        /// ��ѯ���м�¼
        /// </summary>
        public List<Data.Model.HelpPoorSamples> GetTasks(string Code = "", string Province = "", string AgentName = "")
        {
            List<SqlParameter> parList = new List<SqlParameter>();
            StringBuilder sql = new StringBuilder("SELECT * FROM HelpPoorSamples WHERE 1=1");

            if (!Code.IsNullOrEmpty())
            {
                sql.Append(" AND Code like @Code");
                parList.Add(new SqlParameter("@Code", SqlDbType.NVarChar, 50) { Value = "%"+Code+"%" });
            }
            if (!Province.IsNullOrEmpty() && Province != "ȫ��")
            {
                    

                sql.Append(" AND Province like @Province");
                parList.Add(new SqlParameter("@Province", SqlDbType.NVarChar, 50) { Value = "%" + Province + "%" });
            }

            if (!AgentName.IsNullOrEmpty())
            {
                sql.Append(" AND AgentName like @AgentName");
                parList.Add(new SqlParameter("@AgentName", SqlDbType.NVarChar, 50) { Value = "%" + AgentName + "%" });
            }
           
            long count;
            int size = Utility.Tools.GetPageSize();
            int number = Utility.Tools.GetPageNumber();
            string sql1 = dbHelper.GetPaerSql(sql.ToString(), size, number, out count, parList.ToArray());
         //   pager = Utility.Tools.GetPagerHtml(count, size, number, query);


            SqlDataReader dataReader = dbHelper.GetDataReader(sql1, parList.ToArray());
            List<Data.Model.HelpPoorSamples> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }


        /// <summary>
        /// ��ѯ��¼��
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM HelpPoorSamples";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// ����������ѯһ����¼
        /// </summary>
        public Data.Model.HelpPoorSamples Get(Int32 id)
        {
            string sql = "SELECT * FROM HelpPoorSamples WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,-1){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.HelpPoorSamples> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }


        /// <summary>
        /// ��ѯ����ID������
        /// </summary>
        public Dictionary<string, string> GetAllIDAndName()
        {
            string sql = "SELECT distinct Province ID, Province Name FROM dbo.HelpPoorSamples  ORDER BY Name";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            while (dataReader.Read())
            {
                dict.Add(dataReader.GetString(0), dataReader.GetString(1));
            }
            dataReader.Close();
            return dict;
        }

      
    }
}
