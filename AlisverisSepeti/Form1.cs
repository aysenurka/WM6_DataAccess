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
using AlisverisSepeti.BLL;
using Exception = System.Exception;

namespace AlisverisSepeti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<SepetViewModel> sepet = new List<SepetViewModel>();
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
                    EmployeeID = x.EmployeeID,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToList();

            cmbCalisan.DataSource = calisanlar;
        }

        private void NakliyeleriGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var nakliyeler = db.Shippers
                .OrderBy(x => x.CompanyName)
                .Select(x => x.CompanyName)
                .ToList();

            cmbNakliye.DataSource = nakliyeler;
        }

        private void MusterileriGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var musteriler = db.Customers
                .OrderBy(x => x.CompanyName)
                .Select(x => x.CompanyName)
                .ToList();

            cmbMusteri.DataSource = musteriler;
        }

        private void UrunleriGetir()
        {
            NorthwindSabahEntities db = new NorthwindSabahEntities();
            var urunler = db.Products
                .OrderBy(x => x.ProductName)
                .Select(x => new ProductViewModel()
                {
                    ProductId = x.ProductID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice
                })
                .ToList();

            lstUrunler.DataSource = urunler;
        }

        private void txtAra_KeyUp(object sender, KeyEventArgs e)
        {
            string ara = txtAra.Text.ToLower();

            NorthwindSabahEntities db = new NorthwindSabahEntities();

            List<ProductViewModel> bulunanlar = new List<ProductViewModel>();

            db.Products
                .Where(x => x.ProductName.ToLower().Contains(ara) || x.Category.CategoryName.ToLower().Contains(ara))
                .ToList()
                .ForEach(x => bulunanlar.Add(new ProductViewModel()
                {
                    ProductId = x.ProductID,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice
                }));

            lstUrunler.DataSource = bulunanlar;
        }

        private void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null) return;

            var seciliUrun = lstUrunler.SelectedItem as ProductViewModel;
            bool varMi = false;
            var sepetteOlanUrun = new SepetViewModel();

            foreach (var sepetViewModel in sepet)
            {
                if (seciliUrun.ProductId == sepetViewModel.ProductID)
                {
                    varMi = true;
                    sepetteOlanUrun = sepetViewModel;
                    break;
                }
            }

            if (varMi) sepetteOlanUrun.Quantity++;
            else
            {
                sepet.Add(new SepetViewModel()
                {
                    ProductID = seciliUrun.ProductId,
                    ProductName = seciliUrun.ProductName,
                    UnitPrice = seciliUrun.UnitPrice ?? 0,
                    Quantity = 1,
                    Discount = 0,
                });
            }

            SepetHesapla();
        }

        private void SepetHesapla()
        {
            lstSepet.Items.Clear();
            foreach (var item in sepet)
            {
                lstSepet.Items.Add(item);
            }

            var tutar = sepet.Sum(x => x.UnitPrice * x.Quantity * Convert.ToDecimal(1 - x.Discount));
            lblSepetToplam.Text = $"Sepet Toplam: {tutar:c2}";
        }

        private void cikarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSepet.SelectedItem == null) return;

            var seciliSepet1 = lstSepet.SelectedItem as SepetViewModel;
            sepet.Remove(seciliSepet1);
            SepetHesapla();
        }

        private SepetViewModel seciliSepet;
        private void guncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstSepet.SelectedItem == null) return;

            seciliSepet=lstSepet.SelectedItem as SepetViewModel;
            pnlDetay.Visible = true;
            nuAdet.Value = seciliSepet.Quantity;
            nuIndirim.Value = Convert.ToDecimal(seciliSepet.Discount);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            foreach (var item in sepet)
            {
                if (seciliSepet.ProductID==item.ProductID)
                {
                    item.Discount = Convert.ToSingle(nuIndirim.Value);
                    item.Quantity = Convert.ToInt16(nuAdet.Value);
                    break;
                }
            }

            pnlDetay.Visible = false;
            seciliSepet = null;
            SepetHesapla();
        }

        private void btnSiparisVer_Click(object sender, EventArgs e)
        {
            if (!sepet.Any())
            {
                MessageBox.Show("Lutfen sepete urun ekleyiniz");
                return;
            }

            try
            {
                var orderBusiness = new OrderBusiness();
                var cartModel=new CartViewModel()
                {
                    CartModel = sepet,
                    CustomerID = (cmbMusteri.SelectedItem as Customer).CustomerID,
                    EmployeeID = (cmbCalisan.SelectedItem as EmployeeViewModel).EmployeeID,
                    ShipVia = (cmbNakliye.SelectedItem as Shipper).ShipperID,
                    Freight = nuNakliyeFiyat.Value,
                    RequiredDate = dtpTarih.Value,
                    Address = txtAdres.Text
                };

                var sipNo= orderBusiness.MakeOrder(cartModel);
                MessageBox.Show($"{sipNo} nolu siparisiniz basariyla olusturulmustur", "Siparis",MessageBoxButtons.OK,MessageBoxIcon.Information);
                sepet=new List<SepetViewModel>();
                SepetHesapla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
