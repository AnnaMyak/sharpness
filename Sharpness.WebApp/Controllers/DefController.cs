using Sharpness.Persistence;
using Sharpness.Persistence.Entities;
using Sharpness.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace Sharpness.WebApp.Controllers
{
    
    public class DefController : Controller
    {

        public ActionResult Index()
        {
            Process first = new Process();
            try
            {
                first.StartInfo.FileName = @"C:\Users\AnnaToshiba2\Documents\GitHub\sharpness\sharpness console App\SharpnessExplorationCurrent\SharpnessExplorationCurrent\bin\x64\Release\SharpnessExplorationCurrent.exe";
                first.StartInfo.Arguments = @"C:\Users\AnnaToshiba2\Desktop\WSI\CMU-1.ndpi";
                first.Start();
                
                first.WaitForExit();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error "+ex.Message);
            }

            return View();
        }


        [HttpPost]
       public ActionResult CreateStain(Stain s)
        {
            var _context = new DataContext();
            _context.Stains.Add(s);
            _context.SaveChanges();
            string message = "SUCCESS"; 
            
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        public JsonResult GetStains(string Name)
        {
            var _context = new DataContext();
            var stains = _context.Stains.ToList();
            return Json(stains, JsonRequestBehavior.AllowGet);
        }
    }

        
}
