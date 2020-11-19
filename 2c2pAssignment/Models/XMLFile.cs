using _2c2pAssignment.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class XMLFile : BaseFile
    {
        public XMLChoice Choice { get; set; }
        public override bool SaveData()
        {
            return base.SaveData();
           
        }
    }
}
