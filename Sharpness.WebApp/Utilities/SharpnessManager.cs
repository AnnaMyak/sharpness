using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Emgu.CV;
using System.Drawing;
using System.IO;
using System.Text;
using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;

namespace Sharpness.WebApp.Utilities
{
    public class SharpnessManager : ISharpnessManager
    {
       

        public void GenerateSharpnessReport(string Stain, string Organ, string Tissue, Guid WSIId)
        {
            throw new NotImplementedException();
        }

        public int[] GetChannelsValues(byte[] SharpnessMap)
        {
            throw new NotImplementedException();
        }

        public Reglament GetReglament(string Stain, string Organ, string Tissue)
        {
            var _repoReglaments = new ReglamentRepository();
            
            //TODO

            return _repoReglaments.GetReglamentByTitel("Default");
        }

        public int[] GetSemaphoreValues(byte[] SharpnessMap)
        {
            throw new NotImplementedException();
        }
    }
}