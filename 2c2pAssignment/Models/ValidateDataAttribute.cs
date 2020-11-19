using _2c2pAssignment.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace _2c2pAssignment.Models
{
    public class ValidateDataAttribute : ValidationAttribute
    {
        private string ValidationMessage = "";
        protected override ValidationResult IsValid(
     object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                string FType = Path.GetExtension(file.FileName);
                if (FType == Constants.CSV)
                {
                    BaseFile baseFile = new CSVFile();
                    baseFile._Stream = file;
                    ValidationMessage = baseFile.ValidateData();
                    if (!string.IsNullOrEmpty(ValidationMessage))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
                else if (FType == Constants.XML)
                {
                    BaseFile baseFile = new XMLFile();
                    baseFile._Stream = file;
                    ValidationMessage = baseFile.ValidateData();
                    if (!string.IsNullOrEmpty(ValidationMessage))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return ValidationMessage;
        }
    }
}
