using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Role:BaseEntity
    {
        internal class Configuration :
            System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Models.Role>
        {
            public Configuration()
            {

            }
        }
        public Role()
        {

        }

        [System.ComponentModel.DataAnnotations.Required
            (AllowEmptyStrings =false)]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public virtual System.Collections.Generic.IList<Person> People { get; set; }
    }
}
