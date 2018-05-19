using Sharpness.Persistence.Entities;
using Sharpness.Persistence.Repositories;
using Sharpness.Persistence.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace Sharpness.WebApp.API
{
    [DataContract]
    public sealed class StainModel
    {
        [DataMember(IsRequired = true)]
        [Required]
        public string NewStain { get; set; }
    }
    public sealed class OrganModel
    {
        [DataMember(IsRequired = true)]
        [Required]
        public string newOrgan { get; set; }
    }

    public sealed class TissueModel
    {
        [DataMember(IsRequired = true)]
        [Required]
        public string newTissue { get; set; }
    }
    
    public class EntityManagementController : ApiController
    {
        private IStainRepository stainsRepo = new StainRepository();

        [HttpPost]
        public HttpResponseMessage Add(StainModel model)
        {
            var stain = new Stain
            {
                Name = model.NewStain
            };
            var stainVal = new StainValidator();
            
            if (model != null && ModelState.IsValid && stainVal.Validate(stain).IsValid)
            {
                    stainsRepo.Insert(model.NewStain);
                    return Request.CreateResponse(HttpStatusCode.Accepted, true);
                
            }
            return Request.CreateResponse(HttpStatusCode.Forbidden, "Wrong Data!");
        }

        /*[HttpPost]
        public HttpResponseMessage Remove(int domainId)
        {
            try
            {
                _domainRepository.RemoveDomain(domainId);
                _domainRepository.Save();
                return Request.CreateResponse(HttpStatusCode.Accepted, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Request.CreateResponse(HttpStatusCode.Forbidden, "Wrong Data!");
            }
        }*/


    }
}
