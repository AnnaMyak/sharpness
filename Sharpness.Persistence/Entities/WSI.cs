using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Entities
{
    public class WSI
    {
        public WSI()
        {
            WSIId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }

        [Key]
        public Guid WSIId { get; set; }
        public string UserId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Titel { get; set; }
        
        public string Description { get; set; }
        public string Path { get; set; }

        public DateTime Creation { get; set; }


        

        public ICollection<Report> Reports { get; set; }
    }
}
