using _2c2pAssignment.Enum;
using _2c2pAssignment.Logger;
using _2c2pAssignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Processor
{
    public class FileProcessor
    {
        public Tuple<bool, List<FileDiagnostics>> ProcessFile(FileUpload File)
        {
            Tuple<bool, List<FileDiagnostics>> tpl = null;
            try
            {
                string FType = Path.GetExtension(File.File.FileName);
                
                if (FType == Constants.CSV)
                {
                    BaseFile baseFile = new CSVFile();
                    baseFile._Stream = File.File;
                    List<FileDiagnostics> ValidationMessage = baseFile.ValidateData();
                    if (ValidationMessage != null && ValidationMessage.Count > 0)
                    {
                        tpl = Tuple.Create(false, ValidationMessage);
                    }
                    else
                        tpl = Tuple.Create(baseFile.SaveData(), ValidationMessage);
                }
                else if (FType == Constants.XML)
                {
                    BaseFile baseFile = new XMLFile();
                    baseFile._Stream = File.File;
                    List<FileDiagnostics> ValidationMessage = baseFile.ValidateData();
                    if (ValidationMessage != null && ValidationMessage.Count > 0)
                    {
                        tpl = Tuple.Create(false, ValidationMessage);
                    }
                    else
                        tpl = Tuple.Create(baseFile.SaveData(), ValidationMessage);
                }
                else
                {
                    return Tuple.Create(false, new List<FileDiagnostics>() { new FileDiagnostics() { FieldName = "File", Message = "Unknown file format" } });
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
            return tpl;
        }

    }
}