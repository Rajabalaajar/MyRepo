using _2c2pAssignment.Enum;
using _2c2pAssignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class CSVModel : FileModel
    {
        public CSVChoice Choice
        {
            set
            {
                if (value == CSVChoice.Approved)
                {
                    Status = "Approved";
                }
                else if (value == CSVChoice.Failed)
                {
                    Status = "Failed";
                }
                else if (value == CSVChoice.Finished)
                {
                    Status = "Finihsed";

                }
                else
                    Status = "";
            }
        }
        public string ChoiceStr
        {
            get { return Status; }
        }

    }
}
