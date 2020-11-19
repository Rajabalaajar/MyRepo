using _2c2pAssignment.Extension;
using _2c2pAssignment.Interface;
using _2c2pAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.DataAccess
{
    public class DBAccess
    {
        private static SqlConnection _Connection = null;
        public static bool InsertData(List<FileModel> model)
        {
            try
            {
                using (_Connection)
                {
                    if (_Connection.State == System.Data.ConnectionState.Closed)
                        _Connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _Connection;
                    cmd.CommandText = "USP_CRUDFileData";
                    cmd.Parameters.AddWithValue("", "");
                    cmd.Parameters.AddWithValue("", "");
                    cmd.Parameters.AddWithValue("", "");
                    cmd.Parameters.AddWithValue("", "");
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    return Convert.ToBoolean(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        public static bool BulkInsert<T>(List<T> data)
        {
            try
            {
                string DestTable = ((TableNameAttribute)typeof(T).GetCustomAttributes(true)[0]).TableName;
                List<string> ColumnName = null;
                using (_Connection)
                {
                    if (_Connection.State == System.Data.ConnectionState.Closed)
                        _Connection.Open();
                    SqlBulkCopy copy = new SqlBulkCopy(_Connection);
                    copy.DestinationTableName = DestTable;
                    copy.BulkCopyTimeout = 0;
                    copy.WriteToServer(new ObjectDataReader<T>(data, null));

                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }

    }

}
