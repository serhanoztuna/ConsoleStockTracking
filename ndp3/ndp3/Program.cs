/******************************************************************************
 **                       SAKARYA ÜNİVERSİTESİ    
 **                  BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ        
 **                     BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ        
 **                    NESNEYE DAYALI PROGRAMLAMA DERSİ     
 **                          2016-2017 BAHAR DÖNEMİ 
 **                             
 **                  ÖDEV NUMARASI..........: 3    
 **                  ÖĞRENCİ ADI............: SERHAN ÖZTUNA   
 **                                   
 **                  
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ndp3
{
    class Program
    {
        abstract class kisi//kisi sınıfı tanımlanıyor
        {
            public string madi;// kullanılacak genel değişkenler tanımlanıyor
            public string adres;
            public int numara;
            public string web;
            public int vergino;
            public int bakiye;
            public int ucret;
            public kisi(string ad, string adr, int nm, string wb, int vrgi, int bky, int ucrt)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
            {
                madi = ad;
                adres = adr;
                numara = nm;
                web = wb;
                vergino = vrgi;
                bakiye = bky;
                ucret = ucrt;
            }
            class musteri : kisi//kisi sınıfından kalıtım alan musteri sınıfı tanımlanıyor.
            {
                public static int anlikbakiye = 0;//musterinin bakiye durumunun tutulması icin bakiye değiskeni
                public static int ucret = 0;
                public musteri(string ad, string adr, int nm, string wb, int vrgi, int bky, int ucrt) : base(ad, adr, nm, wb, vrgi, bky, ucrt)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
                {
                    anlikbakiye = bky;//dışardan girilen bakiye değişkeni eşitleniyor
                    ucret = ucrt;
                }
            }
            class tedarikci : kisi//kisi sınıfından kalıtım alarak tedarikci sınıfı oluşturuluyor.
            {
                public static int anlikbakiye = 0;
                public static int ucret = 0;
                public tedarikci(string ad, string adr, int nm, string wb, int vrgi, int bky, int ucrt) : base(ad, adr, nm, wb, vrgi, bky, ucrt)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
                {
                    anlikbakiye = bky;
                    ucret = ucrt;
                }
            }

            abstract class Depo//depo bilgilerinin tutulacağı bir depo sınıfı oluşturuluyor
            {

                public int adi;//değişkenler tanımlanıyor.
                public string barkod;
                public string tarih;
                public int miktari;
                public int tedarikci;
                public Depo(int a, string b, string t, int m)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
                {
                    adi = a;
                    barkod = b;
                    tarih = t;
                    miktari = m;

                }
            }
            class Depo1 : Depo
            {
                public static int miktar = 3;//depoda bulunan hammaddeler icin başlangıc değeri
                public Depo1(int a, string b, string t, int m) : base(a, b, t, m)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
                {
                    miktar = miktar + m;
                }

            }
            class Depo2 : Depo
            {
                public static int miktar = 3;//depoda bulunan hammaddeler icin başlangıc değeri
                public Depo2(int a, string b, string t, int m) : base(a, b, t, m)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
                {
                    miktar = miktar + m;//eğer hammadde alınırsa alınan hammadde ekleniyor
                }
            }
            class Depo3 : Depo
            {
                public static int miktar = 3;
                public Depo3(int a, string b, string t, int m) : base(a, b, t, m)//dışardan girilen değişkenler sınıfta ki değişkenlerle eşleştiriliyor
                {
                    miktar = miktar + m;//eğer hammadde alınırsa alınan hammadde ekleniyor
                }
            }
            public static int Menu()
            {
                int secim = 0;
                Console.WriteLine("1-Hammadde ekle:");//ana menu oluşturuluyor
                Console.WriteLine("2-Hammadde Listesi");
                Console.WriteLine("3-Yarı mamul Sat:");
                Console.WriteLine("4-Bitmiş Mamul Sat:");
                Console.WriteLine("5-Müşteri Ekle");
                Console.WriteLine("6-Tedarikci Ekle");
                Console.WriteLine("7-Musteri Listesi");
                Console.WriteLine("8-Tedarikci Listesi");
                Console.WriteLine("9-Çıkış");
                secim = int.Parse(Console.ReadLine());//secilen secim değişkene atiliyor
                return secim;
            }
            static void Main(string[] args)
            {
                string b, t;    //main fonksiyonunda kullanıcan alacağımız bilgileri tutacak değişkenler tanımlanıyor.
                int m = 0, tedarikci = 0, min = 0, a = 0, msayac = 0, tsayac = 0, ucrt = 0;
                string ad, adr, wb;
                int nm = 0, vrgi = 0, bky = 0;
                kisi[] mstr = new kisi[10];//sınıfları kullanarak sınıflara ait verileri saklamak icin diziler oluşturuluyor.
                kisi[] tdrk = new kisi[10];
                Depo[] bir = new Depo[100];
                Depo[] iki = new Depo[100];
                Depo[] uc = new Depo[100];
                int secim = 0, butce = 100, s1 = 0, s2 = 0, s3 = 0;//işletmenin başlangıc parasını tutmak icin butce değişkeni.
                do
                {
                    secim = Menu();
                    switch (secim)
                    {
                        case 1:
                            {
                                if (tdrk[0] != null)//tedarikci varsa döngüye giriyor yoksa uyarı veriyor
                                {
                                    for (int i = 0; i <= tsayac - 1; i++)
                                    {
                                        Console.WriteLine(tdrk[i].madi + "   " + tdrk[i].adres + "   " + tdrk[i].bakiye);//tedarikcileri yazdirarak kullanıcan secim yaptiriyor
                                    }
                                    Console.WriteLine("Seçeceğiniz tedarikcinin sırasını yazın:");//bilgiler alınıyor.
                                    tedarikci = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Hammadde seçin:1-2-3");
                                    a = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Miktarı:");
                                    m = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Barkod no:");
                                    b = Console.ReadLine();
                                    Console.WriteLine("Alınma tarihi");
                                    t = Console.ReadLine();
                                    Console.WriteLine("Minumum sipariş miktarı");
                                    min = int.Parse(Console.ReadLine());

                                    if (a == 1)//alınan hammaddelerin sayısı arttırılıyor
                                    {
                                        bir[s1++] = new Depo1(a, b, t, m);
                                    }
                                    if (a == 2)
                                    {
                                        iki[s2++] = new Depo2(a, b, t, m);
                                    }
                                    if (a == 3)
                                    {
                                        uc[s3++] = new Depo3(a, b, t, m);
                                    }

                                }
                                else { Console.WriteLine("Tedarikci bulunamadı lütfen tedarikci ekleyiniz!"); }

                                break;

                            }
                        case 2:
                            {
                                //hammadde miktarları ekrana yazdırılıyor
                                Console.WriteLine("1.hammadde:" + Depo1.miktar);
                                Console.WriteLine("2.hammadde:" + Depo2.miktar);
                                Console.WriteLine("3.hammadde:" + Depo3.miktar);
                                break;
                            }
                        case 3:
                            {
                                if (mstr[1] != null)//musteri varsa döngüye giriyor yoksa uyarı veriyor
                                {
                                    for (int i = 0; i <= msayac - 1; i++)//dizide bulunan müsteriler listeleniyor
                                    {
                                        Console.WriteLine(mstr[i].madi + "   " + mstr[i].adres + "   " + mstr[i].bakiye + "   " + mstr[i].ucret);
                                    }
                                    Console.WriteLine("Seçmek istediğiniz müsterinin oldugu sırayı giriniz:");
                                    tedarikci = int.Parse(Console.ReadLine());
                                    if (mstr[tedarikci].bakiye > mstr[tedarikci].ucret)
                                    {
                                        if (Depo1.miktar > 2 && Depo2.miktar > 2)//yeterli hammedde varsa satış işlemi yapılıyor
                                        {
                                            Console.WriteLine("Satış başarılı!");
                                            butce += mstr[tedarikci].ucret;//kazanılan para bütceye aktarılıyor
                                            Depo1.miktar--;//hammadde depodan azaltiliyor
                                            Depo2.miktar--;
                                            mstr[tedarikci].bakiye -= mstr[tedarikci].ucret;//musteriden harcadığı para cıkarılıyor
                                        }
                                        else
                                        {
                                            Console.WriteLine("Yeterli Hammadde yok!");//yeterli hammadde yoksa uyarı veriyor
                                        }
                                    }
                                    else { Console.WriteLine("Musterinin yeterli bakiyesi yok!"); }//bakiye yeterli değilse uyarı veriyor
                                }
                                else { Console.WriteLine("musteri bulunamadı!"); }
                                break;
                            }
                        case 4:
                            {
                                if (mstr[1] != null)
                                {
                                    for (int i = 0; i <= msayac - 1; i++)
                                    {
                                        Console.WriteLine(mstr[i].madi + "   " + mstr[i].adres + "   " + mstr[i].bakiye + "   " + mstr[i].ucret);
                                    }
                                    Console.WriteLine("Seçmek istediğiniz müsterinin oldugu sırayı giriniz:");
                                    tedarikci = int.Parse(Console.ReadLine());
                                    if (Depo1.miktar > 2 && Depo2.miktar > 2 && Depo3.miktar > 2)
                                    {
                                        if (mstr[tedarikci].bakiye > mstr[tedarikci].ucret)
                                        {
                                            if (butce - mstr[msayac].ucret > 0)
                                            {
                                                Console.WriteLine("Satış başarılı!");
                                                butce += mstr[tedarikci].bakiye;
                                                Depo1.miktar--;
                                                Depo2.miktar--;
                                                Depo3.miktar--;
                                                butce = butce - mstr[msayac].ucret;
                                                mstr[tedarikci].bakiye -= mstr[tedarikci].ucret;
                                            }
                                        }
                                        else { Console.WriteLine("musterinin yeterli  bütcesi yok!"); }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Yeterli Hammadde bulunamadı lütfen hammadde satın al!");
                                    }
                                }
                                else { Console.WriteLine("Musteri bulunamadı lütfen musteri ekle!"); }
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Musteri Adini Giriniz:");//yeni musteri eklemek icin bilgiler alınıyor ve müsteri sınıfını kullanarak diziye aktariliyor
                                ad = Console.ReadLine();
                                Console.WriteLine("Adres:");
                                adr = Console.ReadLine();
                                Console.WriteLine("Numara:");
                                nm = int.Parse(Console.ReadLine());
                                Console.WriteLine("Web:");
                                wb = Console.ReadLine();
                                Console.WriteLine("Vergi No:");
                                vrgi = int.Parse(Console.ReadLine());
                                Console.WriteLine("Bakiye:");
                                bky = int.Parse(Console.ReadLine());
                                Console.WriteLine("Hammade başına ucret miktarını giriniz:");
                                ucrt = int.Parse(Console.ReadLine());
                                mstr[msayac++] = new musteri(ad, adr, nm, wb, vrgi, bky, ucrt);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Tedarikci Adini Giriniz:");//yeni tedarikci eklemek icin bilgiler alınıyor ve tedarikci sınıfını kullanarak diziye aktariliyor
                                ad = Console.ReadLine();
                                ad = Console.ReadLine();
                                Console.WriteLine("Adres:");
                                adr = Console.ReadLine();
                                Console.WriteLine("Numara:");
                                nm = int.Parse(Console.ReadLine());
                                Console.WriteLine("Web:");
                                wb = Console.ReadLine();
                                Console.WriteLine("Vergi No:");
                                vrgi = int.Parse(Console.ReadLine());
                                Console.WriteLine("Bakiye:");
                                bky = int.Parse(Console.ReadLine());
                                Console.WriteLine("Hammade başına ucret miktarını giriniz:");
                                ucrt = int.Parse(Console.ReadLine());
                                tdrk[tsayac++] = new musteri(ad, adr, nm, wb, vrgi, bky, ucrt);
                                break;
                            }
                        case 7:
                            {
                                if (mstr[0] == null)//musteri listesi listeleniyor
                                {
                                    Console.WriteLine("Musteri bulunamadı!");
                                }
                                else
                                {
                                    for (int i = 0; i <= msayac - 1; i++)
                                    {
                                        Console.WriteLine(mstr[i].madi + "   " + mstr[i].adres + "   " + mstr[i].bakiye);
                                    }
                                }
                                break;
                            }
                        case 8:
                            {
                                if (tdrk[0] == null)
                                {
                                    Console.WriteLine("Tedarikci bulunamadı!");
                                }
                                else
                                {
                                    for (int i = 0; i <= tsayac - 1; i++)
                                    {
                                        Console.WriteLine(tdrk[i].madi + "   " + tdrk[i].adres + "   " + tdrk[i].bakiye);
                                    }
                                }
                                break;
                            }
                    }
                } while (secim != 9);//9 a basılırsa programdan çıkılıyor.
            }
        }
    }
}
