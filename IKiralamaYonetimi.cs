namespace AracKiralamaSistemi
{
    public interface IKiralamaYonetimi
    {
        bool AracKirala(string plaka, int musteriId, int kiralamaSuresi);
        decimal AracIadeEt(string plaka);
        List<Kiralama> ButunKiralamalariGetir();
        List<Kiralama> AktifKiralamalarGetir();
    }
}