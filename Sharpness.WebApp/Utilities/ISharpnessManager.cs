using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.WebApp.Utilities
{
    public interface ISharpnessManager
    {
        Reglament GetReglament(string Stain, string Organ, string Tissue);

        
        double[] GetSemaphoreValues(string path);
        double[] GetChannelsValues(string path);


    }
}
