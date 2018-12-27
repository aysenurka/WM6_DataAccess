using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisSepeti.ViewModels
{
    public class CartViewModel
    {
        public List<SepetViewModel> CartModel { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int ShipVia { get; set; }
        public decimal Freight { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public string Address { get; set; }
    }
}
