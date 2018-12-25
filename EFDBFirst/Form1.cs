using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDBFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // tüm ürünleri listeleyelim
            NorthwindSabahEntities db = new NorthwindSabahEntities();

            // product üzerinden ilerlendiği için tüm productlar gözükmeli yani tüm productlar gözükmeli yani left join
            var sorgu1 = db.Products
                .Select(x => new
                {
                    x.ProductName,
                    x.UnitPrice,
                    x.Category.CategoryName
                })
                .ToList();
            //dgvTest.DataSource = sorgu1;

            // burada ilişki kurulduğu için ilşişkideki kurala göre inner join çalışır
            var sorgu2 = from p in db.Products
                         join c in db.Categories on p.CategoryID equals c.CategoryID
                         select new
                         {
                             UrunAd = p.ProductName,
                             UrunFiyat = p.UnitPrice,
                             UrunKategori = c.CategoryName
                         };
            //dgvTest.DataSource = sorgu2.ToList();

            // çalışanlarımı email adresleri ile listeleyelim
            var sorgu3 = db.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Email = (x.FirstName.Substring(0, 1) + x.LastName + "@northwind.com").ToLower()
                }).ToList();
            //dgvTest.DataSource = sorgu3;

            var sorgu4 = from emp in db.Employees
                         select new
                         {
                             emp.FirstName,
                             emp.LastName,
                             Email = (emp.FirstName.Substring(0, 1) + emp.LastName + "@northwind.com").ToLower()
                         };
            //dgvTest.DataSource = sorgu4.ToList();

            this.Text = $"{db.Products.Average(x => x.UnitPrice):c2}";

            var sorgu5 = db.Products // lambda expression
                .Where(x => x.UnitPrice >= db.Products.Average(y => y.UnitPrice))
                .Select(x => new
                {
                    x.ProductName,
                    Fiyat = x.UnitPrice,
                    x.Category.CategoryName
                })
                .OrderByDescending(x => x.Fiyat)
                .ToList();
            //dgvTest.DataSource = sorgu5;

            var sorgu6 = from p in db.Products // linq
                         where p.UnitPrice >= db.Products.Average(x => x.UnitPrice)
                         orderby p.UnitPrice descending
                         select new
                         {
                             p.ProductName,
                             Fiyat = p.UnitPrice,
                             p.Category.CategoryName
                         };
            //dgvTest.DataSource = sorgu6.ToList();

            // hangi kategoriden kaç tane ürünüm var
            var sorgu7 = db.Products
                .Where(x => x.CategoryID.HasValue && x.SupplierID.HasValue)
                //.GroupBy(x => x.Category.CategoryName)
                .GroupBy(x => new { x.Category.CategoryName, x.Supplier.CompanyName })
                .Select(x => new
                {
                    //CategoryName = x.Key,
                    CategoryName = x.Key.CategoryName,
                    CompanyName = x.Key.CompanyName,
                    Total = x.Count()
                })
                .OrderBy(x => x.CategoryName)
                .ThenBy(x => x.CompanyName)
                .ToList();
            //dgvTest.DataSource = sorgu7;

            var sorgu8 = from p in db.Products
                         join c in db.Categories on p.CategoryID equals c.CategoryID
                         join s in db.Suppliers on p.SupplierID equals s.SupplierID
                         group new
                         {
                             c,
                             s
                         }
                         by new
                         {
                             c.CategoryName,
                             s.CompanyName
                         } into gp
                         orderby gp.Key.CategoryName ascending, gp.Key.CategoryName ascending
                         select new
                         {
                             CategoryName = gp.Key.CategoryName,
                             CompanyName = gp.Key.CompanyName,
                             Total = gp.Count()
                         };
            //dgvTest.DataSource = sorgu8.ToList();

            // hangi üründen ne kadarlık sipariş verilmiş(tl bazında)
            //var sorgu9 = db.Products
            //    .Join(db.Order_Details,
            //    p => p.ProductID,
            //    od => od.ProductID,
            //    (p, od) => new { p, od })
            //    .GroupBy(x => new { x.p.ProductName, x.od.OrderID })
            //    .OrderBy(x => x.Key.OrderID)
            //    .Select(x => new
            //    {
            //        x.Key.OrderID,
            //        x.Key.ProductName,
            //        Total = x.Sum(y => y.od.UnitPrice * y.od.Quantity)
            //    }).ToList();
            //dgvTest.DataSource = sorgu9;

            var sorgu9 = db.Order_Details
                .Join(db.Products,
                od => od.ProductID,
                product => product.ProductID,
                (od, product) => new { od, product })
                .GroupBy(x => x.product.ProductName)
                .OrderBy(x => x.Key)
                .ToList()
                .Select(x => new
                {
                    x.Key,
                    Total = Math.Round(x.Sum(y => y.od.UnitPrice * y.od.Quantity * Convert.ToDecimal(1 - y.od.Discount)), 2)
                });
            //dgvTest.DataSource = sorgu9.ToList();

            //var sorgu10 = from p in db.Products
            //              join od in db.Order_Details on p.ProductID equals od.ProductID
            //              group new
            //              {
            //                  p,
            //                  od
            //              }
            //              by new
            //              {
            //                  p.ProductName
            //              }
            //              into gp
            //              orderby gp.Key.ProductName
            //              select new
            //              {
            //                  gp.Key.ProductName,
            //                  Total = gp.Sum(x => x.od.UnitPrice * x.od.Quantity*Convert.ToDecimal(1-x.od.Discount))
            //              };
            //dgvTest.DataSource = sorgu10.ToList();

            var sorgu10 = from prod in db.Products
                          join od in db.Order_Details on prod.ProductID equals od.ProductID
                          group new
                          {
                              prod,
                              od
                          } by new
                          {
                              prod.ProductName
                          }
                into gp
                          orderby gp.Key.ProductName
                          select new
                          {
                              gp.Key.ProductName,
                              Total = gp.Sum(x => x.od.UnitPrice * x.od.Quantity)
                          };
            //dgvTest.DataSource = sorgu10.ToList();

            // çalışanlarım kaç tane sipariş almış
            //select e.EmployeeID,e.FirstName,sum(od.Quantity) from Employees e
            //inner join Orders o on e.EmployeeID = o.EmployeeID
            //inner join [Order Details] od on o.OrderID = od.OrderID
            //group by e.EmployeeID,e.FirstName

            var sorgu11 = from emp in db.Employees
                          join o in db.Orders on emp.EmployeeID equals o.EmployeeID
                          join od in db.Order_Details on o.OrderID equals od.OrderID
                          group new
                          {
                              emp,
                              //o,
                              od
                          } by new
                          {
                              emp.EmployeeID,
                              emp.FirstName
                          } into gp
                          orderby gp.Key.EmployeeID, gp.Key.FirstName
                          select new
                          {
                              gp.Key.EmployeeID,
                              gp.Key.FirstName,
                              Total = gp.Sum(x => x.od.Quantity)
                          };
            //dgvTest.DataSource = sorgu11.ToList();

            //var sorgu 12=db.Order_Details
            //    .Join(db.or)

            // hangi kategoriden toplam kaç adet siparişim var
            //select p.ProductName,sum(od.Quantity) as Toplam from Categories c
            //join Products p on c.CategoryID = p.CategoryID
            //join [Order Details] od on od.ProductID = p.ProductID
            //group by p.ProductName
            //order by Toplam

            var sorgu13 = from c in db.Categories
                          join p in db.Products on c.CategoryID equals p.CategoryID
                          join od in db.Order_Details on p.ProductID equals od.ProductID
                          group new {
                              p,
                              c, od
                          } by new {
                              p.ProductName,
                              c.CategoryName
                          } into gp
                          //orderby gp.Key.ProductName
                          select new {
                              gp.Key.ProductName,
                              gp.Key.CategoryName,
                              Total = gp.Sum(x => x.od.Quantity)
                          };
            //dgvTest.DataSource = sorgu13.OrderByDescending(x=>x.Total).ToList();

            // sipariş no - toplam sipariş tutarı
            // select many, groupjoin

            // çalışanlarım hangi kategoriden kaç tane sipariş vermiş
            //select e.EmployeeID,e.FirstName,c.CategoryName,sum(od.Quantity) as toplam from Employees e
            //join Orders o on e.EmployeeID = o.EmployeeID
            //join [Order Details] od on o.OrderID = od.OrderID
            //join Products p on p.ProductID = od.ProductID
            //join Categories c on p.CategoryID = c.CategoryID
            //group by e.EmployeeID,e.FirstName,c.CategoryName
            //order by toplam

            var sorgu17 = from dbEmp in db.Employees
                          join dbO in db.Orders on dbEmp.EmployeeID equals dbO.EmployeeID
                          join dbOd in db.Order_Details on dbO.OrderID equals dbOd.OrderID
                          join dbP in db.Products on dbOd.ProductID equals dbP.ProductID
                          join dbC in db.Categories on dbP.CategoryID equals dbC.CategoryID
                          group new
                          {
                              dbEmp,
                              dbC,
                              //dbP,
                              dbOd
                          } by new
                          {
                              //dbEmp.EmployeeID,
                              dbEmp.FirstName,
                              dbC.CategoryName,
                              //dbOd.Quantity
                          } into gp
                          select new
                          {
                              //gp.Key.EmployeeID,
                              gp.Key.FirstName,
                              gp.Key.CategoryName,
                              Total = gp.Sum(x => x.dbOd.Quantity)
                          };
            dgvTest.DataSource = sorgu17.OrderByDescending(x => x.Total).ToList();


        }
    }
}
