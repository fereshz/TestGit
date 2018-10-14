using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DatabaseContextInitializer:
        System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        public DatabaseContextInitializer()
        {

        }

        protected override void Seed(DatabaseContext databasecontext)
        {
            base.Seed(databasecontext);

            Models.Person person = null;

            for (int index = 1; index <= 10; index++)
            {
                person = new Person()
                {
                    Name = "Ali" + index,
                    Age = 20 + index,
                    IsActive=true,
                    
                };

                databasecontext.People.Add(person);
            }


            databasecontext.SaveChanges();
        }
    }
}