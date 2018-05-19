using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext() : base("SharpnessControlDB")
        {
        }

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Organ> Organs { get; set; }
        public virtual DbSet<Reglament> Reglaments { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Stain> Stains { get; set; }
        public virtual DbSet<Tissue> Tissues { get; set; }

        public virtual DbSet<WSI> WSIs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());

        }

        
    }
}
