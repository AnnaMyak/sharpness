﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Entities
{
    public class Tissue
    {
        public Tissue() {
            TissueId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }
        [Key]
        public Guid TissueId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public DateTime Creation { get; set; }
        public ICollection<Report> Reports { get; set; }
        
        
    }
}
