using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProcurementManager
{
    public class Products
    {
        [Key]
        public int  productID  { get; set; }
        public string productName { get; set; }
        public string location { get; set; }
        public int identity { get; set; }

        public int supplierID { get; set; }

    }
}
