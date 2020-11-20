using System;

namespace _2c2pAssignment.Models
{
    public class DBDataTypeAttribute : Attribute
    {
        public Type type = null;
        public DBDataTypeAttribute(Type tpe)
        {
            type = tpe;
        }
    }
}