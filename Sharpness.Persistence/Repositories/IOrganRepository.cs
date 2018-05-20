using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Repositories
{
    public interface IOrganRepository
    {
        IEnumerable<Organ> GetOrgans();
        
        Organ GetOrganByName(string Name);
        void Insert(Organ o);
        void Delete(Organ o);
        void Update(Organ o);
    }
}
