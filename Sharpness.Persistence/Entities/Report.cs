using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Entities
{
    public class Report
    {
        public Report()
        {
            ReportId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }

        public Guid ReportId { get; set; }
        //UserId
        public string UserId { get; set; }




        public Guid WSIId { get; set; }
        public Guid ReglamentId { get; set; }

        public string StainName { get; set; }
        public string OrganName { get; set; }
        public string TissueName { get; set; }




        
       
                
        //First Sharpness Map
        //in %
        public int Semaphore_Green { get; set; }
        public int Semaphore_Yellow { get; set; }
        public int Semaphore_Red { get; set; }



        public string ReportLink { get; set; }
        public string SharpnessMapPath { get; set; }
        


        public bool Evaluation { get; set; }
        public string Comment { get; set; }
        public DateTime Creation { get; set; }


        [ForeignKey("WSIId")]
        public  WSI WSI { get; set; }
        
        [ForeignKey("ReglamentId")]
        public Reglament Reglament {get; set;}
        [ForeignKey("StainName")]
        public Stain Stain { get; set; }
        [ForeignKey("OrganName")]
        public Organ Organ { get; set; }
        [ForeignKey("TissueName")]
        public Tissue Tissue { get; set; }


    }
}
