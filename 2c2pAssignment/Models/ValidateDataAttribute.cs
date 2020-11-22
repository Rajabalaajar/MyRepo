using _2c2pAssignment.Enum;
using _2c2pAssignment.Processor;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

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
                FileProcessor processor = new FileProcessor();
                Tuple<bool, List<FileDiagnostics>> result = processor.ProcessFile(new FileUpload() { File = file });
                if (result != null)
                {
                    if (!result.Item1)
                    {
                        ValidationMessage = result.Item2.FirstOrDefault().Message;
                    }

                }
                else
                {
                    ValidationMessage = "Unknown Error";
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
