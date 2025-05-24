using System;

namespace AracKiralamaSistemi
{
    public class Musteri
    {
        public int Id { get; private set; }
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        public string TcKimlikNo { get; private set; }
        public string Telefon { get; private set; }

        public Musteri(int id, string ad, string soyad, string tcKimlikNo, string telefon)
        {
            Id = id;
            Ad = ad;
            Soyad = soyad;
            TcKimlikNo = tcKimlikNo;
            Telefon = telefon;
        }

        public string BilgileriGetir()
        {
            return $"ID: {Id}\nAd: {Ad}\nSoyad: {Soyad}\nTC Kimlik No: {TcKimlikNo}\nTelefon: {Telefon}";
        }
    }
} 