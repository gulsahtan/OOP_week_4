# 📚 OOP_week_4 – Kalıtım (Inheritance), Base ve Polimorfizm (Polymorphism)

Bu proje, **Nesne Tabanlı Programlama (Object-Oriented Programming – OOP)** dersi kapsamında C# programlama dili kullanılarak hazırlanmıştır.

Bu haftada, önceki derslerde öğrenilen **sınıf oluşturma, nesne tanımlama, metotlar ve constructor (kurucu metotlar)** konularının üzerine **kalıtım (inheritance), `base` anahtar kelimesi, polimorfizm (çok biçimlilik), `virtual` ve `override`** kavramları eklenmiştir.

Uygulamalar, önceki haftalarda kullanılan `Kitap` sınıfı temel alınarak geliştirilmiştir. `CocukKitabi` ve `Dergi` sınıfları oluşturularak kalıtım ve polimorfizm konuları uygulamalı olarak gösterilmiştir.

---

## 🎯 Bu Haftanın Konuları

- Kalıtım (Inheritance) nedir?
- Kalıtım neden kullanılır?
- Temel sınıf (Base Class) ve türetilmiş sınıf (Derived Class)
- `:` operatörü ile kalıtım oluşturma
- Kalıtım yoluyla değişken ve metotların kullanılması
- `base` anahtar kelimesi
- Temel sınıfın constructor metodunu çağırma
- Temel sınıfın normal metodunu çağırma
- Polimorfizm (Polymorphism) nedir?
- `virtual` anahtar kelimesi
- `override` anahtar kelimesi
- Metotların yeniden tanımlanması (Method Overriding)
- Temel sınıf referansı üzerinden alt sınıf nesnelerinin kullanılması

---

## 🧠 Projenin Amacı

Bu proje ile öğrencilerin:

- Kalıtım kavramını öğrenmesi,
- Bir sınıftan başka bir sınıf türetebilmesi,
- Ortak özellikleri tekrar yazmadan kullanabilmesi,
- Temel sınıf ve türetilmiş sınıf arasındaki ilişkiyi anlayabilmesi,
- `base` anahtar kelimesini kullanabilmesi,
- Constructor'ların kalıtım durumunda nasıl çalıştığını öğrenmesi,
- `virtual` ve `override` arasındaki ilişkiyi kavrayabilmesi,
- Polimorfizm kullanarak farklı nesneleri ortak bir tür üzerinden yönetebilmesi

hedeflenmiştir.

---

# 📂 1. Proje Yapısı

```text
OOP_week_4/
│
├── Program.cs
├── Kitap.cs
├── CocukKitabi.cs
├── Dergi.cs
├── OOP_week_4.csproj
└── README.md
```

| Dosya | Açıklama |
|---|---|
| `Kitap.cs` | Temel sınıf, constructor ve virtual metot |
| `CocukKitabi.cs` | Kalıtım, base ve override kullanımı |
| `Dergi.cs` | Kalıtım ve metot ezme |
| `Program.cs` | Nesne oluşturma ve polimorfizm uygulaması |

### Sınıflar Arasındaki Kalıtım İlişkisi

```text
                    Kitap
                 (Base Class)
                      |
             -------------------
             |                 |
        CocukKitabi           Dergi
       (Derived Class)    (Derived Class)
```

Bu yapıda `Kitap` temel sınıftır.

`CocukKitabi` ve `Dergi` sınıfları, `Kitap` sınıfından kalıtım almaktadır.

> **Not:** Bu projede `Dergi` sınıfı, kalıtım konusunu öğretmek amacıyla `Kitap` sınıfından türetilmiştir. Gerçek bir yazılım projesinde kitap ve dergi için ortak bir `Yayin` temel sınıfı oluşturmak daha uygun bir tasarım olabilir.

---

# 📘 2. Kalıtım (Inheritance) Nedir?

Kalıtım, bir sınıfın başka bir sınıfın erişilebilir özelliklerini ve metotlarını devralabilmesidir.

Kalıtım sayesinde ortak özellikler her sınıfta tekrar tekrar yazılmaz.

Örneğin bir kitap için:

