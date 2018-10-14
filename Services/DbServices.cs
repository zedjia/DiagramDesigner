using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DiagramDesigner.Services
{
    public class DbServices
    {

        public static DataTable GetDataTableBySql(string sql,string connStr)
        {
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                DataTable datatable = new DataTable();
                try
                {
                    var reader = cn.ExecuteReader(sql);
                    datatable.Load(reader);
                    return datatable;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

    }
}
