using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Repositories
{
    public interface ITissueRepository
    {
        IEnumerable<Tissue> GetTissues();
        Tissue GetTissueById(Guid TissueId);
        Tissue GetTissueByName(string Name);
        void Insert(Tissue t);
        void Delete(Tissue t);
        void Update(Tissue t);
    }
}