- Kitap adı
- Yazar
- Sayfa sayısı

gibi bilgiler bulunabilir.

Çocuk kitaplarında ise bunlara ek olarak:

- Önerilen yaş
- Resimli olup olmadığı

gibi özellikler bulunabilir.

Bu durumda çocuk kitabı sınıfında bütün değişkenleri yeniden tanımlamak yerine `Kitap` sınıfından kalıtım alabiliriz.

### Kalıtım Olmadan

```csharp
public class Kitap
{
    public string kitapAdi;
    public string yazar;
    public int sayfaSayisi;
}

public class CocukKitabi
{
    public string kitapAdi;
    public string yazar;
    public int sayfaSayisi;

    public int yasAraligi;
    public bool resimliMi;
}
```

Bu örnekte ortak değişkenler tekrar yazılmıştır.

### Kalıtım Kullanarak

```csharp
public class CocukKitabi : Kitap
{
    public int yasAraligi;
    public bool resimliMi;
}
```

Burada:

```csharp
: Kitap
```

ifadesi, `CocukKitabi` sınıfının `Kitap` sınıfından kalıtım aldığını gösterir.

Artık `CocukKitabi`, temel sınıftaki erişilebilir değişkenleri ve metotları kullanabilir.

---

# 📘 3. Temel Sınıf Oluşturma – Kitap.cs

## Adım 1: Yeni Sınıf Oluşturma

Visual Studio içerisinde:

1. `Solution Explorer` bölümünü açınız.
2. Projenin üzerine sağ tıklayınız.
3. `Add → Class` seçeneğine tıklayınız.
4. Sınıf adını `Kitap.cs` olarak belirleyiniz.
5. `Add` butonuna tıklayınız.

## Kitap.cs

```csharp
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

        // Normal metot
        public void KitapTuru()
        {
            Console.WriteLine("Bu bir yayın türüdür.");
        }
    }
}
```

### Kodun Açıklaması

```csharp
public class Kitap
```

Bu ifade `Kitap` adında bir sınıf oluşturur.

```csharp
public string kitapAdi;
public string yazar;
public int sayfaSayisi;
```

Bu değişkenler kitap nesnesinin bilgilerini tutar.

```csharp
public Kitap(string ad, string yazarAdi, int sayfa)
```

Bu constructor, nesne oluşturulurken kitap bilgilerini alır.

```csharp
public virtual void BilgileriGoster()
```

Buradaki `virtual` anahtar kelimesi, metodun alt sınıflarda yeniden tanımlanabilmesine izin verir.

---

# 📗 4. Türetilmiş Sınıf Oluşturma – CocukKitabi.cs

## Adım 2: CocukKitabi Sınıfını Oluşturma

Visual Studio içerisinde:

`Solution Explorer → Projeye Sağ Tık → Add → Class`

Sınıf adı:

`CocukKitabi.cs`

## CocukKitabi.cs

```csharp
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
```

## Kalıtım Nasıl Gerçekleşti?

```csharp
public class CocukKitabi : Kitap
```

Bu tanımlama sayesinde `CocukKitabi`, `Kitap` sınıfından kalıtım alır.

`Kitap` sınıfında bulunan:

```csharp
kitapAdi
yazar
sayfaSayisi
```

değişkenlerini yeniden tanımlamamız gerekmez.

Ayrıca temel sınıftaki erişilebilir metotları da kullanabiliriz.

### Program.cs İçerisinde Kullanımı

```csharp
CocukKitabi cocuk1 = new CocukKitabi(
    "Küçük Prens",
    "Antoine de Saint-Exupéry",
    96,
    8,
    true
);

cocuk1.BilgileriGoster();

cocuk1.YasGrubunuGoster();
```

Bu örnekte `CocukKitabi` nesnesi oluşturulurken hem temel sınıfa ait bilgiler hem de çocuk kitabına özel bilgiler constructor aracılığıyla belirlenmektedir.

---

# 🔑 5. Base Anahtar Kelimesi Nedir?

`base` anahtar kelimesi, türetilmiş sınıf içerisinden temel sınıfın üyelerine erişmek için kullanılır.

