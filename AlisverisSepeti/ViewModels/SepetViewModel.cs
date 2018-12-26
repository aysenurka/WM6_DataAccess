using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisSepeti.ViewModels
{
    public class SepetViewModel
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; } = 0;
        public short Quantity { get; set; } = 1;
        public float Discount { get; set; } = 0;

        public override string ToString() =>
            $"{ProductName} x {Quantity} = {Quantity * UnitPrice * Convert.ToDecimal(1 - Discount):c2}";
    }
}
