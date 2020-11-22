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
using System.Reflection;
using _2c2pAssignment.Repository;
using _2c2pAssignment.Interface;

namespace _2c2pAssignment.Models
{
    public class XMLFile : BaseFile
    {

        public override bool SaveData()
        {
            try
            {
                var dataList = ReadData();
                var Map = Helper.GetPropColMapping<FileModel>();
                DBAccess.BulkInsert<FileModel>(dataList, Map);
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
                return false;
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
        public override List<FileDiagnostics> ValidateData()
        {
            List<FileDiagnostics> diags = new List<FileDiagnostics>();
            try
            {
                var result = ReadData();
                DataValidator<FileModel> dataValidator = new DataValidator<FileModel>();
                diags = dataValidator.ValidateData(result);

                int RowNumber = 0;

                foreach (FileModel t in result)
                {
                    RowNumber++;
                    if (!string.IsNullOrEmpty(t.Status) && t.Status.ToString().ToLower() != Constants.APPROVED && t.Status.ToString().ToLower() != Constants.REJECTED && t.Status.ToString().ToLower() != Constants.DONE)
                    {
                        diags.Add(new FileDiagnostics()
                        {
                            Message = "The property '" + nameof(t.Status) + "' is invalid(Should be Approved/Rejected/Done). Element.No: " + RowNumber,
                            FieldName = nameof(t.Status),
                            RowNo = RowNumber,
                            severity = Severity.Error
                        });

                    }


                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
                throw ex;
            }
            return diags;
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