Bu derste iki farklı kullanımını gördük.

## 5.1. Base ile Constructor Çağırma

```csharp
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
```

Burada:

```csharp
: base(ad, yazarAdi, sayfa)
```

ifadesi `Kitap` sınıfının parametreli constructor'ını çağırır.

### Çalışma Sırası

1. `new CocukKitabi(...)` ile nesne oluşturulmaya başlanır.
2. `base(...)` aracılığıyla `Kitap` constructor'ı çalışır.
3. `kitapAdi`, `yazar` ve `sayfaSayisi` değerleri atanır.
4. Ardından `CocukKitabi` constructor'ının gövdesi çalışır.
5. `yasAraligi` ve `resimliMi` değerleri atanır.

**Önemli:** Constructor'lar kalıtım yoluyla devralınmaz. Ancak türetilmiş sınıfın constructor'ı, `base(...)` kullanarak temel sınıfın constructor'ını çağırabilir.

---

## 5.2. Base ile Temel Sınıfın Metodunu Çağırma

```csharp
public override void BilgileriGoster()
{
    base.BilgileriGoster();

    Console.WriteLine("Önerilen Yaş: " + yasAraligi);
    Console.WriteLine("Resimli mi?: " + resimliMi);
}
```

Burada:

```csharp
base.BilgileriGoster();
```

ifadesi temel sınıftaki `BilgileriGoster()` metodunu çalıştırır.

Böylece kitap adı, yazar ve sayfa sayısı bilgilerini yeniden yazmamıza gerek kalmaz.

Ardından çocuk kitabına özel bilgiler ekrana yazdırılır.

---

# 📙 6. Dergi Sınıfı – Kalıtım ve Override

## Adım 3: Dergi Sınıfını Oluşturma

`Solution Explorer → Add → Class → Dergi.cs`

## Dergi.cs

```csharp
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
```

### Kodun Açıklaması

```csharp
public class Dergi : Kitap
```

`Dergi` sınıfının `Kitap` sınıfından kalıtım aldığını belirtir.

```csharp
: base(ad, editor, sayfa)
```

Temel sınıfın constructor'ını çağırır. Bu örnekte `editor` bilgisi, temel sınıftaki `yazar` alanına aktarılmaktadır.

```csharp
public override void BilgileriGoster()
```

Temel sınıfta `virtual` olarak tanımlanan metodun `Dergi` sınıfında yeniden tanımlandığını gösterir.

---

# 🔄 7. Virtual ve Override Nedir?

## Virtual Anahtar Kelimesi

`virtual`, temel sınıfta tanımlanan bir metodun türetilmiş sınıflarda yeniden tanımlanabilmesini sağlar.

Örneğin `Kitap` sınıfında:

```csharp
public virtual void BilgileriGoster()
{
    Console.WriteLine("Kitap Adı: " + kitapAdi);
    Console.WriteLine("Yazar: " + yazar);
    Console.WriteLine("Sayfa Sayısı: " + sayfaSayisi);
}
```

Bu metot temel sınıf içerisinde tanımlanmıştır.

## Override Anahtar Kelimesi

`override`, temel sınıftaki `virtual` metodun türetilmiş sınıfta yeniden tanımlanmasını sağlar.

Örneğin `CocukKitabi` sınıfında:

```csharp
public override void BilgileriGoster()
{
    base.BilgileriGoster();

    Console.WriteLine("Önerilen Yaş: " + yasAraligi);
    Console.WriteLine("Resimli mi?: " + resimliMi);
}
```

Bu sayede `BilgileriGoster()` metodu, nesnenin türüne göre farklı bilgiler gösterebilir.

## Virtual ve Override Arasındaki Fark

| Virtual | Override |
|---|---|
| Genellikle temel sınıfta kullanılır | Türetilmiş sınıfta kullanılır |
| Metodun yeniden tanımlanabilmesine izin verir | Metodu yeniden tanımlar |
| `public virtual void` | `public override void` |
| Temel davranışı tanımlar | Temel davranışı değiştirebilir veya genişletebilir |

