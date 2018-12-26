using AlisverisSepeti.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlisverisSepeti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UrunleriGetir();
            MusterileriGetir();
            NakliyeleriGetir();
            CalisanlariGetir();
        }

        private void CalisanlariGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var calisanlar = db.Employees
                .OrderBy(x => x.FirstName)
                .Select(x => new EmployeeViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();

            cmbCalisan.DataSource = calisanlar;
        }

        private void NakliyeleriGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var nakliyeler = db.Orders
                .OrderBy(x => x.ShipName)
                .Select(x => x.ShipName)
                .ToList();

            cmbNakliye.DataSource = nakliyeler;
        }

        private void MusterileriGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var musteriler = db.Customers
                .OrderBy(x => x.ContactName)
                .Select(x => x.ContactName)
                .ToList();

            cmbMusteri.DataSource = musteriler;
        }

        private void UrunleriGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var urunler = db.Products
                .OrderBy(x => x.ProductName)
                .Select(x => new ProductViewModel() {
                    ProductName=x.ProductName,
                    UnitPrice=x.UnitPrice
                })
                .ToList();

            lstUrunler.DataSource = urunler;
        }
    }
}
