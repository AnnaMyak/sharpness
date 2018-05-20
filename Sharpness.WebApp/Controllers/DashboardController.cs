using Microsoft.AspNet.Identity;
using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;
using Sharpness.WebApp.Models;
using Sharpness.WebApp.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sharpness.WebApp.Controllers
{
    public class Test
    {
        public string Titel { get; set; }
        public string Description  { get; set; }
        public Guid ReportId { get; set; }
        public DateTime Creation { get; set; }

    }
    public class DashboardController : Controller
    {
        //private IW _userRepo= new UserRepository();
        private IWSIRepository _repoWSIs= new WSIRepository();
        private IReportRepository _repoReports = new ReportRepository();
        private SharpnessViewModels model;

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            model = new SharpnessViewModels();
            model.WSIs = _repoWSIs.GetAllWSIByUserId(User.Identity.GetUserId());
            model.Reports = _repoReports.GetAllReportsByUserId(User.Identity.GetUserId());
           
            return View(model);
        }
        [Authorize]
        public ActionResult WSIToReport (Guid WSIId)
        {
            var report = _repoReports.GetReportByWSI(WSIId);
            return RedirectToAction("Report","ControlPanel", new { ReportId = report.ReportId });
        }

        public ActionResult AllMyTests()
        {
            model = new SharpnessViewModels();
            model.WSIs = _repoWSIs.GetAllWSIByUserId(User.Identity.GetUserId());
            return View(model);
        }

    }

    
}