**Önemli:** Bir metodun `override` ile yeniden tanımlanabilmesi için temel sınıftaki ilgili metodun `virtual`, `abstract` veya `override` olarak tanımlanmış olması gerekir.

---

# 🔄 8. Polimorfizm (Polymorphism) Nedir?

Polimorfizm, Türkçede **çok biçimlilik** anlamına gelir.

Nesne tabanlı programlamada polimorfizm, aynı temel sınıf türündeki referanslar üzerinden farklı alt sınıf nesnelerinin farklı davranışlar sergileyebilmesini sağlar.

Örneğin:

- `Kitap` nesnesi genel kitap bilgilerini gösterir.
- `CocukKitabi` nesnesi çocuk kitabına özel bilgileri gösterir.
- `Dergi` nesnesi dergiye özel bilgileri gösterir.

Ancak bütün bu işlemler aynı metot adı kullanılarak gerçekleştirilebilir:

```csharp
BilgileriGoster()
```

## Polimorfizm Örneği

```csharp
Kitap kitap1 = new Kitap(
    "Suç ve Ceza",
    "Dostoyevski",
    687
);

CocukKitabi cocuk1 = new CocukKitabi(
    "Küçük Prens",
    "Antoine de Saint-Exupéry",
    96,
    8,
    true
);

Dergi dergi1 = new Dergi(
    "Bilim Dergisi",
    "Editör",
    80,
    25,
    "Aylık"
);
```

Bu nesneleri ortak bir dizide tutabiliriz:

```csharp
Kitap[] yayinlar = new Kitap[3];

yayinlar[0] = kitap1;
yayinlar[1] = cocuk1;
yayinlar[2] = dergi1;
```

Burada dizinin türü `Kitap` olmasına rağmen farklı alt sınıflardan oluşturulmuş nesneler tutulabilmektedir.

### Foreach ile Metot Çağırma

```csharp
foreach (Kitap yayin in yayinlar)
{
    Console.WriteLine("------------------");

    yayin.BilgileriGoster();
}
```

### Bu Kod Nasıl Çalışır?

Döngü içerisindeki:

```csharp
yayin.BilgileriGoster();
```

ifadesi her nesne için çağrılır.

Ancak:

- Nesne `Kitap` ise `Kitap.BilgileriGoster()` çalışır.
- Nesne `CocukKitabi` ise `CocukKitabi.BilgileriGoster()` çalışır.
- Nesne `Dergi` ise `Dergi.BilgileriGoster()` çalışır.

Bunun nedeni metodun `virtual` olarak tanımlanması ve alt sınıflarda `override` edilmesidir.

Bu davranış **çalışma zamanı polimorfizmi (runtime polymorphism)** olarak adlandırılır.

---

# 💻 9. Program.cs – Bütün Örneklerin Kullanımı

Aşağıdaki kodda ders boyunca oluşturulan bütün sınıflar kullanılmaktadır.

```csharp
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
```

---

# 🖥️ 10. Örnek Konsol Çıktısı

```text
=== KİTAP ===
Kitap Adı: Suç ve Ceza
Yazar: Dostoyevski
Sayfa Sayısı: 687

=== ÇOCUK KİTABI ===
Kitap Adı: Küçük Prens
Yazar: Antoine de Saint-Exupéry
Sayfa Sayısı: 96
Önerilen Yaş: 8
Resimli mi?: True
Bu kitap 8 yaş ve üzeri çocuklar için uygundur.
Bu bir yayın türüdür.

=== DERGİ ===
DERGİ BİLGİLERİ
Kitap Adı: Bilim Dergisi
Yazar: Editör
Sayfa Sayısı: 80
Sayı No: 25
Yayın Periyodu: Aylık
Bilim Dergisi dergisinin 25. sayısı yayımlandı.

=== POLİMORFİZM ===
------------------
Kitap Adı: Suç ve Ceza
Yazar: Dostoyevski
Sayfa Sayısı: 687
------------------
Kitap Adı: Küçük Prens
Yazar: Antoine de Saint-Exupéry
Sayfa Sayısı: 96
Önerilen Yaş: 8
Resimli mi?: True
------------------
DERGİ BİLGİLERİ
Kitap Adı: Bilim Dergisi
Yazar: Editör
Sayfa Sayısı: 80
Sayı No: 25
Yayın Periyodu: Aylık
```

