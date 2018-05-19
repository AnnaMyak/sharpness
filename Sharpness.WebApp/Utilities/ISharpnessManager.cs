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

        void GenerateSharpnessReport(string Stain, string Organ, string Tissue, Guid WSIId);

        int[] GetSemaphoreValues(byte[] SharpnessMap);
        int[] GetChannelsValues(byte[] SharpnessMap);
        

    }
}
