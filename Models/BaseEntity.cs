using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = System.Guid.NewGuid();
        }
         public System.Guid Id { get; set; }
    }
}
