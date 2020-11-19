using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _2c2pAssignment.Extension
{
    public static class Helper
    {
        public static DataTable ConvertToDatatable<T>(this List<T> data)
        {
            if (data == null)
                return null;

            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }

            return table;
        }
    }
    public class ObjectDataReader<TData> : IDataReader
    {
        /// <summary>
        /// The enumerator for the IEnumerable{TData} passed to the constructor for 
        /// this instance.
        /// </summary>
        private IEnumerator<TData> dataEnumerator;

        /// <summary>
        /// The lookup of property names against their ordinal positions.
        /// </summary>
        private Dictionary<string, int> ordinalLookup = new Dictionary<string, int>();

        private List<string> colHeaders;

        private int columnCount = 0;

        Type typeObj = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectDataReader&lt;TData&gt;"/> class.
        /// </summary>
        /// <param name="data">The data this instance should enumerate through.</param>
        public ObjectDataReader(IEnumerable<TData> data, List<string> colHeaders)
        {
            this.dataEnumerator = data.GetEnumerator();

            this.colHeaders = colHeaders;

            typeObj = typeof(TData);

            if (null != colHeaders)
            {
                columnCount = colHeaders.Count;

                for (int i = 0; i < colHeaders.Count; i++)
                {
                    ordinalLookup[colHeaders[i]] = i;
                }
            }
        }
        #region IDataReader Members

        public void Close()
        {
            this.Dispose();
        }

        public int Depth
        {
            get { return 1; }
        }

        public DataTable GetSchemaTable()
        {
            return null;
        }

        public bool IsClosed
        {
            get { return this.dataEnumerator == null; }
        }

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            if (this.dataEnumerator == null)
            {
                throw new ObjectDisposedException("ObjectDataReader");
            }

            return this.dataEnumerator.MoveNext();
        }

        public int RecordsAffected
        {
            get { return -1; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dataEnumerator != null)
                {
                    this.dataEnumerator.Dispose();
                    this.dataEnumerator = null;
                }
            }
        }

        #endregion

        #region IDataRecord Members

        public int FieldCount
        {
            get { return this.columnCount; }
        }

        public bool GetBoolean(int i)
        {
            throw new NotImplementedException();
        }

        public byte GetByte(int i)
        {
            throw new NotImplementedException();
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            throw new NotImplementedException();
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            throw new NotImplementedException();
        }

        public decimal GetDecimal(int i)
        {
            throw new NotImplementedException();
        }

        public double GetDouble(int i)
        {
            throw new NotImplementedException();
        }

        public Type GetFieldType(int i)
        {
            throw new NotImplementedException();
        }

        public float GetFloat(int i)
        {
            throw new NotImplementedException();
        }

        public Guid GetGuid(int i)
        {
            throw new NotImplementedException();
        }

        public short GetInt16(int i)
        {
            throw new NotImplementedException();
        }

        public int GetInt32(int i)
        {
            throw new NotImplementedException();
        }

        public long GetInt64(int i)
        {
            throw new NotImplementedException();
        }

        public string GetName(int i)
        {
            throw new NotImplementedException();
        }

        public int GetOrdinal(string name)
        {
            int ordinal;
            if (!this.ordinalLookup.TryGetValue(name, out ordinal))
            {
                throw new InvalidOperationException("Unknown parameter name " + name);
            }

            return ordinal;
        }

        public string GetString(int i)
        {
            throw new NotImplementedException();
        }

        public object GetValue(int i)
        {
            if (this.dataEnumerator == null)
            {
                throw new ObjectDisposedException("ObjectDataReader");
            }


            object retVal = DBNull.Value;
            if (null != this.dataEnumerator.Current && i < columnCount)
            {
                string info = colHeaders[i];
                PropertyInfo propInfo = null;
                if (!string.IsNullOrEmpty(info))
                {
                    Type attriType = typeObj.GetProperty(info).PropertyType;
                    object attriObj = typeObj.GetProperty(info).GetValue(this.dataEnumerator.Current);

                    propInfo = attriType.GetProperty(info);
                    if (attriObj != null && propInfo != null)
                        retVal = propInfo.GetValue(attriObj) ?? DBNull.Value;
                }
                else
                {
                    propInfo = typeObj.GetProperty(info);
                    if (propInfo != null)
                        retVal = propInfo.GetValue(this.dataEnumerator.Current) ?? DBNull.Value;
                }
            }
            return retVal;
        }

        public int GetValues(object[] values)
        {
            throw new NotImplementedException();
        }

        public bool IsDBNull(int i)
        {
            throw new NotImplementedException();
        }

        public object this[string name]
        {
            get { throw new NotImplementedException(); }
        }

        public object this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
