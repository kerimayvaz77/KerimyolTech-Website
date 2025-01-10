PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsLock" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK___EFMigrationsLock" PRIMARY KEY,
    "Timestamp" TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);
INSERT INTO __EFMigrationsHistory VALUES('20250109164820_InitialCreate','9.0.0');
CREATE TABLE IF NOT EXISTS "Kullanicilar" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Kullanicilar" PRIMARY KEY AUTOINCREMENT,
    "KullaniciAdi" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Sifre" TEXT NOT NULL,
    "Rol" TEXT NOT NULL
);
INSERT INTO Kullanicilar VALUES(1,'kerim1','kerim@gmail.com','gomis123','Admin');
INSERT INTO Kullanicilar VALUES(2,'kerim','kerim@example.com','kerim123','Kullanici');
INSERT INTO Kullanicilar VALUES(3,'kerimayvaz','kerimayvaz7@gmail.com','gomis123','Kullanici');
INSERT INTO Kullanicilar VALUES(4,'nehirturgut','kerimayvaz71@gmail.com','nehir123','Kullanici');
INSERT INTO Kullanicilar VALUES(5,'nehir1','kerimayvaz117@gmail.com','nehir123','Kullanici');
INSERT INTO Kullanicilar VALUES(6,'nehir23','kerimayvaz12371@gmail.com','asdfqwe123','Kullanici');
INSERT INTO Kullanicilar VALUES(7,'asdasdasda','kerima12312yvaz117@gmail.com','123123123123sadd','Kullanici');
INSERT INTO Kullanicilar VALUES(8,'asdasdasd','kerimayvaz7@gmail.com','asdasdads','Kullanici');
CREATE TABLE IF NOT EXISTS "Urunler" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_Urunler" PRIMARY KEY AUTOINCREMENT,
    "Ad" TEXT NOT NULL,
    "Fiyat" TEXT NOT NULL,
    "StokMiktari" INTEGER NOT NULL,
    "Aciklama" TEXT NOT NULL,
    "ResimUrl" TEXT NOT NULL
);
INSERT INTO Urunler VALUES(1,'Laptop','15000.0',10,'Yüksek performanslı laptop','https://picsum.photos/id/1/400/300');
INSERT INTO Urunler VALUES(2,'Telefon','8000.0',15,'Akıllı telefon','https://picsum.photos/id/2/400/300');
INSERT INTO Urunler VALUES(3,'Tablet','5000.0',20,'10 inç tablet','https://picsum.photos/id/3/400/300');
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('Kullanicilar',8);
INSERT INTO sqlite_sequence VALUES('Urunler',3);
COMMIT;
