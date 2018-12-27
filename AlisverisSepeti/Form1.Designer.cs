namespace AlisverisSepeti
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstUrunler = new System.Windows.Forms.ListBox();
            this.btnSepeteEkle = new System.Windows.Forms.Button();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.cmbNakliye = new System.Windows.Forms.ComboBox();
            this.cmbCalisan = new System.Windows.Forms.ComboBox();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.lstSepet = new System.Windows.Forms.ListBox();
            this.cmsSepet = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cikarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guncelleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSepetToplam = new System.Windows.Forms.Label();
            this.btnSiparisVer = new System.Windows.Forms.Button();
            this.pnlDetay = new System.Windows.Forms.Panel();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.nuIndirim = new System.Windows.Forms.NumericUpDown();
            this.nuAdet = new System.Windows.Forms.NumericUpDown();
            this.lblAdet = new System.Windows.Forms.Label();
            this.lblIndirim = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.nuNakliyeFiyat = new System.Windows.Forms.NumericUpDown();
            this.cmsSepet.SuspendLayout();
            this.pnlDetay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuIndirim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuAdet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuNakliyeFiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // lstUrunler
            // 
            this.lstUrunler.FormattingEnabled = true;
            this.lstUrunler.Location = new System.Drawing.Point(12, 50);
            this.lstUrunler.Name = "lstUrunler";
            this.lstUrunler.Size = new System.Drawing.Size(225, 264);
            this.lstUrunler.TabIndex = 0;
            // 
            // btnSepeteEkle
            // 
            this.btnSepeteEkle.Location = new System.Drawing.Point(243, 323);
            this.btnSepeteEkle.Name = "btnSepeteEkle";
            this.btnSepeteEkle.Size = new System.Drawing.Size(121, 23);
            this.btnSepeteEkle.TabIndex = 1;
            this.btnSepeteEkle.Text = "Sepete Ekle";
            this.btnSepeteEkle.UseVisualStyleBackColor = true;
            this.btnSepeteEkle.Click += new System.EventHandler(this.btnSepeteEkle_Click);
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(12, 12);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(175, 20);
            this.txtAra.TabIndex = 2;
            this.txtAra.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAra_KeyUp);
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(243, 50);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(173, 21);
            this.cmbMusteri.TabIndex = 3;
            // 
            // cmbNakliye
            // 
            this.cmbNakliye.FormattingEnabled = true;
            this.cmbNakliye.Location = new System.Drawing.Point(243, 88);
            this.cmbNakliye.Name = "cmbNakliye";
            this.cmbNakliye.Size = new System.Drawing.Size(173, 21);
            this.cmbNakliye.TabIndex = 4;
            // 
            // cmbCalisan
            // 
            this.cmbCalisan.FormattingEnabled = true;
            this.cmbCalisan.Location = new System.Drawing.Point(243, 126);
            this.cmbCalisan.Name = "cmbCalisan";
            this.cmbCalisan.Size = new System.Drawing.Size(173, 21);
            this.cmbCalisan.TabIndex = 5;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Location = new System.Drawing.Point(243, 212);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(173, 20);
            this.dtpTarih.TabIndex = 9;
            // 
            // lstSepet
            // 
            this.lstSepet.ContextMenuStrip = this.cmsSepet;
            this.lstSepet.FormattingEnabled = true;
            this.lstSepet.Location = new System.Drawing.Point(428, 50);
            this.lstSepet.Name = "lstSepet";
            this.lstSepet.Size = new System.Drawing.Size(225, 264);
            this.lstSepet.TabIndex = 11;
            // 
            // cmsSepet
            // 
            this.cmsSepet.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cikarToolStripMenuItem,
            this.guncelleToolStripMenuItem});
            this.cmsSepet.Name = "cmsSepet";
            this.cmsSepet.Size = new System.Drawing.Size(121, 48);
            // 
            // cikarToolStripMenuItem
            // 
            this.cikarToolStripMenuItem.Name = "cikarToolStripMenuItem";
            this.cikarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.cikarToolStripMenuItem.Text = "Cikar";
            this.cikarToolStripMenuItem.Click += new System.EventHandler(this.cikarToolStripMenuItem_Click);
            // 
            // guncelleToolStripMenuItem
            // 
            this.guncelleToolStripMenuItem.Name = "guncelleToolStripMenuItem";
            this.guncelleToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.guncelleToolStripMenuItem.Text = "Guncelle";
            this.guncelleToolStripMenuItem.Click += new System.EventHandler(this.guncelleToolStripMenuItem_Click);
            // 
            // lblSepetToplam
            // 
            this.lblSepetToplam.AutoSize = true;
            this.lblSepetToplam.Location = new System.Drawing.Point(425, 333);
            this.lblSepetToplam.Name = "lblSepetToplam";
            this.lblSepetToplam.Size = new System.Drawing.Size(79, 13);
            this.lblSepetToplam.TabIndex = 13;
            this.lblSepetToplam.Text = "Sepet Toplam: ";
            // 
            // btnSiparisVer
            // 
            this.btnSiparisVer.Location = new System.Drawing.Point(428, 358);
            this.btnSiparisVer.Name = "btnSiparisVer";
            this.btnSiparisVer.Size = new System.Drawing.Size(121, 23);
            this.btnSiparisVer.TabIndex = 14;
            this.btnSiparisVer.Text = "Siparis Ver";
            this.btnSiparisVer.UseVisualStyleBackColor = true;
            this.btnSiparisVer.Click += new System.EventHandler(this.btnSiparisVer_Click);
            // 
            // pnlDetay
            // 
            this.pnlDetay.Controls.Add(this.btnGuncelle);
            this.pnlDetay.Controls.Add(this.nuIndirim);
            this.pnlDetay.Controls.Add(this.nuAdet);
            this.pnlDetay.Controls.Add(this.lblAdet);
            this.pnlDetay.Controls.Add(this.lblIndirim);
            this.pnlDetay.Location = new System.Drawing.Point(670, 50);
            this.pnlDetay.Name = "pnlDetay";
            this.pnlDetay.Size = new System.Drawing.Size(252, 114);
            this.pnlDetay.TabIndex = 15;
            this.pnlDetay.Visible = false;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(113, 77);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(121, 23);
            this.btnGuncelle.TabIndex = 20;
            this.btnGuncelle.Text = "Guncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // nuIndirim
            // 
            this.nuIndirim.Location = new System.Drawing.Point(114, 51);
            this.nuIndirim.Name = "nuIndirim";
            this.nuIndirim.Size = new System.Drawing.Size(120, 20);
            this.nuIndirim.TabIndex = 19;
            // 
            // nuAdet
            // 
            this.nuAdet.Location = new System.Drawing.Point(114, 18);
            this.nuAdet.Name = "nuAdet";
            this.nuAdet.Size = new System.Drawing.Size(120, 20);
            this.nuAdet.TabIndex = 18;
            // 
            // lblAdet
            // 
            this.lblAdet.AutoSize = true;
            this.lblAdet.Location = new System.Drawing.Point(13, 20);
            this.lblAdet.Name = "lblAdet";
            this.lblAdet.Size = new System.Drawing.Size(32, 13);
            this.lblAdet.TabIndex = 16;
            this.lblAdet.Text = "Adet:";
            // 
            // lblIndirim
            // 
            this.lblIndirim.AutoSize = true;
            this.lblIndirim.Location = new System.Drawing.Point(13, 58);
            this.lblIndirim.Name = "lblIndirim";
            this.lblIndirim.Size = new System.Drawing.Size(40, 13);
            this.lblIndirim.TabIndex = 17;
            this.lblIndirim.Text = "Indirim:";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(243, 250);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(173, 20);
            this.txtAdres.TabIndex = 16;
            // 
            // nuNakliyeFiyat
            // 
            this.nuNakliyeFiyat.Location = new System.Drawing.Point(243, 172);
            this.nuNakliyeFiyat.Name = "nuNakliyeFiyat";
            this.nuNakliyeFiyat.Size = new System.Drawing.Size(173, 20);
            this.nuNakliyeFiyat.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 450);
            this.Controls.Add(this.nuNakliyeFiyat);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.pnlDetay);
            this.Controls.Add(this.btnSiparisVer);
            this.Controls.Add(this.lblSepetToplam);
            this.Controls.Add(this.lstSepet);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.cmbCalisan);
            this.Controls.Add(this.cmbNakliye);
            this.Controls.Add(this.cmbMusteri);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.btnSepeteEkle);
            this.Controls.Add(this.lstUrunler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsSepet.ResumeLayout(false);
            this.pnlDetay.ResumeLayout(false);
            this.pnlDetay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuIndirim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuAdet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuNakliyeFiyat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUrunler;
        private System.Windows.Forms.Button btnSepeteEkle;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.ComboBox cmbNakliye;
        private System.Windows.Forms.ComboBox cmbCalisan;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.ListBox lstSepet;
        private System.Windows.Forms.ContextMenuStrip cmsSepet;
        private System.Windows.Forms.ToolStripMenuItem cikarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guncelleToolStripMenuItem;
        private System.Windows.Forms.Label lblSepetToplam;
        private System.Windows.Forms.Button btnSiparisVer;
        private System.Windows.Forms.Panel pnlDetay;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.NumericUpDown nuIndirim;
        private System.Windows.Forms.NumericUpDown nuAdet;
        private System.Windows.Forms.Label lblAdet;
        private System.Windows.Forms.Label lblIndirim;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.NumericUpDown nuNakliyeFiyat;
    }
}

