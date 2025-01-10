using Microsoft.AspNetCore.Mvc;
using WebUygulama.Models;
using WebUygulama.Data;
using Microsoft.EntityFrameworkCore;

namespace WebUygulama.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KullaniciController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kullanicilar = await _context.Kullanicilar.ToListAsync();
            return View(kullanicilar);
        }

        [HttpGet]
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Kayit(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                // Varsayılan rolü "Müşteri" olarak ayarla
                kullanici.Rol = "Müşteri";
                
                await _context.Kullanicilar.AddAsync(kullanici);
                await _context.SaveChangesAsync();

                TempData["KayitBasarili"] = true;
                return RedirectToAction(nameof(Giris));
            }

            return View(kullanici);
        }

        [HttpGet]
        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(string kullaniciAdi, string sifre)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => (k.Email == kullaniciAdi || k.KullaniciAdi == kullaniciAdi) && k.Sifre == sifre);

            if (kullanici != null)
            {
                HttpContext.Session.SetString("KullaniciId", kullanici.Id.ToString());
                HttpContext.Session.SetString("KullaniciAdi", kullanici.KullaniciAdi);
                HttpContext.Session.SetString("Rol", kullanici.Rol);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Kullanıcı adı/E-posta veya şifre hatalı!");
            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SifremiUnuttum(string kullaniciAdiVeyaEmail)
        {
            var kullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(k => k.Email == kullaniciAdiVeyaEmail || k.KullaniciAdi == kullaniciAdiVeyaEmail);

            if (kullanici == null)
            {
                ModelState.AddModelError("", "Bu e-posta adresi veya kullanıcı adı ile kayıtlı kullanıcı bulunamadı.");
                return View();
            }

            // Geçici şifre oluştur
            var geciciSifre = Guid.NewGuid().ToString("N").Substring(0, 8);
            kullanici.Sifre = geciciSifre;
            await _context.SaveChangesAsync();

            // Normalde burada e-posta gönderme işlemi yapılır
            // Şimdilik geçici şifreyi ekranda gösterelim
            TempData["Message"] = $"Geçici şifreniz: {geciciSifre}";
            
            return RedirectToAction(nameof(Giris));
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Rol") == "Admin";
        }

        // Admin Panel İşlemleri
        public async Task<IActionResult> AdminPanel()
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Giris");
            }

            ViewBag.Kullanicilar = await _context.Kullanicilar.ToListAsync();
            ViewBag.Urunler = await _context.Urunler.ToListAsync();

            return View();
        }

        public async Task<IActionResult> KullaniciListesi()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");

            var kullanicilar = await _context.Kullanicilar.ToListAsync();
            return View(kullanicilar);
        }

        public async Task<IActionResult> KullaniciSil(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici != null && kullanici.Rol != "Admin") // Admin kullanıcısı silinemez
            {
                _context.Kullanicilar.Remove(kullanici);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(KullaniciListesi));
        }

        [HttpGet]
        public async Task<IActionResult> KullaniciDuzenle(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
                return NotFound();

            return View(kullanici);
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciDuzenle(int id, Kullanici kullanici)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");

            if (id != kullanici.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var mevcutKullanici = await _context.Kullanicilar.FindAsync(id);
                if (mevcutKullanici != null)
                {
                    // Admin kullanıcısının rolü değiştirilemez
                    if (mevcutKullanici.Rol == "Admin")
                    {
                        kullanici.Rol = "Admin";
                    }

                    mevcutKullanici.KullaniciAdi = kullanici.KullaniciAdi;
                    mevcutKullanici.Email = kullanici.Email;
                    mevcutKullanici.Sifre = kullanici.Sifre;
                    mevcutKullanici.Rol = kullanici.Rol;

                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(KullaniciListesi));
            }
            return View(kullanici);
        }

        public async Task<IActionResult> KullaniciDetay(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Home");

            var kullanici = await _context.Kullanicilar.FindAsync(id);
            if (kullanici == null)
                return NotFound();

            return View(kullanici);
        }
    }
} 