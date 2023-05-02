using kutuphane_udemy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane_udemy
{
    public partial class Form1 : Form
    {
        List<Kisi> Kisilerim = new List<Kisi>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_kulladi.Text=string.Empty;
            txt_sifre.Text=string.Empty;
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi, sifre = "";
            kullaniciAdi = txt_kulladi.Text;
            sifre = txt_sifre.Text;
            bool kontrol=false;
            foreach (Kisi kisi in Kisilerim)
            {
                if (kullaniciAdi.ToLower()==kisi.getKullaniciAdi() && sifre.ToLower()==kisi.getSifre() && kisi.getYetki()=="admin")
                {
                    //admin sayfasına yonlendir
                    AdminSayfasi adminSayfasi=new AdminSayfasi();
                    adminSayfasi.Show();
                    this.Hide();
                    kontrol = true;
                    break;
                }
                else if (kullaniciAdi.ToLower() == kisi.getKullaniciAdi() && sifre.ToLower() == kisi.getSifre() && kisi.getYetki() == "uye")
                {
                    UyeSayfasi uyeSayfasi=new UyeSayfasi();
                    uyeSayfasi.Show();
                    this.Hide();
                    kontrol = true;
                    break;
                }
                

            }
            if(!kontrol)
            {
                MessageBox.Show("Bir hata oluştu ..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kisilerim.Add(new Kisi(1, "Enes", "Bayram", DateTime.Now, "enes", "1", "admin"));
            Kisilerim.Add(new Kisi(2, "Yakup", "Reçber", DateTime.Now, "yakup", "2", "uye"));
            Kisilerim.Add(new Kisi(3, "Bilal", "Çamur", DateTime.Now, "bilal", "3", "uye"));
            Kisilerim.Add(new Kisi(4, "Yasin", "Yazıcı", DateTime.Now, "yasin", "4", "uye"));

        }
    }
}
