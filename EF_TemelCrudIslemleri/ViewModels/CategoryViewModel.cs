using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_TemelCrudIslemleri.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public override string ToString() => $"{CategoryName} - ({ProductCount})";
    }
}
