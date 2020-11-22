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
using _2c2pAssignment.Processor;

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
                        FileProcessor processor = new FileProcessor();
                        Tuple<bool, List<FileDiagnostics>> result = processor.ProcessFile(File.File.OpenReadStream(), File.File.FileName);
                        if (result != null)
                        {
                            if (result.Item1)
                            {
                                ViewData["Uploaded"] = result.Item1;
                            }
                            else
                            {
                                foreach (FileDiagnostics fd in result.Item2)
                                {
                                    AppLogger.Trace(fd.Message + "- Row.No:" + fd.RowNo);
                                }
                                return BadRequest(result.Item2);
                            }
                        }
                        else
                        {
                            return Error();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
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
