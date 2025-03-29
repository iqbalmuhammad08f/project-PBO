using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Produk
{
    public string Nama { get; set; }
    public decimal Harga { get; set; }
    public string Kategori { get; set; }
    public decimal? Berat { get; set; }  
    public int? Jumlah { get; set; }

    public Produk(string nama, decimal harga, string kategori, decimal? berat = null, int? jumlah = null)
    {
        Nama = nama;
        Harga = harga;
        Kategori = kategori;
        Berat = berat;
        Jumlah = jumlah;
    }

}

class KeranjangBelanja
{
    private List<Produk> produkList = new List<Produk>();

    public decimal ongkirBajuPakaian;
    public decimal ongkirElektronik;
    public decimal ongkirBuku;


    public void TambahProduk(Produk produk)
    {
        produkList.Add(produk);
    }

    public decimal HitungTotalHarga()
    {
        decimal totalHarga = 0;
        foreach (var produk in produkList)
        {
            if (produk.Jumlah.HasValue) 
            {
                totalHarga += produk.Harga * produk.Jumlah.Value;
            }
            else
            {
                totalHarga += produk.Harga;
            }
        }
        return totalHarga;
    }

    public decimal HitungOngkosKirim()
    {
        ongkirElektronik = 0;
        ongkirBajuPakaian = 0;
        ongkirBuku = 0;
        foreach (var produk in produkList)
        {
            if (produk.Kategori == "Elektronik" && produk.Berat.HasValue)
            {
                ongkirElektronik += produk.Berat.Value * 11000;
            }
            else if (produk.Kategori == "Baju dan Pakaian")
            {
                ongkirBajuPakaian += 5000;
            }
            else if (produk.Kategori == "Buku")
            {
                ongkirBuku += 3000;
            }
        }
        return ongkirElektronik + ongkirBajuPakaian + ongkirBuku;
    }

    public decimal TotalBayar()
    {
        decimal totalHarga = HitungTotalHarga();
        decimal ongkosKirim = HitungOngkosKirim();
        return totalHarga + ongkosKirim;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Produk produk1 = new Produk("Laptop", 8000000, "Elektronik", berat: 2);
        Produk produk2 = new Produk("T-shirt", 150000, "Baju dan Pakaian", jumlah: 4);
        Produk produk3 = new Produk("Novel", 120000, "Buku", jumlah: 3);

        KeranjangBelanja keranjang = new KeranjangBelanja();
        keranjang.TambahProduk(produk1);
        keranjang.TambahProduk(produk2);
        keranjang.TambahProduk(produk3);

        keranjang.HitungOngkosKirim();

        Console.WriteLine("Daftar Produk dalam keranjang belanja");
        Console.WriteLine($"Nama Produk: {produk1.Nama}");
        Console.WriteLine($"Harga Produk: {produk1.Harga}");
        Console.WriteLine($"Berat Produk: {produk1.Berat} kg");
        Console.WriteLine($"Ongkir barang elektronik: {keranjang.ongkirElektronik}");
        Console.WriteLine($"Total harga elektrok: {produk1.Harga + keranjang.ongkirElektronik} \n");

        Console.WriteLine($"Nama Produk: {produk2.Nama}");
        Console.WriteLine($"Harga Produk: {produk2.Harga}");
        Console.WriteLine($"Jumlah Produk: {produk2.Jumlah}");
        Console.WriteLine($"Ongkir barang elektronik: {keranjang.ongkirBajuPakaian}");
        Console.WriteLine($"Total harga elektrok: {produk2.Harga * produk2.Jumlah + keranjang.ongkirBajuPakaian}\n");

        Console.WriteLine($"Nama Produk: {produk3.Nama}");
        Console.WriteLine($"Harga Produk: {produk3.Harga}");
        Console.WriteLine($"Jumlah Produk: {produk3.Jumlah}");
        Console.WriteLine($"Ongkir barang elektronik: {keranjang.ongkirBuku}");
        Console.WriteLine($"Total harga elektrok: {produk3.Harga * produk3.Jumlah + keranjang.ongkirBuku}\n");

        Console.WriteLine($"Total harga keselurun: {keranjang.TotalBayar()} ");


    }
}