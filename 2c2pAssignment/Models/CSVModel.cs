using _2c2pAssignment.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class CSVModel
    {
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string CurrenctCode { get; set; }
        public string TransactionDate { get; set; }
        public CSVChoice Choice { get; set; }

        public string ChoiceStr
        {
            get
            {
                if (Choice == CSVChoice.Approved)
                {
                    return "Approved";
                }
                else if (Choice == CSVChoice.Failed)
                {
                    return "Failed";
                }
                else if (Choice == CSVChoice.Finished)
                {
                    return "Finished";
                }
                else
                    return string.Empty;

            }
            set { }
        }
    }
}
