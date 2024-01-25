#region Değişkenler
/*
Program değişkenleri isimleri ile bilmez adresleri ile bilir.
Değişkenler ram'de adresli saklanır.
Değişkenler yan yana saklanır(adreslenir).
Bir stringin hafızada ne kadar okunacağı iki yöntemle bulunur;
1.Yol: Header, yani okunacak stringin kaç uzunlıkta olduğunu stringin başına yazılması
2.Yol: Number 0 yada #0,okunacak stringin sonuna yazılarak görüldüğünde daha ileri gitmemesini söyler. 
*/
#endregion

class ArraysClass
{
   #region Diziler
   /*
   Diziler bir değişken grubudur. 
   İçerisinde aynı türden değişkenler bulundurabilir. Aynı türe ait birçok değişken bulunabilir.
   Dizi elemanları hafızada yan yana bulunur.
   Diziler genel itibari ile değişkenlerin yetişmediği yerlerde kullnılmak üzere geliştirilmiştir.
   1,2,3,4 boyutlu diziler yaygın olan boyutlu dizilere örnek iken boyutlamanın bir sınırı yada sonu yoktur.

   A[indis] = değer 

   Bir Boyutlu Diziler

   -> Tek Boyutlu Dizilerde Adres Bulma: x[i] = x[0] + i*4 (X[0], X dizisinin ilk elemanının adresidir)

      A dizinin başlangıç adresi(x) + indis * dizini eleman büyüklüğü  
      "x + indis * a"

      ÖR: İlk elemanının adresi 1000 olan X dizisinin 1453'üncü elemanının adresi kaçtır?
      1000+1453*4 = 6812 

      örn: A[12] = ? --> 200 + 12 * 4 = 248
      int[] x = new int[5];

   İki Boyutlu Diziler
   Hem satır hemde sütunlardan meydana gelen 2 boyutlu diziler state programlamada da kullandığımız matris tipli dizilerdir.

   Satır ve sütundan oluşur. (3x4 -> 3 satır, her satırda 4 hücre 
   Tüm n boyutlu diziler RAM'de tek boyutlu olarak saklanır.

   int x[,] = new int[3,4]; 12 hücre var.
   x[2,1] = 3
   x[1,2] = 5

   -> İki Boyutlu Dizilerde Adres Bulma

      x[q,w] q=3, w=4
      Dizinin başlangıç adresi + q * satırdaki eleman sayısı * eleman büyüklüğü + w * eleman büyüklüğü

      "X[i1,i2]
      X[b1,b2] olmak üzere;
      X[i] = X[0]+(i1*b2+i2)*4"

      ÖR : X[5,4] dizisinin ilk elemanının adresi 500 ise X[4,3]. elemanının adresi kaçtır?
      500+(4*4+3)*4=576

   Üç Boyutlu Diziler  
   Satır, sütun ve derinliği olan dizilerdir.

   Adreslenmesi: 

   X[i1,i2,i3]
   X[b1,b2,b3] olmak üzere ; 
   X[i]+(i1*b2*b3+i2*b3+i3)*4

   ÖR : X[8,5,7] dizisinin ilk elemanı 4000'den başlıyorsa X[6,4,3]. elemanının adresi kaçtır?
   4000+(6*5*7+4*7+3)*4 = 4.964

   Dört Boyutlu Diziler 
   Satır, sütun, derinlik ve derinliğin 2'ye bölünmesi ile oluşan dizilerdir.

   Adreslenmesi:
   X[i1,i2,i3,i4]
   X[b1,b2,b3,b4] olmak üzere;
   X[0]+(i1*b2*b3*b4+i2*b3*b4+i3*b4+i4)*4

   ÖR: X[10,15,8,7] dizisinin ilk elemanı 6000'de ise X[9,11,6,4]. elemanının adresi kaçtır?
   6000+(9*15*8*7+11*8*7+6*7+4)*4 = 38.888

   SORU: Klavyeden boyutları ve bu boyutların büyüklüğü girilen dizinin yine klavyeden girilen elemanının adresini bul. 
   Çözüm:

   static void Main(string[] args){
     Console.Write("Diziniz kaç boyutlu olsun: ");
     int boyutSayisi = Convert.ToInt16(Console.ReadLine());
     int[] boyutDizisi = new int[boyutSayisi];
     for(int i = 0; i < boyutSayisi; i++){
        Console.Write((i+1) + ". boyutun uzunluğunu girin: ");
        int boyut = Convert.ToInt16(Console.ReadLine());
        boyutDizisi[i] = boyut;
     }
     //klavyeden dizinin boyutları oluşturuldu.

     int[] arananElemanDizisi = new int[boyutSayisi]; // [i,j,k,...]
     Console.WriteLine("Adresini bulmak istediğiniz elemanın ; ");
     for(int i = 0; i < boyutSayisi; i++){
        Console.Write((i+1) + ". boyuttaki eleman sayısını girin: ");
        int arananEleman = Convert.ToInt16(Console.ReadLine());
        arananElemanDizisi[i] = arananEleman;
     }
     //adresi bulunmak istenen elemanın dizi numaraları girildi. [2,6,3,..] gibi görmek için.

     int adres = 0;
     int sayac = 1;
     for (int i = 0; i < boyutSayisi; i++)
      {
         int tempAdres = arananelemanDizisi[i];
         int tempSayac = sayac;
         for (int j = 0; j < (boyutSayisi - (i + 1)); j++)
            {
               tempAdres = tempAdres * boyutDizisi[tempSayac];
               tempSayac++;
            }
            sayac++;
            adres += tempAdres;
      }    
      Console.WriteLine(adres*4);
      Console.ReadKey();                                 
   }



   */
   #endregion
}