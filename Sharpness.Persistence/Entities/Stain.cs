using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Entities
{
    public class Stain
    {

        public Stain() {
            Creation = DateTime.Now;
        }
        
        
        [StringLength(100, MinimumLength = 2)]
        [Required]
        [Key]
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public ICollection <Report> Reports { get; set; }

        

    }

}
