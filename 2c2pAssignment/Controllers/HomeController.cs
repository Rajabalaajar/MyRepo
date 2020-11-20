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
using _2c2pAssignment.DataAccess;

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
                            string ValidationMessage = baseFile.ValidateData();
                            if (!string.IsNullOrEmpty(ValidationMessage))
                                return BadRequest(ValidationMessage);
                            ViewData["Uploaded"] = baseFile.SaveData();
                        }
                        else if (FType == Constants.XML)
                        {
                            BaseFile baseFile = new XMLFile();
                            baseFile._Stream = File.File;
                            string ValidationMessage = baseFile.ValidateData();
                            if (!string.IsNullOrEmpty(ValidationMessage))
                                return BadRequest(ValidationMessage);
                            ViewData["Uploaded"] = baseFile.SaveData();
                        }
                        else
                        {
                            return Json("Unknown file format");
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
                model = DBAccess.GetData(null);
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
            DataViewModel m = new DataViewModel();
            m = DBAccess.GetData(model);
            if (m != null)
            {
                var data = m.currencyFilter.Currencies.Where(x => x.Text == model.currencyFilter.Currency).FirstOrDefault();
                data.Selected = true;
                m.statusFilter.StatusList.Where(x => x.Text == model.statusFilter.Status).FirstOrDefault().Selected = true;
                m.dateFilter.StartDate = model.dateFilter.StartDate;
                m.dateFilter.EndDate = model.dateFilter.EndDate;
            }
            return View(m);
        }
        public IActionResult JSONView()
        {
            DataViewModel m = new DataViewModel();
            m = DBAccess.GetData(null);

            return Ok(Json(m.outputModel).Value);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
