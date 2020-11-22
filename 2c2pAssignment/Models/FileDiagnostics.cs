using _2c2pAssignment.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{

    public class FileDiagnostics
    {
        public string Message { get; set; }
        public int RowNo { get; set; }

        public string FieldName { get; set; }

        public Severity severity { get; set; }
    }
}
