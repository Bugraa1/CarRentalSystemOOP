namespace AracKiralamaSistemi
{
    public interface IAracYonetimi
    {
        void AracEkle(Arac arac);
        bool AracSil(string plaka);
        List<Arac> ButunAraclariGetir();
        List<Arac> UygunAraclariGetir();
        Arac AracBul(string plaka);
    }
}