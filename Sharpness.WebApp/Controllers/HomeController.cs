using Microsoft.AspNet.Identity;
using Sharpness.Persistence;
using Sharpness.Persistence.Entities;
using Sharpness.WebApp.Utilities;
using System.Web.Mvc;


namespace IdentitySample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var s= new InitDataContext();
            //ISharpnessManager manager = new SharpnessManager();
            //manager.GenerateSharpnessReport();
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
