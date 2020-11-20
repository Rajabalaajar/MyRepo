using _2c2pAssignment.Enum;
using _2c2pAssignment.Interface;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using _2c2pAssignment.Logger;
using CsvHelper.Configuration;
using System.Globalization;
using _2c2pAssignment.Extension;
using _2c2pAssignment.DataAccess;

namespace _2c2pAssignment.Models
{
    public class CSVFile : BaseFile
    {
        public override bool SaveData()
        {
            try
            {
                var dataList = ReadData(out string Message);
                var Map = Helper.GetPropColMapping<FileModel>();
                DBAccess.BulkInsert<FileModel>(dataList, Map);
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
            return true;
        }
        public override string ValidateData()
        {
            string Message = "";
            try
            {
                var result = ReadData(out Message);
                int RowNumber = 0;
                string[] formats = { "yyyy-MM-dd hh:mm:ss" };
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
                        Message = "The property '" + nameof(t.TransactionId) + "' length is exceed(Should be lesser than 51). Row.No: " + RowNumber;
                    }
                    else if (!Decimal.TryParse(t.Amount, out decimal Result))
                    {
                        Message = "The property '" + nameof(t.Amount) + "' is not in the number format. Row.No: " + RowNumber;
                    }
                    else if (string.IsNullOrEmpty(t.CurrencyCode))
                    {
                        Message = "The property '" + nameof(t.CurrencyCode) + "' is required. Row.No: " + RowNumber;
                    }
                    else if (string.IsNullOrEmpty(t.TransactionDate))
                    {
                        Message = "The property '" + nameof(t.TransactionDate) + "' is required. Row.No: " + RowNumber;
                    }
                    else if (!string.IsNullOrEmpty(t.TransactionDate) && !DateTime.TryParseExact(t.TransactionDate, formats,
                System.Globalization.CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dt))
                    {
                        Message = "The property '" + nameof(t.TransactionDate) + "' is invalid format(Should be yyyy-MM-dd hh:mm:ss). Row.No: " + RowNumber;
                    }
                    else if (string.IsNullOrEmpty(t.Status))
                    {
                        Message = "The property '" + nameof(t.Status) + "' is required. Row.No: " + RowNumber;
                    }
                    else if (!string.IsNullOrEmpty(t.Status) && t.Status.ToString().ToLower() != Constants.APPROVED && t.Status.ToString().ToLower() != Constants.FAILED && t.Status.ToString().ToLower() != Constants.FINISHED)
                    {
                        Message = "The property '" + nameof(t.Status) + "' is invalid(Should be Approved/Finished/Failed). Row.No: " + RowNumber;
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
                throw ex;
            }
            return Message;
        }

        private List<FileModel> ReadData(out string Message)
        {
            List<FileModel> lst = new List<FileModel>();
            string msg = "";
            try
            {
                #region 
                //string[] DataLines = Data.Split(Environment.NewLine);
                //if (DataLines.Count() > 0)
                //{
                //    FileModel model = new CSVModel();
                //    PropertyInfo[] propsinfo = model.GetType().GetProperties();
                //    foreach (string str in DataLines[0].Split(','))
                //    {
                //        bool PrpFound = false;
                //        foreach (PropertyInfo info in propsinfo)
                //        {
                //            if (info.Name.ToLower() == str.TrimEnd().TrimStart().ToLower())
                //            {
                //                PrpFound = true;
                //            }
                //        }
                //        if (!PrpFound)
                //        {
                //            AppLogger.Trace("'" + str + "'" + " field is not matching with model or invalid field in the CSV file");
                //            break;
                //        }
                //    }
                //}
                //foreach (string row in DataLines.Skip(1))
                //{
                //    FileModel model = new CSVModel();
                //    model.TransactionId =
                //}
                #endregion

                TextReader reader = new StreamReader(_Stream.OpenReadStream());
                CsvConfiguration csvConfiguration = new CsvConfiguration(new System.Globalization.CultureInfo("en-US"));
                csvConfiguration.IgnoreQuotes = true;
                csvConfiguration.MissingFieldFound = (a, b, c) =>
                {
                    msg = "The header '" + a + "' is missing in the file " + _Stream.FileName + "";
                };
                CsvReader csvReader = new CsvReader(reader, csvConfiguration);
                var result = csvReader.GetRecords<FileModel>().ToList();
                Message = msg;
                lst = result;
                foreach (var t in lst)
                {
                    t.TransactionId = t.TransactionId.Replace("\"", "").TrimEnd().TrimStart();
                    t.Amount = t.Amount.Replace("\"", "").TrimEnd().TrimStart();
                    t.CurrencyCode = t.CurrencyCode.Replace("\"", "").TrimEnd().TrimStart();
                    t.Status = t.Status.Replace("\"", "").TrimEnd().TrimStart();
                    t.TransactionDate = t.TransactionDate.Replace("\"", "").TrimEnd().TrimStart();
                }
            }

            catch (InvalidDataException ex)
            {
                Message = msg;
                AppLogger.Log(ex);
            }
            catch (Exception ex)
            {
                throw;
            }
            return lst;
        }
    }
}