---

# 📊 11. Bu Haftanın Temel Kavramları

| Kavram | Açıklama | Örnek |
|---|---|---|
| Class | Sınıf oluşturma | `class Kitap` |
| Inheritance | Kalıtım | `CocukKitabi : Kitap` |
| Base Class | Temel sınıf | `Kitap` |
| Derived Class | Türetilmiş sınıf | `CocukKitabi` |
| `base` | Temel sınıfın üyelerine erişme | `base.BilgileriGoster()` |
| `base(...)` | Temel sınıfın constructor'ını çağırma | `base(ad, yazar, sayfa)` |
| `virtual` | Metodun yeniden tanımlanmasına izin verme | `virtual void BilgileriGoster()` |
| `override` | Metodu yeniden tanımlama | `override void BilgileriGoster()` |
| Polymorphism | Çok biçimlilik | `Kitap yayin = new CocukKitabi(...)` |
| Constructor | Nesnenin başlangıç durumunu hazırlama | `new Kitap(...)` |

---

# 📝 12. Öğrenci Uygulamaları

## Uygulama 1 – Yeni Bir Alt Sınıf Oluşturma

`Kitap` sınıfından kalıtım alan `DersKitabi` adında yeni bir sınıf oluşturunuz.

Bu sınıf içerisinde:

- `dersAdi`
- `sinifSeviyesi`

değişkenlerini tanımlayınız.

### Yapılacaklar

1. `DersKitabi.cs` adında yeni bir sınıf oluşturunuz.
2. `Kitap` sınıfından kalıtım alınız.
3. Parametreli constructor oluşturunuz.
4. `base` kullanarak temel sınıfın constructor'ını çağırınız.
5. `BilgileriGoster()` metodunu `override` ediniz.
6. Ders kitabına özel bilgileri ekrana yazdırınız.

---

## Uygulama 2 – Base Anahtar Kelimesi

`CocukKitabi` sınıfında:

```csharp
base.BilgileriGoster();
```

satırını geçici olarak kaldırınız.

Programı tekrar çalıştırınız.

### Sorular

1. Hangi bilgiler artık ekrana yazdırılmıyor?
2. `base.BilgileriGoster()` neden kullanılıyor?
3. Temel sınıftaki metodu tekrar yazmadan kullanmanın avantajı nedir?

---

## Uygulama 3 – Virtual ve Override

`DersKitabi` sınıfında `BilgileriGoster()` metodunu yeniden tanımlayınız.

Ekrana aşağıdaki bilgilerin yazdırılmasını sağlayınız:

```text
DERS KİTABI BİLGİLERİ

Kitap Adı: Matematik
Yazar: Örnek Yazar
Sayfa Sayısı: 250
Ders Adı: Matematik
Sınıf Seviyesi: 9
```

---

## Uygulama 4 – Polimorfizm

`Kitap` türünde bir dizi oluşturunuz.

Bu dizinin içerisinde:

- Bir adet `Kitap`
- Bir adet `CocukKitabi`
- Bir adet `Dergi`
- Bir adet `DersKitabi`

nesnesi bulunsun.

`foreach` döngüsü kullanarak bütün nesnelerin `BilgileriGoster()` metotlarını çağırınız.

### Düşünme Sorusu

Dizideki bütün elemanlar `Kitap` türünde tutulmasına rağmen neden farklı sınıflardaki metotlar çalışmaktadır?

# 📌 Sonuç

Bu haftaki uygulamalarda nesne tabanlı programlamanın temel prensiplerinden olan **Inheritance (Kalıtım)** ve **Polymorphism (Çok Biçimlilik)** konuları ele alınmıştır.

- **Kitap sınıfı** ile temel sınıf ve `virtual` metot,
- **CocukKitabi sınıfı** ile kalıtım, `base` ve `override`,
- **Dergi sınıfı** ile metotların yeniden tanımlanması,
- **Program.cs** ile temel sınıf referansları üzerinden polimorfizm

uygulamalı olarak gösterilmiştir.
