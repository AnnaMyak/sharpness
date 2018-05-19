using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Validators;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence
{
    public class InitDataContext
    {
        public InitDataContext()
        {
            /* var _context = new DataContext();

             var stains = new List<Stain>
             {
                 new Stain {Name="HE"},
                 new Stain {Name="Periodic Acid Schiff (PAS)"},
                 new Stain {Name="Giemsa"},
                 new Stain {Name="Iron (Prussian Blue)" },
                 new Stain {Name="HC" },
                 new Stain {Name= "Alcian Blue" },
                 new Stain {Name="Alcian Blue+PAS" },
                 new Stain {Name ="Gomori Trichrome blue"},
                 new Stain {Name ="Gomori Trichrome green"},
                 new Stain {Name ="EvG" },
                 new Stain {Name="AFB" },
                 new Stain {Name="GMS" },
                 new Stain {Name ="Gram" },
                 new Stain {Name ="Toluidine Blue" },
                 new Stain {Name ="Acid fast" },
                 new Stain {Name ="Congo red for amyloid"},
                 new Stain {Name ="Jones methenamine silver for basement membrane and mesangium" },
                 new Stain {Name ="Sudan black for lipids & lipochrome pigments" },
                 new Stain {Name ="Verhoeff's method for elastin" },
                 new Stain {Name ="Warthin-Starry method for bacteria" },
                 new Stain {Name="Weigert’s iron hematoxylin" },
                 new Stain {Name ="Electron micrograph (EM)" },
                 new Stain {Name ="Methenamine Silver" },
                 new Stain {Name="Jones’ Basement Membrane" },
                 new Stain {Name ="DMABR"}


             };

             stains.ForEach(s => _context.Stains.Add(s));
             _context.SaveChanges();
             var organs = new List<Organ> {
                 new Organ {Name="Organ" },
                 new Organ {Name="Liver" },
                 new Organ {Name="Kidney" },
                 new Organ {Name="Lung" },
                 new Organ {Name="Spleen" },
                 new Organ {Name ="Heart" },
                 new Organ {Name ="Skin" },
                 new Organ {Name ="Intestine" },
                 new Organ {Name ="Submucosa" },
                 new Organ {Name ="Stomach" },
                 new Organ {Name="Urinary bladder"},
                 new Organ {Name ="Gallbladder" },
                 new Organ {Name="Blood vessel" },
                 new Organ {Name="Muscles" },
                 new Organ {Name="Thyroid"},
                 new Organ {Name="Skeleton" },
                 new Organ {Name="Breast" },
                 new Organ {Name="Vagina" },
                 new Organ {Name="Uterus"},
                 new Organ {Name= "Ovar" },
                 new Organ {Name="Cervix" },
                 new Organ {Name="Prostate" }
             };
             organs.ForEach(o => _context.Organs.Add(o));

             _context.SaveChanges();

             var reglament = new Reglament
             { Titel = "Default ",
               AcceptanceValue = 70,
               Edges = 200,
               Scaling = 1.0,
               SharpnessThresholdValue = 0.3,
               TileSize = 512,
               Status=true,
             };
             _context.Reglaments.Add(reglament);
             _context.SaveChanges();

     */

            var _context = new DataContext();
            var wsis = _context.WSIs.ToList();
            var repots = new ArrayList();
            var tissue = _context.Tissues.Where(t => t.Name == "Tissue").FirstOrDefault();
            var organ = _context.Organs.Where(t => t.Name == "Organ").FirstOrDefault();
            var stain = _context.Stains.Where(t => t.Name == "HE").FirstOrDefault();
            foreach (var item in wsis)
            {
                _context.Reports.Add(
                    new Report{
                        UserId=item.UserId,
                        WSIId=item.WSIId,
                        OrganId=organ.OrganId,
                        TissueId=tissue.TissueId,
                        StainId=stain.StainId,



                    });
            } 

        }

    }
}
