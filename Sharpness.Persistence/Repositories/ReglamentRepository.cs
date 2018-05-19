using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharpness.Persistence.Entities;
using System.Data.Entity;

namespace Sharpness.Persistence.Repositories
{
    public class ReglamentRepository : IReglamentRepository
    {
        public void Delete(Reglament r)
        {
            var _context = new DataContext();
            _context.Reglaments.Remove(r);
            _context.SaveChanges();
        }

        public IEnumerable<Reglament> GetAllReglaments()
        {
            var _context = new DataContext();
            return _context.Reglaments.ToList();

        }

        public Reglament GetReglamentById(Guid ReglamentId)
        {
            var _context = new DataContext();
            return _context.Reglaments.Find(ReglamentId);
        }

        public Reglament GetReglamentByTitel(string Titel)
        {
            var _context = new DataContext();
            return _context.Reglaments.Where(r => r.Titel == Titel).FirstOrDefault();
        }

        public void Insert(Reglament r)
        {
            var _context = new DataContext();
            _context.Reglaments.Add(r);
            _context.SaveChanges();
        }

        public void Update(Reglament r)
        {
            var _context = new DataContext();
            _context.Entry(r).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
