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
using System.Drawing;
using System.IO;

namespace Sharpness.WebApp.Controllers
{
    
    public class DefController : Controller
    {

        public ActionResult Index()
        {
            
            Image img = Image.FromFile(@"C:\Users\AnnaToshiba2\Desktop\WSI\Sharpness_WebApp_Uploads\myakinen@gmail.com\WSI AAA\CMU-1.png");
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            var base64 = Convert.ToBase64String(arr);
            ViewBag.Img= String.Format("data:image/png;base64,{0}", base64);
        

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
