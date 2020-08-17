using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProcurementManager
{
    public class ContextClass2 : DbContext
    {
        public ContextClass2() : base("ProductDB")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ContextClass>());
            
        }

        public DbSet <Supplier> Supplierss { get; set; }
    }

}
