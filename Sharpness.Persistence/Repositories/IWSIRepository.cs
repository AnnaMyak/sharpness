using Sharpness.Persistence.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Repositories
{
    public interface IWSIRepository
    {
        IEnumerable<WSI> GetWSIs();
        WSI GetById(Guid WSIId);
        WSI GetByTitel(string Titel);
        IEnumerable<WSI> GetAllWSIByUserId(string UserId);
        IEnumerable<WSI> GetRecentWSIByUSerId(string UserId);
        void Insert(WSI w);
        void Delete(WSI w);
        void Update(WSI w);
        

        //Common
        int GetTotalNumberOfWSIs();
        int GetTotalNumberOfWSIsByUser(string UserId);
    }
}
