using _2c2pAssignment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _2c2pAssignment.Extension
{
    public static class Helper
    {
        public static DataTable ConvertToDatatable<T>(this List<T> data, Dictionary<string, ColumnType> ColName)
        {
            if (data == null)
                return null;

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();
            if (ColName != null && ColName.Count > 0)
            {
                foreach (KeyValuePair<string, ColumnType> k in ColName)
                {
                    table.Columns.Add(k.Value.Name, k.Value.type);
                }
                foreach (T obj in data)
                {
                    DataRow dr = table.NewRow();
                    foreach (KeyValuePair<string, ColumnType> keyValuePair in ColName)
                    {
                        dr[keyValuePair.Value.Name] = obj.GetType().GetProperty(keyValuePair.Key).GetValue(obj, null);
                    }
                    table.Rows.Add(dr);
                }
            }
            return table;
        }
        public static Dictionary<string, ColumnType> GetPropColMapping<T>()
        {
            Dictionary<string, ColumnType> dic = new Dictionary<string, ColumnType>();
            var props = typeof(T).GetProperties();
            foreach (PropertyInfo pr in props)
            {
                var attr = ((ColumnAttrAttribute)pr.GetCustomAttribute(typeof(ColumnAttrAttribute))).MappedColumnName;
                var typeAttr = ((DBDataTypeAttribute)pr.GetCustomAttribute(typeof(DBDataTypeAttribute))).type;
                dic.Add(pr.Name, new ColumnType() { Name = attr, type = typeAttr });
            }
            return dic;
        }
        public static SqlBulkCopy MapColumns(this SqlBulkCopy copy, Dictionary<string, ColumnType> lookupDic)
        {
            foreach (KeyValuePair<string, ColumnType> kvp in lookupDic)
            {
                copy.ColumnMappings.Add(kvp.Value.Name, kvp.Value.Name);
            }
            return copy;
        }

    }
}
