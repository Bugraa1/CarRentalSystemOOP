

namespace AracKiralamaSistemi
{
    public class KiralamaYonetimi
    {
        private List<Kiralama> _kiralamalar;
        private AracYonetimi _aracYonetimi;
        private MusteriYonetimi _musteriYonetimi;

        public KiralamaYonetimi(AracYonetimi aracYonetimi, MusteriYonetimi musteriYonetimi)
        {
            _kiralamalar = new List<Kiralama>();
            _aracYonetimi = aracYonetimi;
            _musteriYonetimi = musteriYonetimi;
        }

        public bool AracKirala(string plaka, int musteriId, int kiralamaSuresi)
        {
          
            var arac = _aracYonetimi.AracBul(plaka);
            var musteri = _musteriYonetimi.MusteriBul(musteriId);

            if (arac == null || musteri == null || !arac.Kiralanabilir || kiralamaSuresi <= 0)
            {
                return false;
            }

            var kiralama = new Kiralama(arac, musteri, kiralamaSuresi);
            _kiralamalar.Add(kiralama);

            return true;
        }

        public decimal AracIadeEt(string plaka)
        {
            var kiralama = _kiralamalar.FirstOrDefault(k => k.Arac.Plaka == plaka && k.Aktif);
            
            if (kiralama == null)
            {
                return 0; // Kiralama bulunamadı
            }

            return kiralama.AraciIadeEt();
        }

        public List<Kiralama> ButunKiralamalariGetir()
        {
            return _kiralamalar;
        }

        public List<Kiralama> AktifKiralamalarGetir()
        {
            return _kiralamalar.Where(k => k.Aktif).ToList();
        }

        public List<Kiralama> MusteriyeGoreKiralamalarGetir(int musteriId)
        {
            return _kiralamalar.Where(k => k.Musteri.Id == musteriId).ToList();
        }

        public List<Kiralama> PlakayaGoreKiralamalarGetir(string plaka)
        {
            return _kiralamalar.Where(k => k.Arac.Plaka == plaka).ToList();
        }

        public List<Kiralama> TarihAraliginaGoreKiralamalarGetir(DateTime baslangic, DateTime bitis)
        {
            return _kiralamalar.Where(k => 
                (k.BaslangicTarihi >= baslangic && k.BaslangicTarihi <= bitis) ||
                (k.BitisTarihi >= baslangic && k.BitisTarihi <= bitis)).ToList();
        }
    }
} 