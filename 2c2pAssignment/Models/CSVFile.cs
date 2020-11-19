using _2c2pAssignment.Enum;
using _2c2pAssignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class CSVFile : BaseFile
    {
        public CSVChoice choice { get; set; }
        public override bool SaveData()
        {
            return base.SaveData();
        }
    }
}
