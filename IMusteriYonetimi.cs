namespace AracKiralamaSistemi
{
    public interface IMusteriYonetimi
    {
        void MusteriEkle(Musteri musteri);
        bool MusteriSil(int id);
        List<Musteri> ButunMusterileriGetir();
        Musteri MusteriBul(int id);
        Musteri TcKimlikNoIleMusteriBul(string tcKimlikNo);
    }
}