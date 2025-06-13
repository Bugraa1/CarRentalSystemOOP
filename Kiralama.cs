namespace AracKiralamaSistemi
{
    public class Kiralama : IKiralama
    {
        public int Id { get; private set; }
        public Arac Arac { get; private set; }
        public Musteri Musteri { get; private set; }
        public DateTime BaslangicTarihi { get; private set; }
        public DateTime BitisTarihi { get; private set; }
        public int KiralamaSuresi { get; private set; }
        public bool Aktif { get; private set; }
        public decimal ToplamUcret { get; private set; }

        private static int _sonId = 0;

        public Kiralama(Arac arac, Musteri musteri, int kiralamaSuresi)
        {
            Id = ++_sonId;
            Arac = arac;
            Musteri = musteri;
            BaslangicTarihi = DateTime.Now;
            KiralamaSuresi = kiralamaSuresi;
            BitisTarihi = BaslangicTarihi.AddDays(kiralamaSuresi);
            Aktif = true;
            ToplamUcret = arac.UcretHesapla(kiralamaSuresi);
            
            arac.Kiralanabilir = false;
        }

        public string BilgileriGetir()
        {
            return $"Kiralama ID: {Id}\n" +
                   $"Araç: {Arac.Marka} {Arac.Model} - {Arac.Plaka}\n" +
                   $"Müşteri: {Musteri.Ad} {Musteri.Soyad}\n" +
                   $"Başlangıç Tarihi: {BaslangicTarihi:dd/MM/yyyy}\n" +
                   $"Bitiş Tarihi: {BitisTarihi:dd/MM/yyyy}\n" +
                   $"Kiralama Süresi: {KiralamaSuresi} gün\n" +
                   $"Toplam Ücret: {ToplamUcret} TL\n" +
                   $"Durum: {(Aktif ? "Aktif" : "Tamamlandı")}";
        }

       
        public decimal AraciIadeEt()
        {
            
            Aktif = false;
            Arac.Kiralanabilir = true;

          
            DateTime iadeTarihi = DateTime.Now;
            
          
            
            int gecikmeGunu = 0;
            if (iadeTarihi > BitisTarihi)
            {
                gecikmeGunu = (int)(iadeTarihi - BitisTarihi).TotalDays;
                
                decimal ekUcret = Arac.GunlukUcret * gecikmeGunu * 1.5m;
                ToplamUcret += ekUcret;
            }

            return ToplamUcret;
        }

        
        IArac IKiralama.Arac => Arac;
        IMusteri IKiralama.Musteri => Musteri;
    }
}