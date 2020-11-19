using System;

namespace _2c2pAssignment.Models
{
    public class TableNameAttribute : Attribute
    {
        public string TableName = "";
        public TableNameAttribute(string tblName)
        {
            TableName = tblName;
        }
        
    }
}