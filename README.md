# 🚀 Kerimyol Tech Web Uygulaması

Bu web uygulaması, Kerimyol Tech şirketi için geliştirilmiş modern bir e-ticaret yönetim sistemidir. Kullanıcı dostu arayüzü ve kapsamlı yönetim özellikleriyle, ürün ve kullanıcı yönetimini kolaylaştırır.

## 📋 Özellikler

### 👥 Kullanıcı Yönetimi
- Kullanıcı kaydı ve giriş sistemi
- Şifremi unuttum özelliği
- Kullanıcı profil yönetimi
- Rol tabanlı yetkilendirme (Admin/Kullanıcı)

### 🛍️ Ürün Yönetimi
- Ürün ekleme, düzenleme ve silme
- Detaylı ürün bilgileri (fiyat, stok, açıklama vb.)
- Ürün fotoğrafı yükleme
- Ürün listeleme ve arama

### 👨‍💼 Admin Paneli
- Tüm kullanıcıları görüntüleme ve yönetme
- Ürün yönetimi
- Sistem ayarları

### 🎨 Tasarım
- Modern ve şık arayüz
- Mobil uyumlu (responsive) tasarım
- Kullanıcı dostu navigasyon
- Bootstrap tabanlı modern görünüm

## 🛠️ Kullanılan Teknolojiler

- **Backend:** ASP.NET Core MVC 9.0
- **Veritabanı:** SQLite
- **ORM:** Entity Framework Core
- **Frontend:** 
  - Bootstrap 5
  - jQuery
  - Modern CSS
  - Responsive Design

## 💻 Kurulum Adımları

### Gereksinimler
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio Code](https://code.visualstudio.com/) veya [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Git](https://git-scm.com/downloads)

### 1️⃣ Projeyi İndirme
```bash
# Projeyi klonlayın
git clone https://github.com/kerimayvaz77/KerimyolTech-Website.git

# Proje klasörüne gidin
cd KerimyolTech-Website
```

### 2️⃣ Bağımlılıkları Yükleme
```bash
# Gerekli paketleri yükleyin
dotnet restore
```

### 3️⃣ Veritabanı Kurulumu
```bash
# Veritabanını oluşturun ve güncelleyin
dotnet ef database update
```

### 4️⃣ Uygulamayı Çalıştırma
```bash
# Uygulamayı başlatın
dotnet run
```

Uygulama başlatıldıktan sonra tarayıcınızda `http://localhost:5000` adresine giderek uygulamaya erişebilirsiniz.

## 👩‍💻 Kullanım Kılavuzu

### Admin Girişi
- **URL:** `http://localhost:5000/Kullanici/Giris`
- **Kullanıcı Adı:** admin
- **Şifre:** admin123

### Yeni Kullanıcı Kaydı
1. Ana sayfadaki "Kayıt Ol" butonuna tıklayın
2. Gerekli bilgileri doldurun
3. Kaydı tamamlayın

### Ürün Yönetimi (Admin)
1. Admin olarak giriş yapın
2. "Admin Paneli" menüsüne tıklayın
3. "Ürünler" sekmesinden ürün işlemlerini yapabilirsiniz:
   - Yeni ürün eklemek için "Yeni Ürün" butonunu kullanın
   - Mevcut ürünleri düzenlemek için ürün satırındaki "Düzenle" butonunu kullanın
   - Ürünleri silmek için "Sil" butonunu kullanın

### Kullanıcı Yönetimi (Admin)
1. Admin panelinde "Kullanıcılar" sekmesine gidin
2. Tüm kullanıcıları görüntüleyin
3. Kullanıcı bilgilerini düzenleyin veya kullanıcıları silin

## 🤝 Destek ve İletişim

Herhangi bir sorunuz veya öneriniz için:
- 📧 E-posta: info@kerimyol.com
- 🌐 Website: [www.kerimyol.com](http://www.kerimyol.com)

## 📝 Lisans

Bu proje [MIT lisansı](LICENSE) altında lisanslanmıştır.

---
© 2024 Kerimyol Tech. Tüm hakları saklıdır. 