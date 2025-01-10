using Microsoft.AspNetCore.Mvc;
using WebUygulama.Models;
using WebUygulama.Data;
using Microsoft.EntityFrameworkCore;

namespace WebUygulama.Controllers
{
    public class UrunController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UrunController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var urunler = await _context.Urunler.ToListAsync();
            return View(urunler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Giris", "Kullanici");
            }

            return View(new Urun());
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Urun urun, IFormFile? resimDosya)
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Giris", "Kullanici");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (resimDosya != null)
                    {
                        // Resim kaydetme işlemi
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(resimDosya.FileName);
                        string extension = Path.GetExtension(resimDosya.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

                        // Dizinin var olduğundan emin ol
                        string uploadDir = Path.Combine(wwwRootPath, "urun-resimleri");
                        if (!Directory.Exists(uploadDir))
                        {
                            Directory.CreateDirectory(uploadDir);
                        }

                        string path = Path.Combine(uploadDir, fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await resimDosya.CopyToAsync(fileStream);
                        }

                        urun.ResimUrl = "/urun-resimleri/" + fileName;
                    }
                    else
                    {
                        // Varsayılan resim
                        urun.ResimUrl = "/urun-resimleri/default-product.png";
                    }

                    // Eklenme tarihini ayarla
                    urun.EklenmeTarihi = DateTime.Now;
                    urun.GuncellemeTarihi = null;

                    await _context.Urunler.AddAsync(urun);
                    await _context.SaveChangesAsync();
                    TempData["Basari"] = "Ürün başarıyla eklendi.";
                    return RedirectToAction("AdminPanel", "Kullanici");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ürün eklenirken bir hata oluştu: " + ex.Message);
                    return View(urun);
                }
            }
            return View(urun);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var urun = await _context.Urunler.FirstOrDefaultAsync(u => u.Id == id);
            if (urun == null)
                return NotFound();

            return View(urun);
        }

        [HttpGet]
        public async Task<IActionResult> UrunDuzenle(int id)
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Giris", "Kullanici");
            }

            var urun = await _context.Urunler.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            return View(urun);
        }

        [HttpPost]
        public async Task<IActionResult> UrunDuzenle(int id, Urun urun, IFormFile? resimDosya)
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Giris", "Kullanici");
            }

            if (id != urun.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var mevcutUrun = await _context.Urunler.FindAsync(id);
                    if (mevcutUrun == null)
                    {
                        return NotFound();
                    }

                    if (resimDosya != null)
                    {
                        // Eski resmi sil
                        if (!string.IsNullOrEmpty(mevcutUrun.ResimUrl))
                        {
                            var eskiResimYolu = Path.Combine(_hostEnvironment.WebRootPath, mevcutUrun.ResimUrl.TrimStart('/'));
                            if (System.IO.File.Exists(eskiResimYolu))
                            {
                                System.IO.File.Delete(eskiResimYolu);
                            }
                        }

                        // Yeni resmi kaydet
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(resimDosya.FileName);
                        string extension = Path.GetExtension(resimDosya.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/urun-resimleri/", fileName);

                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await resimDosya.CopyToAsync(fileStream);
                        }

                        urun.ResimUrl = "/urun-resimleri/" + fileName;
                    }
                    else
                    {
                        urun.ResimUrl = mevcutUrun.ResimUrl;
                    }

                    urun.EklenmeTarihi = mevcutUrun.EklenmeTarihi;
                    urun.GuncellemeTarihi = DateTime.Now;

                    _context.Entry(mevcutUrun).CurrentValues.SetValues(urun);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction("AdminPanel", "Kullanici");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunExists(urun.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(urun);
        }

        [HttpPost]
        public async Task<IActionResult> UrunSil(int id)
        {
            if (HttpContext.Session.GetString("Rol") != "Admin")
            {
                return RedirectToAction("Giris", "Kullanici");
            }

            var urun = await _context.Urunler.FindAsync(id);
            if (urun != null)
            {
                _context.Urunler.Remove(urun);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("AdminPanel", "Kullanici");
        }

        private bool UrunExists(int id)
        {
            return _context.Urunler.Any(e => e.Id == id);
        }
    }
} 