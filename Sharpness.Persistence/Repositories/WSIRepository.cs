using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;
using System.Data.Entity;
using System.Collections;

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
            return _context.WSIs.Where(w => w.UserId == UserId).OrderByDescending(w=>w.Creation ).ToList();
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

        public IEnumerable<WSI> GetRecentWSIByUSerId(string UserId)
        {
            var _context = new DataContext();
            var wsis = _context.WSIs.Where(w=>w.UserId==UserId).OrderByDescending(w=>w.Creation).ToList();
            var num = wsis.Count;
           
            if (wsis.Count == 1)
            {
                var results = new List<WSI>();

                results.Add(wsis.ElementAt(0));
                return results;
            }
            if (wsis.Count == 2)
            {
                var results = new List<WSI>();

                results.Add(wsis.ElementAt(0));
                results.Add(wsis.ElementAt(1));
                
                return results;
            }
            if (wsis.Count >= 3)
            {
                var results = new List<WSI>();

                results.Add(wsis.ElementAt(0));
                results.Add(wsis.ElementAt(1));
                results.Add(wsis.ElementAt(2));
                return results;
            }
            else
                return new List<WSI>();

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
