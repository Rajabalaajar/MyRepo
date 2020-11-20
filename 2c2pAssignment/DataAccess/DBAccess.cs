using _2c2pAssignment.Extension;
using _2c2pAssignment.Interface;
using _2c2pAssignment.Logger;
using _2c2pAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _2c2pAssignment.DataAccess
{
    public class DBAccess
    {
        private static SqlConnection _Connection = null;
        private static string ConnectionStr;
        public static void InitializeDBSetting(string ConnStr)
        {
            ConnectionStr = ConnStr;

        }
        private static SqlConnection GetSQLConnection()
        {
            return new SqlConnection(ConnectionStr);
        }
        public static DataViewModel GetData(DataViewModel model)
        {
            DataViewModel md = new DataViewModel();
            md.currencyFilter = new CurrencyFilter();
            md.dateFilter = new DateFilter();
            md.statusFilter = new StatusFilter();
            md.resultFormat = new ResultFormat();
            md.currencyFilter.Currencies = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            md.currencyFilter.Currencies.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "--Select--", Value = "--Select--" });
            md.statusFilter.StatusList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            md.statusFilter.StatusList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = "--Select--", Value = "--Select--" });
            md.resultFormat.ResultList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();
            md.outputModel = new List<OutputModel>();
            try
            {
                using (_Connection = GetSQLConnection())
                {
                    if (_Connection.State == System.Data.ConnectionState.Closed)
                        _Connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = _Connection;
                    cmd.CommandText = "USP_GetTransactionData";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (model != null)
                    {
                        cmd.Parameters.AddWithValue("@Currency", model.currencyFilter.Currency);
                        cmd.Parameters.AddWithValue("@Status", model.statusFilter.Status);
                        cmd.Parameters.AddWithValue("@Start_Date", model.dateFilter.StartDate);
                        cmd.Parameters.AddWithValue("@End_Date", model.dateFilter.EndDate);
                    }

                    cmd.Parameters.AddWithValue("@Operation", "All");
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string Currency = Convert.ToString(reader["Currency"]);
                        md.currencyFilter.Currencies.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = Currency, Value = Currency });
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            string Status = Convert.ToString(reader["Status"]);
                            md.statusFilter.StatusList.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = Status, Value = Status });
                        }
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            string Stat = Convert.ToString(reader["Status"]);
                            string TrnsId = Convert.ToString(reader["ID"]);
                            string Pay = Convert.ToString(reader["Payment"]);
                            md.outputModel.Add(new OutputModel() { Id = TrnsId, Payment = Pay, Status = Stat });
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
            return md;
        }
        public static bool BulkInsert<T>(List<T> data, Dictionary<string, ColumnType> ColMap)
        {
            try
            {
                string DestTable = ((TableNameAttribute)typeof(T).GetCustomAttributes(true)[0]).TableName;
                using (_Connection = GetSQLConnection())
                {
                    if (_Connection.State == System.Data.ConnectionState.Closed)
                        _Connection.Open();
                    SqlBulkCopy copy = new SqlBulkCopy(_Connection);
                    copy.DestinationTableName = DestTable;
                    copy.BulkCopyTimeout = 0;
                    DataTable dt = data.ConvertToDatatable<T>(ColMap);
                    copy.MapColumns(ColMap);
                    copy.WriteToServer(dt);

                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
                return false;
            }
            return true;
        }

    }

}
