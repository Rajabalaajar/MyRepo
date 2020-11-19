using _2c2pAssignment.Enum;
using _2c2pAssignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class XMLModel : FileModel
    {
        public XMLChoice Choice
        {
            set
            {
                if (value == XMLChoice.Approved)
                {
                    Status = "Approved";
                }
                else if (value == XMLChoice.Done)
                {
                    Status = "Done";
                }
                else if (value == XMLChoice.Rejected)
                {
                    Status = "Rejected";

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
