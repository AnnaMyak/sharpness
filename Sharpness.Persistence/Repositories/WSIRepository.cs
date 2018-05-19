using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;
using System.Data.Entity;

namespace Sharpness.Persistence.Repositories
{
    public class WSIRepository: IWSIRepository
    {
         public WSIRepository() { }

        public void Delete(WSI w)
        {
            var _context = new DataContext();
            _context.WSIs.Remove(w);
            _context.SaveChanges();
            
        }
        public IEnumerable<WSI> GetAllWSIByUserId(string UserId)
        {
            var _context = new DataContext();
            return _context.WSIs.Where(w => w.UserId == UserId).ToList();
        }

        public WSI GetById(Guid WSIId)
        {
            var _context = new DataContext();
            return _context.WSIs.Find(WSIId);
        }

        public WSI GetByTitel(string Titel)
        {
            var _context = new DataContext();
            return _context.WSIs.Where(w=> w.Titel==Titel).FirstOrDefault();
        }

        public int GetTotalNumberOfWSIs()
        {
            var _context = new DataContext();

            return _context.WSIs.ToList().Count;
        }

        
        public int GetTotalNumberOfWSIsByUser(string UserId)
        {
            var _context = new DataContext();
            return _context.WSIs.Where(w => w.UserId == UserId).ToList().Count;
        }

        

        public IEnumerable<WSI> GetWSIs()
        {
            var _context = new DataContext();
            return _context.WSIs.ToList();
        }

        public void Insert(WSI w)
        {
            var _context = new DataContext();
            _context.WSIs.Add(w);
            _context.SaveChanges();
        }

        public void Update(WSI w)
        {
            var _context = new DataContext();
            _context.Entry(w).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
