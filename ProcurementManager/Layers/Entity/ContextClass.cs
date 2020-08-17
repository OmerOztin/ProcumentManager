using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProcurementManager
{
    public class ContextClass : DbContext
    {
        public ContextClass() : base("ProductDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextClass>());
            
        }

        public DbSet <Products> Productss { get; set; }
    }

}
