using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Entities
{
    public class Reglament
    {

        public Reglament()
        {
            ReglamentId = System.Guid.NewGuid();
            Creation = DateTime.Now;
        }
        [Key]
        public Guid ReglamentId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Titel { get; set; }
        [Range(0, 1)]
        [Required]
        public double SharpnessThresholdValue { get; set; }
        [Range(0, 1)]
        [Required]
        public double Scaling { get; set; }
        [Range(1, 200)]
        [Required]
        public int Edges { get; set; }
        [Range(1, 512)]
        [Required]
        public int TileSize { get; set; }
        // Sharp Area in %
        [Range(1, 100)]
        [Required]
        public int AcceptanceValue { get; set; }
        [Required]
        public bool Status { get; set; }
        public DateTime Creation { get; set; }
        
        
        
        
        public ICollection<Report> Reports { get; set; }
        
        

    }
}
