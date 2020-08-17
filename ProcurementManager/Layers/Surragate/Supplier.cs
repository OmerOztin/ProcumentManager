using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager
{
    public class Supplier
    {
        [Key]
        public int supplierID { get; set; }

        public string supplierName { get; set; } 
    }
}
