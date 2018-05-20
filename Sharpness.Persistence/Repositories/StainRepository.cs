using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;
using System.Data.Entity;

namespace Sharpness.Persistence.Repositories
{
    public class StainRepository:IStainRepository
    {
        
        public void Delete(Stain s)
        {
            var _context = new DataContext();
            _context.Stains.Remove(s);
            _context.SaveChanges();
        }



        public Stain GetStainByName(string Name)
        {
            var _context = new DataContext();
            return _context.Stains.Where(s => s.Name == Name)
                    .FirstOrDefault();
        }

        public IEnumerable<Stain> GetStains()
        {
            var _context = new DataContext();
            return _context.Stains.ToList();
        }

        public void Insert(string name)
        {
            var _context = new DataContext();
            var stain = new Stain { Name=name};
            _context.Stains.Add(stain);
            _context.SaveChanges();
        }

        public void Update(Stain s)
        {
            var _context= new DataContext();
            _context.Entry(s).State = EntityState.Modified;
            _context.SaveChanges();
            
        }
    }
}
