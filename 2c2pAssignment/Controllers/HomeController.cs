using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _2c2pAssignment.Models;
using System.IO;
using _2c2pAssignment.Enum;
using _2c2pAssignment.Logger;

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
            DataViewModel model = new DataViewModel();
            try
            {

                model.currencyFilter = new CurrencyFilter();
                model.dateFilter = new DateFilter();
                model.statusFilter = new StatusFilter();
                model.currencyFilter.Currencies = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>()
            {
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){Text="--Select--",Value="--Select--" },
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){Text="USD",Value="USD" }
            };
                model.statusFilter.StatusList = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>()
            {
                    new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){Text="--Select--",Value="--Select--" },
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){ Text="Approved",Value="A" },
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){ Text="Rejected",Value="R" },
                new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem(){ Text="Done",Value="D" },

            };
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult DataView(DataViewModel model)
        {


            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
