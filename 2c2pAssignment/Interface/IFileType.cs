using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Interface
{
    public interface IFileType
    {
        string ValidateData();
        bool SaveData();
    }
}
