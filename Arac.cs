namespace AracKiralamaSistemi
{
    
    public abstract class Arac : IArac
    {
        public string Plaka { get; private set; }
        public string Marka { get; private set; }
        public string Model { get; private set; }
        public int Yil { get; private set; }
        public decimal GunlukUcret { get; protected set; }
        public bool Kiralanabilir { get; set; } = true;

        public Arac(string plaka, string marka, string model, int yil, decimal gunlukUcret)
        {
            Plaka = plaka;
            Marka = marka;
            Model = model;
            Yil = yil;
            GunlukUcret = gunlukUcret;
        }

       
        public virtual string BilgileriGetir()
        {
            return $"Plaka: {Plaka}\nMarka: {Marka}\nModel: {Model}\nYıl: {Yil}\n" +
                   $"Günlük Ücret: {GunlukUcret} TL\nDurum: {(Kiralanabilir ? "Kiralanabilir" : "Kiralandı")}";
        }

      
        public virtual decimal UcretHesapla(int gun)
        {
            return GunlukUcret * gun;
        }
    }

   
    public class Otomobil : Arac
    {
        public string KasaTipi { get; private set; }

        public Otomobil(string plaka, string marka, string model, int yil, string kasaTipi, decimal gunlukUcret)
            : base(plaka, marka, model, yil, gunlukUcret)
        {
            KasaTipi = kasaTipi;
        }

        public override string BilgileriGetir()
        {
            return base.BilgileriGetir() + $"\nAraç Tipi: Otomobil\nKasa Tipi: {KasaTipi}";
        }
    }

    
    public class SUV : Arac
    {
        public bool AraziOzelligi { get; private set; }

        public SUV(string plaka, string marka, string model, int yil, decimal gunlukUcret, bool araziOzelligi)
            : base(plaka, marka, model, yil, gunlukUcret)
        {
            AraziOzelligi = araziOzelligi;
        }

        public override string BilgileriGetir()
        {
            return base.BilgileriGetir() + $"\nAraç Tipi: SUV\nArazi Özelliği: {(AraziOzelligi ? "Var" : "Yok")}";
        }
        
    }
    
    public class Minibus : Arac
    {
        public int YolcuKapasitesi { get; private set; }

        public Minibus(string plaka, string marka, string model, int yil, int yolcuKapasitesi, decimal gunlukUcret)
            : base(plaka, marka, model, yil, gunlukUcret)
        {
            YolcuKapasitesi = yolcuKapasitesi;
        }

        public override string BilgileriGetir()
        {
            return base.BilgileriGetir() + $"\nAraç Tipi: Minibüs\nYolcu Kapasitesi: {YolcuKapasitesi}";
        }
        
    }
}