using _2c2pAssignment.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public abstract class BaseFile : IFileType
    {
        public IFormFile _Stream;
        public virtual bool SaveData()
        {
            throw new Exception("Invalid File type uploaded");
        }

        public virtual string ValidateData()
        {
            throw new Exception("Invalid File type uploaded");
        }
    }
}
