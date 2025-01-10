using WebUygulama.Models;
using Microsoft.EntityFrameworkCore;

namespace WebUygulama.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            // Kullanıcılar
            if (!await context.Kullanicilar.AnyAsync())
            {
                var kullanicilar = new Kullanici[]
                {
                    new Kullanici
                    {
                        KullaniciAdi = "admin",
                        Email = "admin@example.com",
                        Sifre = "admin123",
                        Rol = "Admin"
                    },
                    new Kullanici
                    {
                        KullaniciAdi = "kerim",
                        Email = "kerim@example.com",
                        Sifre = "kerim123",
                        Rol = "Kullanici"
                    }
                };

                await context.Kullanicilar.AddRangeAsync(kullanicilar);
                await context.SaveChangesAsync();
            }

            // Ürünler
            if (!await context.Urunler.AnyAsync())
            {
                var urunler = new Urun[]
                {
                    new Urun
                    {
                        Ad = "Laptop",
                        Fiyat = 15000,
                        StokMiktari = 10,
                        Aciklama = "Yüksek performanslı laptop",
                        ResimUrl = "https://picsum.photos/id/1/400/300"
                    },
                    new Urun
                    {
                        Ad = "Telefon",
                        Fiyat = 8000,
                        StokMiktari = 15,
                        Aciklama = "Akıllı telefon",
                        ResimUrl = "https://picsum.photos/id/2/400/300"
                    },
                    new Urun
                    {
                        Ad = "Tablet",
                        Fiyat = 5000,
                        StokMiktari = 20,
                        Aciklama = "10 inç tablet",
                        ResimUrl = "https://picsum.photos/id/3/400/300"
                    }
                };

                await context.Urunler.AddRangeAsync(urunler);
                await context.SaveChangesAsync();
            }
        }
    }
} 