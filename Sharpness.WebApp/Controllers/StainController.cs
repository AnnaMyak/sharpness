using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;
using Sharpness.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sharpness.WebApp.Controllers
{
    public class StainController : Controller
    {
        
        // GET: Stain
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            return View();
        }

        




        // GET: Stain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stain/Create

        [HttpGet]
        public ActionResult Add()
        {
            
            return View();
        }

        

        // GET: Stain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stain/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stain/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
