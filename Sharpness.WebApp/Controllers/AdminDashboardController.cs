using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;
using Sharpness.WebApp.Models;
using Sharpness.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sharpness.WebApp.Controllers
{
    public class AdminDashboardController : Controller
    {
        private IStainRepository _repoStains = new StainRepository();
        private IOrganRepository _repoOrgans = new OrganRepository();
        private ITissueRepository _repoTissues = new TissueRepository();
        private IWSIRepository _repoWSI = new WSIRepository();
        private IUserRepository _repoUsers = new UserRepository();
        private IReportRepository _repoReports = new ReportRepository();
        private IReglamentRepository _repoReglaments = new ReglamentRepository();

        //public IReglamentRepository _repoReglaments = new ReglamentRepository();
         
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Stains = _repoStains.GetStains();
            model.Organs = _repoOrgans.GetOrgans();
            model.Tissues = _repoTissues.GetTissues();
            model.Reports = _repoReports.GetAllReports();
            //löschen
            model.Users = _repoUsers.GetAllUsers();

            //get all admins
            var _appContext = new IdentitySample.Models.ApplicationDbContext();
            
            
            //model.WSIs = _repoWSI.GetWSIs();
            //model.Reglaments = _repoReglaments.GetAllReglaments();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult WSIs()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.WSIs = _repoWSI.GetWSIs();
            model.Users = _repoUsers.GetAllUsers();
            model.Reports = _repoReports.GetAllReports();

            foreach (var item in model.WSIs)
            {
                item.UserId = _repoUsers.GetUserById(item.UserId).Email;
            }
           

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Users = _repoUsers.GetAllUsers();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult WSIToReport(Guid WSIId)
        {
            var report = _repoReports.GetReportByWSI(WSIId);
            return RedirectToAction("Report", "ControlPanel", new { ReportId = report.ReportId });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Reglaments()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Reglaments = _repoReglaments.GetAllReglaments();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddReglament(Reglament reglament)
        {
          
                
                _repoReglaments.Insert(new Reglament {
                    Titel =reglament.Titel,
                    SharpnessThresholdValue =reglament.SharpnessThresholdValue,
                    Scaling=reglament.Scaling,
                    Edges=reglament.Edges,
                    TileSize=reglament.TileSize,
                    AcceptanceValue=reglament.AcceptanceValue});
            
            return RedirectToAction("Reglaments");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteReglament(string Titel)
        {
            _repoReglaments.Delete(_repoReglaments.GetReglamentByTitel(Titel));
            return RedirectToAction("Reglaments");
        }



        public JsonResult WelcomeNote()
        {
            bool isAdmin = false;
            //TODO: Check the user if it is admin or normal user, (true-Admin, false- Normal user)  
            string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";

            return Json(output, JsonRequestBehavior.AllowGet);
        }

       
    }
}