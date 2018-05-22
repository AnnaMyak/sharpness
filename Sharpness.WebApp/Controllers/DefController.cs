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

namespace Sharpness.WebApp.Controllers
{
    
    public class DefController : Controller
    {

        public ActionResult Index()
        {
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
