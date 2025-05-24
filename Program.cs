

namespace AracKiralamaSistemi
{
    class Program
    {
        static void Main(string[] args)
        {
            AracYonetimi aracYonetimi = new AracYonetimi();
            MusteriYonetimi musteriYonetimi = new MusteriYonetimi();
            KiralamaYonetimi kiralamaYonetimi = new KiralamaYonetimi(aracYonetimi, musteriYonetimi);

            
            aracYonetimi.AracEkle(new Otomobil("34ABC123", "Toyota", "Corolla", 2020, "Sedan", 500));
            aracYonetimi.AracEkle(new Otomobil("34DEF456", "Honda", "Civic", 2021, "Sedan", 600));
            aracYonetimi.AracEkle(new SUV("34GHI789", "Nissan", "Qashqai", 2019, 700, true));
            aracYonetimi.AracEkle(new Minibus("34JKL012", "Mercedes", "Sprinter", 2018, 15, 1000));

            
            musteriYonetimi.MusteriEkle(new Musteri(1, "Ahmet", "Yılmaz", "12345678901", "5551234567"));
            musteriYonetimi.MusteriEkle(new Musteri(2, "Ayşe", "Demir", "98765432109", "5559876543"));

            bool devam = true;
            
            while (devam)
            {
                
                Console.Clear();
                Console.WriteLine("=== ARAÇ KİRALAMA SİSTEMİ ===");
                Console.WriteLine("1. Araç İşlemleri");
                Console.WriteLine("2. Müşteri İşlemleri");
                Console.WriteLine("3. Kiralama İşlemleri");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                
                {
                    case "1":
                        AracMenusu(aracYonetimi);
                        break;
                    case "2":
                        MusteriMenusu(musteriYonetimi);
                        break;
                    case "3":
                        KiralamaMenusu(kiralamaYonetimi, aracYonetimi, musteriYonetimi);
                        break;
                    case "0":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AracMenusu(AracYonetimi aracYonetimi)
        {
            bool devam = true;
            while (devam)
            {
                Console.Clear();
                Console.WriteLine("=== ARAÇ İŞLEMLERİ ===");
                Console.WriteLine("1. Araç Ekle");
                Console.WriteLine("2. Araçları Listele");
                Console.WriteLine("3. Araç Sil");
                Console.WriteLine("0. Ana Menüye Dön");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        YeniAracEkle(aracYonetimi);
                        break;
                    case "2":
                        AraclariListele(aracYonetimi);
                        break;
                    case "3":
                        AracSil(aracYonetimi);
                        break;
                    case "0":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void YeniAracEkle(AracYonetimi aracYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== YENİ ARAÇ EKLE ===");
            Console.WriteLine("Araç Tipi Seçin:");
            Console.WriteLine("1. Otomobil");
            Console.WriteLine("2. SUV");
            Console.WriteLine("3. Minibüs");
            Console.Write("Seçiminiz: ");
            
            string aracTipi = Console.ReadLine();
            
            Console.Write("Plaka: ");
            string plaka = Console.ReadLine();
            Console.Write("Marka: ");
            string marka = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Yıl: ");
            int yil = Convert.ToInt32(Console.ReadLine());
            Console.Write("Günlük Ücret: ");
            decimal gunlukUcret = Convert.ToDecimal(Console.ReadLine());

            switch (aracTipi)
            {
                case "1":
                    Console.Write("Kasa Tipi (Sedan, Hatchback, vb.): ");
                    string kasaTipi = Console.ReadLine();
                    aracYonetimi.AracEkle(new Otomobil(plaka, marka, model, yil, kasaTipi, gunlukUcret));
                    break;
                case "2":
                    Console.Write("Arazi Özelliği (true/false): ");
                    bool araziOzelligi = Convert.ToBoolean(Console.ReadLine());
                    aracYonetimi.AracEkle(new SUV(plaka, marka, model, yil, gunlukUcret, araziOzelligi));
                    break;
                case "3":
                    Console.Write("Yolcu Kapasitesi: ");
                    int yolcuKapasitesi = Convert.ToInt32(Console.ReadLine());
                    aracYonetimi.AracEkle(new Minibus(plaka, marka, model, yil, yolcuKapasitesi, gunlukUcret));
                    break;
                default:
                    Console.WriteLine("Geçersiz araç tipi!");
                    break;
            }

            Console.WriteLine("Araç başarıyla eklendi.");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void AraclariListele(AracYonetimi aracYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== ARAÇ LİSTESİ ===");
            
            var araclar = aracYonetimi.ButunAraclariGetir();
            
            if (araclar.Count == 0)
            {
                Console.WriteLine("Kayıtlı araç bulunamadı.");
            }
            else
            {
                foreach (var arac in araclar)
                {
                    Console.WriteLine(arac.BilgileriGetir());
                    Console.WriteLine("------------------------");
                }
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void AracSil(AracYonetimi aracYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== ARAÇ SİL ===");
            Console.Write("Silmek istediğiniz aracın plakasını girin: ");
            string plaka = Console.ReadLine();

            bool sonuc = aracYonetimi.AracSil(plaka);
            
            if (sonuc)
            {
                Console.WriteLine("Araç başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Araç bulunamadı veya kiralanmış durumda olduğu için silinemedi.");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void MusteriMenusu(MusteriYonetimi musteriYonetimi)
        {
            bool devam = true;
            while (devam)
            {
                Console.Clear();
                Console.WriteLine("=== MÜŞTERİ İŞLEMLERİ ===");
                Console.WriteLine("1. Müşteri Ekle");
                Console.WriteLine("2. Müşterileri Listele");
                Console.WriteLine("3. Müşteri Sil");
                Console.WriteLine("0. Ana Menüye Dön");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        YeniMusteriEkle(musteriYonetimi);
                        break;
                    case "2":
                        MusterileriListele(musteriYonetimi);
                        break;
                    case "3":
                        MusteriSil(musteriYonetimi);
                        break;
                    case "0":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void YeniMusteriEkle(MusteriYonetimi musteriYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== YENİ MÜŞTERİ EKLE ===");
            
            Console.Write("Müşteri ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("TC Kimlik No: ");
            string tcKimlik = Console.ReadLine();
            Console.Write("Telefon: ");
            string telefon = Console.ReadLine();

            musteriYonetimi.MusteriEkle(new Musteri(id, ad, soyad, tcKimlik, telefon));
            
            Console.WriteLine("Müşteri başarıyla eklendi.");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void MusterileriListele(MusteriYonetimi musteriYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== MÜŞTERİ LİSTESİ ===");
            
            var musteriler = musteriYonetimi.ButunMusterileriGetir();
            
            if (musteriler.Count == 0)
            {
                Console.WriteLine("Kayıtlı müşteri bulunamadı.");
            }
            else
            {
                foreach (var musteri in musteriler)
                {
                    Console.WriteLine(musteri.BilgileriGetir());
                    Console.WriteLine("------------------------");
                }
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void MusteriSil(MusteriYonetimi musteriYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== MÜŞTERİ SİL ===");
            Console.Write("Silmek istediğiniz müşterinin ID'sini girin: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool sonuc = musteriYonetimi.MusteriSil(id);
            
            if (sonuc)
            {
                Console.WriteLine("Müşteri başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Müşteri bulunamadı veya aktif kiralaması olduğu için silinemedi.");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void KiralamaMenusu(KiralamaYonetimi kiralamaYonetimi, AracYonetimi aracYonetimi, MusteriYonetimi musteriYonetimi)
        {
            bool devam = true;
            while (devam)
            {
                Console.Clear();
                Console.WriteLine("=== KİRALAMA İŞLEMLERİ ===");
                Console.WriteLine("1. Yeni Kiralama");
                Console.WriteLine("2. Kiralamaları Listele");
                Console.WriteLine("3. Araç İade Et");
                Console.WriteLine("0. Ana Menüye Dön");
                Console.Write("Seçiminiz: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        YeniKiralama(kiralamaYonetimi, aracYonetimi, musteriYonetimi);
                        break;
                    case "2":
                        KiralamalarıListele(kiralamaYonetimi);
                        break;
                    case "3":
                        AracIadeEt(kiralamaYonetimi);
                        break;
                    case "0":
                        devam = false;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void YeniKiralama(KiralamaYonetimi kiralamaYonetimi, AracYonetimi aracYonetimi, MusteriYonetimi musteriYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== YENİ KİRALAMA ===");
            
            // Müşterileri listele
            var musteriler = musteriYonetimi.ButunMusterileriGetir();
            if (musteriler.Count == 0)
            {
                Console.WriteLine("Kayıtlı müşteri bulunamadı. Önce müşteri ekleyin.");
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("Müşteriler:");
            foreach (var musteri in musteriler)
            {
                Console.WriteLine($"{musteri.Id} - {musteri.Ad} {musteri.Soyad}");
            }
            
            Console.Write("Müşteri ID seçin: ");
            int musteriId = Convert.ToInt32(Console.ReadLine());
            
            // Uygun araçları listele
            var uygunAraclar = aracYonetimi.UygunAraclariGetir();
            if (uygunAraclar.Count == 0)
            {
                Console.WriteLine("Kiralanabilir araç bulunamadı.");
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine("\nUygun Araçlar:");
            foreach (var arac in uygunAraclar)
            {
                Console.WriteLine($"{arac.Plaka} - {arac.Marka} {arac.Model} - Günlük: {arac.GunlukUcret} TL");
            }
            
            Console.Write("Kiralanacak aracın plakasını girin: ");
            string plaka = Console.ReadLine();
            
            Console.Write("Kiralama süresi (gün): ");
            int gun = Convert.ToInt32(Console.ReadLine());
            
            bool sonuc = kiralamaYonetimi.AracKirala(plaka, musteriId, gun);
            
            if (sonuc)
            {
                Console.WriteLine("Araç başarıyla kiralandı.");
            }
            else
            {
                Console.WriteLine("Kiralama işlemi başarısız. Araç veya müşteri bulunamadı ya da araç kiralanabilir durumda değil.");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void KiralamalarıListele(KiralamaYonetimi kiralamaYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== KİRALAMA LİSTESİ ===");
            
            var kiralamalar = kiralamaYonetimi.ButunKiralamalariGetir();
            
            if (kiralamalar.Count == 0)
            {
                Console.WriteLine("Kayıtlı kiralama bulunamadı.");
            }
            else
            {
                foreach (var kiralama in kiralamalar)
                {
                    Console.WriteLine(kiralama.BilgileriGetir());
                    Console.WriteLine("------------------------");
                }
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void AracIadeEt(KiralamaYonetimi kiralamaYonetimi)
        {
            Console.Clear();
            Console.WriteLine("=== ARAÇ İADE ===");
            
            Console.Write("İade edilecek aracın plakasını girin: ");
            string plaka = Console.ReadLine();
            
            decimal toplamUcret = kiralamaYonetimi.AracIadeEt(plaka);
            
            if (toplamUcret > 0)
            {
                Console.WriteLine($"Araç başarıyla iade edildi. Toplam ücret: {toplamUcret} TL");
            }
            else
            {
                Console.WriteLine("İade işlemi başarısız. Araç bulunamadı veya kiralanmış durumda değil.");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
}