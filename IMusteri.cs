namespace AracKiralamaSistemi
{
    public interface IMusteri
    {
        int Id { get; }
        string Ad { get; }
        string Soyad { get; }
        string TcKimlikNo { get; }
        string Telefon { get; }
        
        string BilgileriGetir();
    }
}