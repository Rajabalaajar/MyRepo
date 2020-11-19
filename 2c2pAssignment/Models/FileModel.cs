using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _2c2pAssignment.Models
{

   [TableName("TransactionData")]
    public class FileModel
    {
        
        [Name("Transaction Identificator", "Transaction Id")]
        public string TransactionId { get; set; }

        [Name("Amount")]
        public string Amount { get; set; }
        [Name("Currency Code")]
        public string CurrencyCode { get; set; }
        [Name("Transaction Date")]
        public string TransactionDate { get; set; }
        [Name("Status")]
        public virtual string Status { get; set; }
    }
}
