using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data.MSSQL
{
    public class ReceiveDoc : Data.Interface.IReceiveDoc
    {
        private DBHelper dbHelper = new DBHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public ReceiveDoc()
        {
        }
        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        /// <returns>操作所影响的行数</returns>
        public int Add(Data.Model.ReceiveDoc model)
        {
            string sql = @"INSERT INTO dbo.ReceiveDocument
				(ID,DocumentTitle,DocumentType,DocumentLevel,DocumentCode,ReceiveDate,DocumentNum,DocumentAttech,DocumentUnit,AddTime,UserID) 
				VALUES(@ID,@DocumentTitle,@DocumentType,@DocumentLevel,@DocumentCode,@ReceiveDate,@DocumentNum,@DocumentAttech,@DocumentUnit,@AddTime,@UserID)";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@ID", SqlDbType.UniqueIdentifier,-1){ Value = model.ID },
				new SqlParameter("@DocumentTitle", SqlDbType.NVarChar, 50){ Value = model.DocumentTitle },
				new SqlParameter("@DocumentType", SqlDbType.VarChar, 50){ Value = model.DocumentType },
				new SqlParameter("@DocumentLevel", SqlDbType.VarChar, 50){ Value = model.DocumentLevel },
				new SqlParameter("@DocumentCode", SqlDbType.VarChar, 50){ Value = model.DocumentCode },
                new SqlParameter("@ReceiveDate", SqlDbType.VarChar, 50){ Value = model.ReceiveDate },
                new SqlParameter("@DocumentNum", SqlDbType.VarChar, 50){ Value = model.DocumentNum },
                new SqlParameter("@DocumentAttech", SqlDbType.VarChar, 5000){ Value = model.DocumentAttech },
                new SqlParameter("@DocumentUnit", SqlDbType.VarChar, 50){ Value = model.DocumentUnit },
				new SqlParameter("@AddTime", SqlDbType.DateTime){ Value = model.AddTime },
                new SqlParameter("@UserID", SqlDbType.VarChar, 50){ Value = model.UserID }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="model">Data.Model.Users实体类</param>
        public int Update(Data.Model.ReceiveDoc model)
        {
            string sql = @"UPDATE dbo.ReceiveDocument SET 
				DocumentTitle=@DocumentTitle,DocumentType=@DocumentType,DocumentLevel=@DocumentLevel,DocumentCode=@DocumentCode,ReceiveDate=@ReceiveDate,DocumentNum=@DocumentNum,DocumentAttech=@DocumentAttech,DocumentUnit=@DocumentUnit,AddTime=@AddTime,UserID=@UserID
				WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier,-1){ Value = model.ID },
				new SqlParameter("@DocumentTitle", SqlDbType.NVarChar, 50){ Value = model.DocumentTitle },
				new SqlParameter("@DocumentType", SqlDbType.VarChar, 50){ Value = model.DocumentType },
				new SqlParameter("@DocumentLevel", SqlDbType.VarChar, 50){ Value = model.DocumentLevel },
				new SqlParameter("@DocumentCode", SqlDbType.VarChar, 50){ Value = model.DocumentCode },
                new SqlParameter("@ReceiveDate", SqlDbType.VarChar, 50){ Value = model.ReceiveDate },
                new SqlParameter("@DocumentNum", SqlDbType.VarChar, 50){ Value = model.DocumentNum },
                new SqlParameter("@DocumentAttech", SqlDbType.VarChar, 5000){ Value = model.DocumentAttech },
                new SqlParameter("@DocumentUnit", SqlDbType.VarChar, 50){ Value = model.DocumentUnit },
				new SqlParameter("@AddTime", SqlDbType.DateTime){ Value = model.AddTime },
                new SqlParameter("@UserID", SqlDbType.VarChar, 50){ Value = model.UserID }
				
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 删除记录
        /// </summary>
        public int Delete(Guid id)
        {
            string sql = "DELETE FROM dbo.ReceiveDocument WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier){ Value = id }
			};
            return dbHelper.Execute(sql, parameters);
        }
        /// <summary>
        /// 将DataRedar转换为List
        /// </summary>
        private List<Data.Model.ReceiveDoc> DataReaderToList(SqlDataReader dataReader)
        {
            List<Data.Model.ReceiveDoc> List = new List<Data.Model.ReceiveDoc>();
            Data.Model.ReceiveDoc model = null;
            while (dataReader.Read())
            {
                model = new Data.Model.ReceiveDoc();
                model.ID = dataReader.GetGuid(0);
                model.DocumentTitle = dataReader.GetString(1);
                model.DocumentType = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    model.DocumentLevel = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    model.DocumentCode = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    model.ReceiveDate = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    model.DocumentNum = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7))
                    model.DocumentAttech = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    model.DocumentUnit = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    model.AddTime = dataReader.GetDateTime(9);
                if (!dataReader.IsDBNull(10))
                    model.UserID = dataReader.GetString(10);

                List.Add(model);
            }
            return List;
        }
        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReceiveDoc> GetAll()
        {
            string sql = "SELECT * FROM dbo.ReceiveDocument";
            SqlDataReader dataReader = dbHelper.GetDataReader(sql);
            List<Data.Model.ReceiveDoc> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }



        /// <summary>
        /// 查询所有记录
        /// </summary>
        public List<Data.Model.ReceiveDoc> GetTasks(string DocumentType = "", string DocumentLevel = "", string DocumentTitle = "", string DocumentCode = "", string DocumentUnit = "", string AddTime = "")
        {
            List<SqlParameter> parList = new List<SqlParameter>();
            StringBuilder sql = new StringBuilder("select * from (SELECT document.ID,document.DocumentTitle,DocumentType, DocumentLevel, document.DocumentCode,document.ReceiveDate,document.DocumentNum,document.DocumentAttech,document.DocumentUnit,document.AddTime,document.UserID,dic1.Title dicDocumentType,dic2.Title dicDocumentLevel FROM dbo.ReceiveDocument document inner join dbo.Dictionary dic1 on document.DocumentType=dic1.ID INNER JOIN dbo.Dictionary dic2 on document.DocumentLevel=dic2.ID) document WHERE 1=1");

            if (!DocumentType.IsNullOrEmpty())
            {
                sql.Append(" AND dicDocumentType like @DocumentType");
                parList.Add(new SqlParameter("@DocumentType", SqlDbType.NVarChar, 50) { Value = "%" + DocumentType + "%" });
            }
            if (!DocumentLevel.IsNullOrEmpty())
            {


                sql.Append(" AND dicDocumentLevel like @DocumentLevel");
                parList.Add(new SqlParameter("@DocumentLevel", SqlDbType.NVarChar, 50) { Value = "%" + DocumentLevel + "%" });
            }

            if (!DocumentTitle.IsNullOrEmpty())
            {
                sql.Append(" AND DocumentTitle like @DocumentTitle");
                parList.Add(new SqlParameter("@DocumentTitle", SqlDbType.NVarChar, 50) { Value = "%" + DocumentTitle + "%" });
            }

            if (!DocumentCode.IsNullOrEmpty())
            {
                sql.Append(" AND DocumentCode like @DocumentCode");
                parList.Add(new SqlParameter("@DocumentCode", SqlDbType.NVarChar, 50) { Value = "%" + DocumentCode + "%" });
            }

            if (!DocumentUnit.IsNullOrEmpty())
            {
                sql.Append(" AND DocumentUnit like @DocumentUnit");
                parList.Add(new SqlParameter("@DocumentUnit", SqlDbType.NVarChar, 50) { Value = "%" + DocumentUnit + "%" });
            }

            if (!AddTime.IsNullOrEmpty())
            {
                sql.Append(" AND convert (varchar(50),AddTime,23)=replace(convert (varchar(50),@AddTime,120),'/','-')");
                parList.Add(new SqlParameter("@AddTime", SqlDbType.NVarChar, 50) { Value = AddTime });
            }

          
            long count;
            int size = Utility.Tools.GetPageSize();
            int number = Utility.Tools.GetPageNumber();
            string sql1 = dbHelper.GetPaerSql(sql.ToString(), size, number, out count, parList.ToArray());
         //   pager = Utility.Tools.GetPagerHtml(count, size, number, query);


            SqlDataReader dataReader = dbHelper.GetDataReader(sql1, parList.ToArray());
            List<Data.Model.ReceiveDoc> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List;
        }


        /// <summary>
        /// 查询记录数
        /// </summary>
        public long GetCount()
        {
            string sql = "SELECT COUNT(*) FROM dbo.ReceiveDocument";
            long count;
            return long.TryParse(dbHelper.GetFieldValue(sql), out count) ? count : 0;
        }
        /// <summary>
        /// 根据主键查询一条记录
        /// </summary>
        public Data.Model.ReceiveDoc Get(Int32 id)
        {
            string sql = "SELECT * FROM dbo.ReceiveDocument WHERE ID=@ID";
            SqlParameter[] parameters = new SqlParameter[]{
				new SqlParameter("@ID", SqlDbType.Int,-1){ Value = id }
			};
            SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameters);
            List<Data.Model.ReceiveDoc> List = DataReaderToList(dataReader);
            dataReader.Close();
            return List.Count > 0 ? List[0] : null;
        }


        /// <summary>
        /// 查询所有ID和名称
        /// </summary>
        public Dictionary<string, string> GetAllIDAndName()
        {
            string sql = "SELECT distinct Province ID, Province Name FROM dbo.ReceiveDocument  ORDER BY Name";
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

