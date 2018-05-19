using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sharpness.WebApp.Controllers
{
    public class OrganController : Controller
    {
        // GET: Organ
        public ActionResult Index()
        {
            return View();
        }

        // GET: Organ/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Organ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organ/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Organ/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Organ/Edit/5
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

        // GET: Organ/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Organ/Delete/5
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
