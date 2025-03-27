using System;
using System.Collections.Generic;

class Produk
{
    public string Nama { get; set; }
    public decimal Harga { get; set; }
    public string Kategori { get; set; }
    public decimal? Berat { get; set; }  // Berat hanya untuk kategori Elektronik

    public Produk(string nama, decimal harga, string kategori, decimal? berat = null)
    {
        Nama = nama;
        Harga = harga;
        Kategori = kategori;
        Berat = berat;
    }
}

class KeranjangBelanja
{
    private List<Produk> produkList = new List<Produk>();

    public void TambahProduk(Produk produk)
    {
        produkList.Add(produk);
    }

    public decimal HitungTotalHarga()
    {
        decimal totalHarga = 0;
        foreach (var produk in produkList)
        {
            totalHarga += produk.Harga;
        }
        return totalHarga;
    }

    public decimal HitungOngkosKirim()
    {
        decimal ongkosKirim = 0;
        foreach (var produk in produkList)
        {
            if (produk.Kategori == "Elektronik" && produk.Berat.HasValue)
            {
                ongkosKirim += produk.Berat.Value * 1000;  // Contoh ongkos kirim berdasarkan berat
            }
            else if (produk.Kategori == "Baju dan Pakaian")
            {
                ongkosKirim += 5000;  // Ongkos kirim tetap untuk kategori baju dan pakaian
            }
            else if (produk.Kategori == "Buku")
            {
                ongkosKirim += 3000;  // Ongkos kirim tetap untuk kategori buku
            }
        }
        return ongkosKirim;
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
        Produk produk1 = new Produk("Laptop", 8000000m, "Elektronik", 2m);
        Produk produk2 = new Produk("T-shirt", 150000m, "Baju dan Pakaian");
        Produk produk3 = new Produk("Novel", 120000m, "Buku");

        KeranjangBelanja keranjang = new KeranjangBelanja();
        keranjang.TambahProduk(produk1);
        keranjang.TambahProduk(produk2);
        keranjang.TambahProduk(produk3);

        Console.WriteLine("Total Harga Produk: " + keranjang.HitungTotalHarga());
        Console.WriteLine("Total Ongkos Kirim: " + keranjang.HitungOngkosKirim());
        Console.WriteLine("Total Bayar: " + keranjang.TotalBayar());
    }
}

