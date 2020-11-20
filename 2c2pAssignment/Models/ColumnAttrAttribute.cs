using System;

namespace _2c2pAssignment.Models
{
    public class ColumnAttrAttribute : Attribute
    {
        public string MappedColumnName = "";
        public ColumnAttrAttribute(string Name)
        {
            MappedColumnName = Name;
        }
    }
}