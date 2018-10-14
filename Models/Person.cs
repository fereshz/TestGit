using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person : BaseEntity
    {
        internal class Configuration :
            System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Models.Person>
        {
            public Configuration()
            {
                HasOptional(current => current.Role)
                    .WithMany(role => role.People)
                    .HasForeignKey(current => current.RoleId)
                    .WillCascadeOnDelete(false);
            }
        }
        public Person() : base()
        {

        }

        public System.Guid? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsActive { get; set; }

    }
}
