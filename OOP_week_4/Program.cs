using System;

namespace OOP_week_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. TEMEL SINIF
            Console.WriteLine("=== KİTAP ===");

            Kitap kitap1 = new Kitap(
                "Suç ve Ceza",
                "Dostoyevski",
                687
            );

            kitap1.BilgileriGoster();

            // 2. KALITIM - ÇOCUK KİTABI
            Console.WriteLine("\n=== ÇOCUK KİTABI ===");

            CocukKitabi cocuk1 = new CocukKitabi(
                "Küçük Prens",
                "Antoine de Saint-Exupéry",
                96,
                8,
                true
            );

            cocuk1.BilgileriGoster();
            cocuk1.YasGrubunuGoster();

            // Temel sınıftan miras alınan metot
            cocuk1.KitapTuru();

            // 3. KALITIM - DERGİ
            Console.WriteLine("\n=== DERGİ ===");

            Dergi dergi1 = new Dergi(
                "Bilim Dergisi",
                "Editör",
                80,
                25,
                "Aylık"
            );

            dergi1.BilgileriGoster();
            dergi1.YeniSayiDuyur();

            // 4. POLİMORFİZM
            Console.WriteLine("\n=== POLİMORFİZM ===");

            Kitap[] yayinlar = new Kitap[3];

            yayinlar[0] = kitap1;
            yayinlar[1] = cocuk1;
            yayinlar[2] = dergi1;

            foreach (Kitap yayin in yayinlar)
            {
                Console.WriteLine("------------------");
                yayin.BilgileriGoster();
            }

            Console.ReadKey();
        }
    }
}
