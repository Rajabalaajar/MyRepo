using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class MetaValidation
    {
        public string Message { get; set; }
        public string ValidationType { get; set; }

        public string DataSetName { get; set; }

        public string TypeName { get; set; }

        public int FieldOrder { get; set; }
    }
}
