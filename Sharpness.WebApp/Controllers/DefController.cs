using Sharpness.WebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sharpness.WebApp.Controllers
{

    public class PersonModel
    {


        ///<summary>
        /// Gets or sets Name.
        ///</summary>
        [Key]
        public string Name { get; set; }

        ///<summary>
        /// Gets or sets Gender.
        ///</summary>
        public string Gender { get; set; }

        ///<summary>
        /// Gets or sets City.
        ///</summary>
        public string City { get; set; }
    }



    public class DefController : Controller
    {



        public ActionResult Sample()
        {

            return View();
        }
        public ActionResult Sample2()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonModel person)
        {
          
            string name = person.Name;
            string gender = person.Gender;
            string city = person.City;

            return RedirectToAction("Sample");
        }

       
    }

        
}
