using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUygulama.Models
{
    public class Urun
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunludur.")]
        [Display(Name = "Ürün Adı")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Fiyat zorunludur.")]
        [Display(Name = "Fiyat")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Fiyat { get; set; }

        [Required(ErrorMessage = "Stok miktarı zorunludur.")]
        [Display(Name = "Stok Miktarı")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı 0'dan küçük olamaz.")]
        public int StokMiktari { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string Aciklama { get; set; }

        [Display(Name = "Resim")]
        public string? ResimUrl { get; set; }

        [NotMapped]
        [Display(Name = "Resim Yükle")]
        public IFormFile? ResimDosya { get; set; }

        // Yeni özellikler
        [Display(Name = "Marka")]
        public string? Marka { get; set; }

        [Display(Name = "Model")]
        public string? Model { get; set; }

        [Display(Name = "Teknik Özellikler")]
        [DataType(DataType.MultilineText)]
        public string? TeknikOzellikler { get; set; }

        [Display(Name = "Garanti Süresi (Ay)")]
        [Range(0, 120, ErrorMessage = "Garanti süresi 0-120 ay arasında olmalıdır.")]
        public int? GarantiSuresi { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;

        [Display(Name = "Son Güncelleme")]
        [DataType(DataType.DateTime)]
        public DateTime? GuncellemeTarihi { get; set; }
    }
} 