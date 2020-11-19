using _2c2pAssignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public abstract class BaseFile : IFileType
    {
       

        public virtual bool SaveData()
        {
            throw new Exception("Invalid File type uploaded");
        }
    }
}
