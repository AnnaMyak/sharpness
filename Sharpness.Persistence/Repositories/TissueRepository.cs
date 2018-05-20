using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;
using System.Data.Entity;

namespace Sharpness.Persistence.Repositories
{
    public class TissueRepository : ITissueRepository
    {
        public void Delete(Tissue t)
        {
            var _context = new DataContext();
            _context.Tissues.Remove(t);
            _context.SaveChanges();
        }

        

        public Tissue GetTissueByName(string Name)
        {
            var _context = new DataContext();
            return _context.Tissues.Where(t => t.Name == Name).FirstOrDefault();
        }

        public IEnumerable<Tissue> GetTissues()
        {
            var _context = new DataContext();
            return _context.Tissues.ToList();
        }

        public void Insert(Tissue t)
        {
            var _context = new DataContext();
            _context.Tissues.Add(t);
            _context.SaveChanges();
        }

        public void Update(Tissue t)
        {
            var _context = new DataContext();
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
