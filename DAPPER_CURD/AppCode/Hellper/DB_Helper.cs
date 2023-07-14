using Dapper;
using DAPPER_CURD.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using static Dapper.SqlMapper;

namespace DAPPER_CURD.AppCode.Hellper
{
    public class DB_Helper
    {
        public static T ExecuteProc<T>(string ProcName, DynamicParameters param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return (T)Convert.ChangeType(sqlcon.Execute(ProcName, param, commandType:System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }
        public static IEnumerable<T> ExecuteProcList<T>(string ProcName, DynamicParameters param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return sqlcon.Query<T>(ProcName, param, commandType:System.Data.CommandType.StoredProcedure);
            }
        }
        public static T ExecuteQueryFirst<T>(string ProcName, DynamicParameters param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return sqlcon.QueryFirst<T>(ProcName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public static T ExecuteQuery<T>(string query,DynamicParameters param)
        {
            using (SqlConnection sqlcon = new SqlConnection(Config.ConStr))
            {
                return (T)Convert.ChangeType(sqlcon.Execute(query, param, commandType: System.Data.CommandType.Text),typeof(T));
            }
        }
    }
}
