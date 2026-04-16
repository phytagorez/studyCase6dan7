using System;
using System.Collections.Generic;
using ECommerceCoreLibrary;

namespace ECommerceCoreLibrary
{
    public interface IPembayaran
    {
        void ProsesBayar(double nominal);
    }

    public abstract class AkunPengguna
    {
        public string? Username { get; set; }

        public void Login()
        {
            Console.WriteLine($"[Sistem] {Username} berhasil login.");
        }

        public abstract void TampilkanDashboard();
    }

    public class Toko
    {
        public string NamaToko { get; set; }
        public Toko(string nama) { NamaToko = nama; }
    }

    public class Produk
    {
        public string NamaProduk { get; set; }
        public Produk(string nama) { NamaProduk = nama; }
    }

    public class OrderDetail
    {
        public string NomorResi { get; set; }
        public OrderDetail(string resi) { NomorResi = resi; }
    }

    public class Order
    {
        public string OrderId { get; set; }
        private OrderDetail detail;

        public Order(string orderId, string resi)
        {
            OrderId = orderId;
            detail = new OrderDetail(resi);
            Console.WriteLine($"[Sistem] Order {OrderId} dibuat dengan resi {detail.NomorResi}.");
        }
    }

    public class KeranjangBelanja
    {
        private List<Produk> listProduk = new List<Produk>();

        public void TambahProduk(Produk p)
        {
            listProduk.Add(p);
            Console.WriteLine($"[Keranjang] {p.NamaProduk} ditambahkan.");
        }
    }

    public class Pembeli : AkunPengguna, IPembayaran
    {
        public Pembeli(string nama)
        {
            Username = nama;
        }

        public override void TampilkanDashboard()
        {
            Console.WriteLine($"[Dashboard] Selamat datang di area belanja, {Username}!");
        }

        public void ProsesBayar(double nominal)
        {
            Console.WriteLine($"[Pembayaran] Saldo Gopay/OVO terpotong sebesar Rp{nominal:N0}.");
        }

        public void KunjungiToko(Toko toko)
        {
            Console.WriteLine($"[Aktivitas] {Username} sedang melihat-lihat di {toko.NamaToko}.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== SIMULASI E-COMMERCE ===\n");

        Pembeli budi = new Pembeli("Budi_Santoso");
        budi.Login();
        budi.TampilkanDashboard();

        Toko tokoElektronik = new Toko("Toko Komputer Jaya");
        budi.KunjungiToko(tokoElektronik);

        Produk laptop = new Produk("Laptop ASUS ROG");
        Produk mouse = new Produk("Mouse Logitech");

        KeranjangBelanja keranjangBudi = new KeranjangBelanja();
        keranjangBudi.TambahProduk(laptop);
        keranjangBudi.TambahProduk(mouse);

        budi.ProsesBayar(15000000);

        Order pesananBaru = new Order("ORD-001", "RESI-XYZ-999");

        Console.WriteLine("\nSimulasi Selesai.");
    }
}