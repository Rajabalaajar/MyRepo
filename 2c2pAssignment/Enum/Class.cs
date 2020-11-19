using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Enum
{
    public enum CSVChoice
    {
        Approved,
        Failed,
        Finished
    }
    public enum XMLChoice
    {
        Approved,
        Rejected,
        Done

    }
   public class Constants
    {
        public const string PDF = ".pdf";
        public const string CSV = ".csv";
        public const string XML = ".xml";
        public const string APPROVED = "approved";
        public const string REJECTED = "rejected";
        public const string FAILED = "failed";
        public const string FINISHED = "finished";
        public const string DONE = "done";
    }
}
