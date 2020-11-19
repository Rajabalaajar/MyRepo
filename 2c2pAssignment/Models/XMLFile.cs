using _2c2pAssignment.Enum;
using _2c2pAssignment.Logger;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using _2c2pAssignment.DataAccess;
using _2c2pAssignment.Extension;
using System.Data;

namespace _2c2pAssignment.Models
{
    public class XMLFile : BaseFile
    {

        public override bool SaveData()
        {
            try
            {
                var dataList = ReadData();
                DBAccess.BulkInsert<FileModel>(dataList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }
        public List<FileModel> ReadData()
        {
            List<FileModel> lstModel = new List<FileModel>();
            try
            {
                Stream st = _Stream.OpenReadStream();
                string Tdata = new StreamReader(st).ReadToEnd();
                XmlSerializer serializer = new XmlSerializer(typeof(Transactions));
                Transactions result = null;
                using (TextReader reader = new StringReader(Tdata))
                {
                    result = (Transactions)serializer.Deserialize(reader);
                }
                foreach (Transaction t in result.Transaction)
                {
                    FileModel model = new FileModel()
                    {
                        TransactionId = t.Id.Replace("\"", "").TrimEnd().TrimStart(),
                        TransactionDate = t.TransactionDate.Replace("\"", "").TrimEnd().TrimStart(),
                        Amount = t.PaymentDetails.Amount.Replace("\"", "").TrimEnd().TrimStart(),
                        CurrencyCode = t.PaymentDetails.CurrencyCode.Replace("\"", "").TrimEnd().TrimStart(),
                        Status = t.Status.Replace("\"", "").TrimEnd().TrimStart()

                    };
                    lstModel.Add(model);
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
            return lstModel;
        }
        public override string ValidateData()
        {
            string Message = "";
            try
            {
                var result = ReadData();
                int RowNumber = 0;
                string[] formats = { "yyyy-MM-dd HH:mm:ss" };
                DateTime dt;

                foreach (FileModel t in result)
                {
                    RowNumber++;
                    if (string.IsNullOrEmpty(t.TransactionId))
                    {
                        Message = "The property '" + nameof(t.TransactionId) + "' is empty or null in the given input file";
                    }
                    else if (t.TransactionId.Length > 50)
                    {
                        Message = "The property '" + nameof(t.TransactionId) + "' length is exceed(Should be lesser than 51). Element.No: " + RowNumber;
                    }
                    else if (!Decimal.TryParse(t.Amount, out decimal Result))
                    {
                        Message = "The property '" + nameof(t.Amount) + "' is not in the number format. Element.No: " + RowNumber;
                    }
                    else if (string.IsNullOrEmpty(t.CurrencyCode))
                    {
                        Message = "The property '" + nameof(t.CurrencyCode) + "' is required. Element.No: " + RowNumber;
                    }
                    else if (string.IsNullOrEmpty(t.TransactionDate))
                    {
                        Message = "The property '" + nameof(t.TransactionDate) + "' is required. Element.No: " + RowNumber;
                    }
                    else if (!string.IsNullOrEmpty(t.TransactionDate) && !DateTime.TryParseExact(t.TransactionDate, formats,
                System.Globalization.CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dt))
                    {
                        Message = "The property '" + nameof(t.TransactionDate) + "' is invalid format(Should be yyyy-MM-dd hh:mm:ss). Element.No: " + RowNumber;
                    }
                    else if (string.IsNullOrEmpty(t.Status))
                    {
                        Message = "The property '" + nameof(t.Status) + "' is required. Element.No: " + RowNumber;
                    }
                    else if (!string.IsNullOrEmpty(t.Status) && t.Status.ToString().ToLower() != Constants.APPROVED && t.Status.ToString().ToLower() != Constants.REJECTED && t.Status.ToString().ToLower() != Constants.DONE)
                    {
                        Message = "The property '" + nameof(t.Status) + "' is invalid(Should be Approved/Rejected/Done). Element.No: " + RowNumber;
                    }
                    if (!string.IsNullOrEmpty(Message))
                    {
                        AppLogger.Trace(Message);
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
                throw ex;
            }
            return Message;
        }
    }
    [XmlRoot(ElementName = "PaymentDetails")]
    public class PaymentDetails
    {
        [XmlElement(ElementName = "Amount")]
        public string Amount { get; set; }
        [XmlElement(ElementName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
    }

    [XmlRoot(ElementName = "Transaction")]
    public class Transaction
    {
        [XmlElement(ElementName = "TransactionDate")]
        public string TransactionDate { get; set; }
        [XmlElement(ElementName = "PaymentDetails")]
        public PaymentDetails PaymentDetails { get; set; }
        [XmlElement(ElementName = "Status")]
        public string Status { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }
    }

    [XmlRoot(ElementName = "Transactions")]
    public class Transactions
    {
        [XmlElement(ElementName = "Transaction")]
        public List<Transaction> Transaction { get; set; }
    }
}
