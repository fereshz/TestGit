using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatabaseContext:System.Data.Entity.DbContext
    {
        public DatabaseContext():base()
        {

        }

        static DatabaseContext()
        {
            System.Data.Entity.Database.SetInitializer
                        (new DatabaseContextInitializer());
        }

        public System.Data.Entity.DbSet<Models.Person> People { get; set; }
        public System.Data.Entity.DbSet<Models.Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Role.Configuration());
            modelBuilder.Configurations.Add(new Person.Configuration());
        }
    }
}
