namespace AracKiralamaSistemi
{
    public interface IKiralama
    {
        int Id { get; }
        IArac Arac { get; }
        IMusteri Musteri { get; }
        DateTime BaslangicTarihi { get; }
        DateTime BitisTarihi { get; }
        int KiralamaSuresi { get; }
        bool Aktif { get; }
        decimal ToplamUcret { get; }
        
        string BilgileriGetir();
        decimal AraciIadeEt();
    }
}