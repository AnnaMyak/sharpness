using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;
using System.Data.Entity;

namespace Sharpness.Persistence.Repositories
{
    public class OrganRepository : IOrganRepository
    {
        public void Delete(Organ o)
        {
            var _context = new DataContext();
            _context.Organs.Remove(o);
            _context.SaveChanges();
        }

        public Organ GetOrganById(Guid OrganId)
        {
            var _context = new DataContext();
            return _context.Organs.Find(OrganId);
        }

        public Organ GetOrganByName(string Name)
        {
            var _context = new DataContext();
            return _context.Organs.Where(o => o.Name==Name).FirstOrDefault();
        }

        public IEnumerable<Organ> GetOrgans()
        {
            var _context = new DataContext();
            return _context.Organs.ToList();
        }

        public void Insert(Organ o)
        {
            var _context = new DataContext();
            _context.Organs.Add(o);
            _context.SaveChanges();
        }

        public void Update(Organ o)
        {
            var _context = new DataContext();
            _context.Entry(o).State= EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
