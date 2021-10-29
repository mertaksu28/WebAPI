using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
    }
}
