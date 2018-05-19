using Sharpness.Persistence.Repositories;
using Sharpness.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sharpness.WebApp.Controllers
{
    public class ReglamentController : Controller
    {
        IReglamentRepository _repo = new ReglamentRepository();
        // GET: Reglament

        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Reglaments = _repo.GetAllReglaments();
                        
            return View(model);
        }

        // GET: Reglament/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reglament/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reglament/Create
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

        // GET: Reglament/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reglament/Edit/5
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

        // GET: Reglament/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reglament/Delete/5
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
