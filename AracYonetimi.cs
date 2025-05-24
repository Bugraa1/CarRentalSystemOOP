using System;
using System.Collections.Generic;
using System.Linq;

namespace AracKiralamaSistemi
{
    public class AracYonetimi
    {
        private List<Arac> _araclar;

        public AracYonetimi()
        {
            _araclar = new List<Arac>();
        }

        public void AracEkle(Arac arac)
        {
            _araclar.Add(arac);
        }

        public bool AracSil(string plaka)
        {
            var arac = _araclar.FirstOrDefault(a => a.Plaka == plaka);
            
            _araclar.Remove(arac);
            return true;
        }

        public List<Arac> ButunAraclariGetir()
        {
            return _araclar;
        }

        
        public List<Arac> UygunAraclariGetir()
        {
            return _araclar.Where(a => a.Kiralanabilir).ToList();
        }

       
        public Arac AracBul(string plaka)
        {
            return _araclar.FirstOrDefault(a => a.Plaka == plaka);
        }
        
    }
} 