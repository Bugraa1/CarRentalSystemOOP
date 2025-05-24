

namespace AracKiralamaSistemi
{
    public class MusteriYonetimi
    {
        private List<Musteri> _musteriler;

        public MusteriYonetimi()
        {
            _musteriler = new List<Musteri>();
        }

        public void MusteriEkle(Musteri musteri)
        {
            
            _musteriler.Add(musteri);
        }

        
        public bool MusteriSil(int id)
        {
            var musteri = _musteriler.FirstOrDefault(m => m.Id == id);

            _musteriler.Remove(musteri);
            return true;
        }

        public List<Musteri> ButunMusterileriGetir()
        {
            return _musteriler;
        }

        public Musteri MusteriBul(int id)
        {
            return _musteriler.FirstOrDefault(m => m.Id == id);
        }

        public Musteri TcKimlikNoIleMusteriBul(string tcKimlikNo)
        {
            return _musteriler.FirstOrDefault(m => m.TcKimlikNo == tcKimlikNo);
        }
        
    }
} 