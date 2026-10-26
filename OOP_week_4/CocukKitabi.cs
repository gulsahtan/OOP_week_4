using System;

namespace OOP_week_4
{
    public class CocukKitabi : Kitap
    {
        public int yasAraligi;
        public bool resimliMi;

        // Parametreli constructor
        public CocukKitabi(
            string ad,
            string yazarAdi,
            int sayfa,
            int yas,
            bool resimli
        ) : base(ad, yazarAdi, sayfa)
        {
            yasAraligi = yas;
            resimliMi = resimli;
        }

        // Override metot
        public override void BilgileriGoster()
        {
            base.BilgileriGoster();

            Console.WriteLine("Önerilen Yaş: " + yasAraligi);
            Console.WriteLine("Resimli mi?: " + resimliMi);
        }

        public void YasGrubunuGoster()
        {
            Console.WriteLine(
                "Bu kitap " + yasAraligi +
                " yaş ve üzeri çocuklar için uygundur."
            );
        }
    }
}
