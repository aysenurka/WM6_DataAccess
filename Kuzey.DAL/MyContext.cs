using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuzey.DAL
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyCon")
        {
        }
    }
}
