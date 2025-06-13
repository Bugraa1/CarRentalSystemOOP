namespace AracKiralamaSistemi
{
    public interface IArac
    {
        string Plaka { get; }
        string Marka { get; }
        string Model { get; }
        int Yil { get; }
        decimal GunlukUcret { get; }
        bool Kiralanabilir { get; set; }
        
        string BilgileriGetir();
        decimal UcretHesapla(int gun);
    }
}