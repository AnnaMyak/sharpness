using Microsoft.AspNet.Identity;
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
    public class DashboardController : Controller
    {
        //private IW _userRepo= new UserRepository();
        private IWSIRepository _repoWSIs= new WSIRepository();

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.WSIs = _repoWSIs.GetAllWSIByUserId(User.Identity.GetUserId());
            return View(model);
        }
    }
}