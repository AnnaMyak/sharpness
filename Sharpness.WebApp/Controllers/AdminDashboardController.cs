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
        public IStainRepository _repoStains = new StainRepository();
        public IOrganRepository _repoOrgans = new OrganRepository();
        public ITissueRepository _repoTissues = new TissueRepository();
        public IWSIRepository _repoWSI = new WSIRepository();
        public IUserRepository _repoUsers = new UserRepository();

        //public IReglamentRepository _repoReglaments = new ReglamentRepository();
        #region ActionControllers  
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Stains = _repoStains.GetStains();
            model.Organs = _repoOrgans.GetOrgans();
            model.Tissues = _repoTissues.GetTissues();
            //model.Users = _repoUsers.GetAllUsers();
           

            //model.WSIs = _repoWSI.GetWSIs();
            //model.Reglaments = _repoReglaments.GetAllReglaments();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult WSIs()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.WSIs = _repoWSI.GetWSIs();
            
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Users = _repoUsers.GetAllUsers();

            return View(model);
        }

        public JsonResult WelcomeNote()
        {
            bool isAdmin = false;
            //TODO: Check the user if it is admin or normal user, (true-Admin, false- Normal user)  
            string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";

            return Json(output, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}