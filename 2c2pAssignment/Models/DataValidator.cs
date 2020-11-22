using _2c2pAssignment.Interface;
using _2c2pAssignment.Repository;
using _2c2pAssignment.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using _2c2pAssignment.Logger;

namespace _2c2pAssignment.Models
{
    public class DataValidator<T> where T : FileModel
    {
        Dictionary<string, List<MetaValidation>> _ValidationDic = new Dictionary<string, List<MetaValidation>>();
        public DataValidator()
        {
            _ValidationDic = MetaFactory.Instance.GetValidation<T>();
        }

        public List<FileDiagnostics> ValidateData(List<T> DataList)
        {
            List<FileDiagnostics> valid = new List<FileDiagnostics>();
            try
            {
                int RowNumber = 0;
                string[] formats = { "yyyy-MM-dd HH:mm:ss" };
                DateTime dt;
                foreach (FileModel t in DataList)
                {
                    List<MetaValidation> metas = null;
                    RowNumber++;
                    if (string.IsNullOrEmpty(t.TransactionId))
                    {
                        _ValidationDic.TryGetValue(nameof(t.TransactionId).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 1).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (t.TransactionId.Length > 50)
                    {
                        _ValidationDic.TryGetValue(nameof(t.TransactionId).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 2).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (!Decimal.TryParse(t.Amount, out decimal Result))
                    {
                        _ValidationDic.TryGetValue(nameof(t.Amount).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 1).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (string.IsNullOrEmpty(t.CurrencyCode))
                    {
                        _ValidationDic.TryGetValue(nameof(t.CurrencyCode).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 1).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (string.IsNullOrEmpty(t.TransactionDate))
                    {
                        _ValidationDic.TryGetValue(nameof(t.TransactionDate).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 1).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (!string.IsNullOrEmpty(t.TransactionDate) && !DateTime.TryParseExact(t.TransactionDate, formats,
                System.Globalization.CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dt))
                    {
                        _ValidationDic.TryGetValue(nameof(t.TransactionDate).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 2).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (string.IsNullOrEmpty(t.Status))
                    {
                        _ValidationDic.TryGetValue(nameof(t.Status).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 1).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }
                    else if (!string.IsNullOrEmpty(t.Status) && t.Status.ToString().ToLower() != Constants.APPROVED && t.Status.ToString().ToLower() != Constants.REJECTED && t.Status.ToString().ToLower() != Constants.DONE)
                    {
                        _ValidationDic.TryGetValue(nameof(t.Status).ToLower(), out metas);
                        if (metas != null)
                        {
                            MetaValidation md = metas.Where(x => x.FieldOrder == 2).FirstOrDefault();
                            if (md != null)
                            {
                                FileDiagnostics fd = new FileDiagnostics();
                                fd.FieldName = md.DataSetName;
                                fd.Message = md.Message;
                                fd.severity = Enum.Severity.Error;
                                fd.RowNo = RowNumber;
                                valid.Add(fd);
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
            return valid;
        }
    }
}
