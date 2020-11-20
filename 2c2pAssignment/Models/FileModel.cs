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

        [ColumnAttr("Transaction Id"), DBDataType(typeof(string))]
        [Name("Transaction Id", "Transaction Identificator")]
        public string TransactionId { get; set; }

        [ColumnAttr("Amount"), DBDataType(typeof(decimal))]
        [Name("Amount")]
        public string Amount { get; set; }
        [ColumnAttr("Currency Code"), DBDataType(typeof(string))]
        [Name("Currency Code")]
        public string CurrencyCode { get; set; }
        [ColumnAttr("Transaction Date"), DBDataType(typeof(DateTime))]
        [Name("Transaction Date")]
        public string TransactionDate { get; set; }
        [ColumnAttr("Status"), DBDataType(typeof(string))]
        [Name("Status")]
        public virtual string Status { get; set; }

    }
    public class ColumnType
    {
        public string Name { get; set; }
        public Type type { get; set; }
    }
}
