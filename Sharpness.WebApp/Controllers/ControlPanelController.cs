using Microsoft.AspNet.Identity;
using Sharpness.Persistence;
using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;
using Sharpness.WebApp.Models;
using Sharpness.WebApp.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sharpness.WebApp.Controllers
{
    


    public class ControlPanelController : Controller
    {
        private IStainRepository _repoStains = new StainRepository();
        private IOrganRepository _repoOrgans = new OrganRepository();
        private IWSIRepository _repoWSIs = new WSIRepository();
        private IReglamentRepository _repoReglaments = new ReglamentRepository();
        private ISharpnessManager manager = new SharpnessManager();
        private ITissueRepository _repoTissues = new TissueRepository();
        
        
        // GET: ControlPanel
        [Authorize]
        public ActionResult Index()
        {
            SharpnessViewModels model = new SharpnessViewModels();
            model.Organs = _repoOrgans.GetOrgans();
            model.Stains = _repoStains.GetStains();
            model.Tissues = _repoTissues.GetTissues();
            ViewBag.Stains = new SelectList(model.Stains, "Name", "Name");
            ViewBag.Organs = new SelectList(model.Organs, "Name", "Name");
            ViewBag.Tissues = new SelectList(model.Tissues,"Name","Name");
            return View(model);
        }

        [Authorize]
        public ActionResult Report(string Link)
        {

            ViewBag.ViewerLink = "http://localhost:5000/Sharpness_WebApp_Uploads/"+Link;

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, WSI wsi, Stain stain, Organ organ, Tissue tissue)
        {

            //TODO
            //Today only one value possible
            //var tissue = _repoTissues.GetTissueByName("Tissue");

            //
            var root = @"C:\Users\AnnaToshiba2\Desktop\WSI\Sharpness_WebApp_Uploads\";
            var fileName = "";
            
            
            string outputDir = Path.Combine(Path.GetDirectoryName(root), User.Identity.GetUserName(),"WSI "+wsi.Titel);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            if (file.ContentLength > 0)
            {
                fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(outputDir, fileName);
                file.SaveAs(path);

                wsi.WSIId = Guid.NewGuid();
                wsi.Path = path;
                wsi.UserId = User.Identity.GetUserId();
                _repoWSIs.Insert(wsi);
                
            }

            //only Default-rules possible 
            //var reglament = manager.GetReglament(stain.Name,organ.Name,tissue.Name);
           // var report = manager.GenerateSharpnessReport(stain.Name, organ.Name,tissue.Name); 




            var reportLink = User.Identity.GetUserName() + "/" + "WSI " + wsi.Titel + "/" + fileName;

            return RedirectToAction("Report", new {Link=reportLink});
        }


        
    }
}