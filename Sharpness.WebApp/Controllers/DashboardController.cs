﻿using Microsoft.AspNet.Identity;
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
    
    public class DashboardController : Controller
    {
        //private IW _userRepo= new UserRepository();
        private IWSIRepository _repoWSIs= new WSIRepository();
        private IReportRepository _repoReports = new ReportRepository();
        private IUserRepository _repoUsers = new UserRepository();
        private SharpnessViewModels model;

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            model = new SharpnessViewModels();
            model.WSIs = _repoWSIs.GetAllWSIByUserId(User.Identity.GetUserId());
            model.Reports = _repoReports.GetAllReportsByUserId(User.Identity.GetUserId());
            model.RecentWSIs = (IList<WSI>)_repoWSIs.GetRecentWSIByUSerId(User.Identity.GetUserId());


            ViewBag.TestTotal = _repoReports.GetTotalNumberOfTestsByUserId(User.Identity.GetUserId());
            ViewBag.TestTotalThisWeek = _repoReports.GetTotalNumberOfTestsForLastWeekByUserId(User.Identity.GetUserId());
            ViewBag.TestTotalThisMonth = _repoReports.GetTotalNumberOfTestsForLastMonthByUserId(User.Identity.GetUserId());
            ViewBag.TestTotalThisYear = _repoReports.GetTotalNumberOfTestsForLastYearByUserId(User.Identity.GetUserId());
            ViewBag.NegativeTests = _repoReports.GetTotalNumberOfNegativeTestsByUserId(User.Identity.GetUserId());
            ViewBag.PositiveTests = _repoReports.GetTotalNumberOfPositiveTestsByUserId(User.Identity.GetUserId());
            return View(model);
        }





        [Authorize(Roles = "Admin")]
        public ActionResult AdminToUserDashboard(string UserId)
        {
            model = new SharpnessViewModels();
            model.WSIs = _repoWSIs.GetAllWSIByUserId(UserId);
            model.Reports = _repoReports.GetAllReportsByUserId(UserId);
            model.RecentWSIs = (IList<WSI>)_repoWSIs.GetRecentWSIByUSerId(UserId);

            ViewBag.CurrentUserId = UserId;
            ViewBag.CurrentUserName = _repoUsers.GetUserById(UserId).UserName;
            ViewBag.TestTotal = _repoReports.GetTotalNumberOfTestsByUserId(UserId);
            ViewBag.TestTotalThisWeek = _repoReports.GetTotalNumberOfTestsForLastWeekByUserId(UserId);
            ViewBag.TestTotalThisMonth = _repoReports.GetTotalNumberOfTestsForLastMonthByUserId(UserId);
            ViewBag.TestTotalThisYear = _repoReports.GetTotalNumberOfTestsForLastYearByUserId(UserId);
            ViewBag.NegativeTests = _repoReports.GetTotalNumberOfNegativeTestsByUserId(UserId);
            ViewBag.PositiveTests = _repoReports.GetTotalNumberOfPositiveTestsByUserId(UserId);
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