using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Repositories
{
    public interface IStainRepository
    {
        IEnumerable<Stain> GetStains();
        Stain GetStainById(Guid StainId);
        Stain GetStainByName (string Name);
        void Insert(string name);
        void Delete(Stain s);
        void Update(Stain s); 
    }
}
