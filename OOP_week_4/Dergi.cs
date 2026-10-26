using System;

namespace OOP_week_4
{
    public class Dergi : Kitap
    {
        public int sayiNo;
        public string yayinPeriyodu;

        public Dergi(
            string ad,
            string editor,
            int sayfa,
            int sayi,
            string periyot
        ) : base(ad, editor, sayfa)
        {
            sayiNo = sayi;
            yayinPeriyodu = periyot;
        }

        public override void BilgileriGoster()
        {
            Console.WriteLine("DERGİ BİLGİLERİ");

            base.BilgileriGoster();

            Console.WriteLine("Sayı No: " + sayiNo);
            Console.WriteLine("Yayın Periyodu: " + yayinPeriyodu);
        }

        public void YeniSayiDuyur()
        {
            Console.WriteLine(
                kitapAdi + " dergisinin " +
                sayiNo + ". sayısı yayımlandı."
            );
        }
    }
}
