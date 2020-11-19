using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _2c2pAssignment.Models;
using System.IO;
using _2c2pAssignment.Enum;

namespace _2c2pAssignment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(FileUpload File)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (File != null && File.File != null)
                    {
                        string FType = Path.GetExtension(File.File.FileName);
                        if (FType == Constants.CSV)
                        {
                            BaseFile baseFile = new CSVFile();
                            baseFile._Stream = File.File;
                            baseFile.SaveData();
                        }
                        else if (FType == Constants.XML)
                        {
                            BaseFile baseFile = new XMLFile();
                            baseFile._Stream = File.File;
                            baseFile.SaveData();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        public IActionResult DataView()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
