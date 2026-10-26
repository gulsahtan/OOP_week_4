using System;

namespace OOP_week_4
{
    public class Kitap
    {
        public string kitapAdi;
        public string yazar;
        public int sayfaSayisi;

        // Parametresiz constructor
        public Kitap()
        {
            kitapAdi = "Bilinmiyor";
            yazar = "Bilinmiyor";
            sayfaSayisi = 0;
        }

        // Parametreli constructor
        public Kitap(string ad, string yazarAdi, int sayfa)
        {
            kitapAdi = ad;
            yazar = yazarAdi;
            sayfaSayisi = sayfa;
        }

        // Virtual metot
        public virtual void BilgileriGoster()
        {
            Console.WriteLine("Kitap Adı: " + kitapAdi);
            Console.WriteLine("Yazar: " + yazar);
            Console.WriteLine("Sayfa Sayısı: " + sayfaSayisi);
        }

        public void KitapTuru()
        {
            Console.WriteLine("Bu bir yayın türüdür.");
        }
    }
}
