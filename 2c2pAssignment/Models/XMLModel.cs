using _2c2pAssignment.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Models
{
    public class XMLModel
    {
        public string TransactionId { get; set; }
        public string Amount { get; set; }
        public string CurrenctCode { get; set; }
        public string TransactionDate { get; set; }
        public XMLChoice Choice { get; set; }
        public string ChoiceStr
        {
            get
            {
                if (Choice == XMLChoice.Approved)
                {
                    return "Approved";
                }
                else if (Choice == XMLChoice.Done)
                {
                    return "Done";
                }
                else if (Choice == XMLChoice.Rejected)
                {
                    return "Rejected";
                }
                else
                    return string.Empty;

            }
            set { }
        }
    }
}
