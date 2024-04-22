using System;
using System.Diagnostics.Metrics;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace data_structure;

class Blok
{
    // Şu anda sınıfımız oluştu ve özellikleri yüklendi ancak hala sanal durumda onu kullanabilmemiz için new etmemiz gerekiyor.

    public int data;
    public Blok next;
    public Blok prev;
}

class Btree
{
    public int data;
    public Btree left;
    public Btree right;
}

class Queue
{
    public int data;
    public Queue next;
}


class Program
{
    static void Main(string[] args)
    {
        //Tekli Linked List
        #region
        /*
        Her ne kadar dizileri kullanmanın avantajları olsa dezavantajları da bulunmakta:
        1-)Diziler dinamik değil statik yapılıdır yani uzunluğu tanımlanmış diziyi işlem esnasında değiştiremezsin.
        2-)Stringler gibi değer değil adres tuttuklarından çok maliyetlidirler.
        3-)Eleman ekleme ve çıkartma işlemleri yapılamaz.

        Bizde dizilere alternatif olarak linked listleri kullanıyoruz. Linked listler kısaca hem veri hem adres saklayan veri yapıları olarak tanımlanabilir.

        Kullanımı : 
         Bir class içerisinde yeni bir Block sınıfı açıp buna linked list kullanırken ihtiyacımız olacak özellilkleri tanımlıyoruz.
          
        */
        #endregion

        //Blok bl = new Blok();
        //Şu anda içi boş ve herhangi bir yeri işaret etmeyen bir yapı oluşturduk. İçerisine veri atamak için ne yapmalıyız?
        //bl.data = 5;
        // Şimdi de içinde data yada veri bulunan bir yapımız var. 
        //Ancak hala bir noktayı işaret etmiyor bunun için isterseniz ikinci bir blok açıp ona da değer atayarak onu işaret edelim.
        //Blok bl2 = new Blok();
        //bl2.data = 85;
        //bl.next = bl2;
        //Artık linked list olarak tanımladığımız veri yapısının bütün özelliklerini kullandık.
        //Yani bir blok oluşturduk ona veri atadık ve en son başka bir bloğa işaret ettirerek bağladık.

        //Peki bu oluşturma ve atama işlemlerini nasıl otomatik hale getirebiliriz?
        //Bunun için şu örneği çözmekte fayda var.

        //ÖR: Bir head bloğumuz var bu bloktan başlayarak 10 tane blok oluştur, değer ata ve değerleri ekrana yazdır.

        //Blok head = new Blok();
        //Blok last = head;

        //for (int i = 1; i < 11; i++)
        //{
        //    Blok node = new Blok();
        //    node.data = i;
        //    if (head == null)
        //    {
        //        head = node;
        //        last = node;
        //    }
        //    last.next = node;
        //    last = node;
        //    //Console.WriteLine(node.data);
        //}

        ////if olmadan optimize etmek istersek:
        //Blok head2 = null;
        //Blok last2 = null;

        //for (int i = 0; i < 10; i++)
        //{
        //    head2 = new Blok();
        //    head2.data = i;
        //    head2.next = last2;
        //    last2 = head2;
        //}

        ////linked list içerisindeki dataları yazdırma
        //Blok temp = head;
        //while (temp != null)
        //{
        //    Console.WriteLine(temp.data);
        //    temp = temp.next;
        //}

        ////Örn: Başlangıç bloğu head olan 10'luk linked listin data değeri çift olanların değerlerini ekrana bastır.

        //Blok headd = new Blok();
        //Blok lst = new Blok();

        //for (int i = 0; i < 10; i++)
        //{
        //    Blok nd = new Blok();
        //    nd.data = i;
        //    if (headd == null)
        //    {
        //        headd = nd;
        //        lst = nd;
        //    }
        //    lst.next = nd;
        //    lst = nd;
        //}
        //Blok tmp = head;
        //while (tmp != null)
        //{
        //    if (tmp.data % 2 == 0)
        //    {
        //        Console.WriteLine(tmp.data);
        //    }
        //    tmp = tmp.next;
        //}


        #region Örnek Sorular
        /*
         * Head bloğu ilk elemana bakan  uzunluğu bilinmeyen linked list yapsında :
         1-)Listenin en başına data değeri -1 olan blok ekle
         2-)Listenin son elemanından sonra data değeri 100 olan blok ekle
         3-)Listenin ilk elemanını sil
         4-)Listenin son elemanını sil
         5-)Data değeri 5 olan bloğu sil
         6-)Data değeri 5 olan bloktan sonra blok ekle
         7-)Data değeri 5 olan bloktan önce datası -5 olan bir blok ekle
         8-)Bu listenin 7.elemanını yazdır
         9-)7. elemandan sonra eleman ekle
         10-)Bu listenin aynısını ilk blok adı first olan yeni bir linked liste kopyala
         11-)Bu listenin aynısını ilk blok adı first olan yeni bir linked liste tersten kopyala
         12-)Son elemandan önce blok ekle
         13-)Kullanıcının seçtiği sayı kadar sondaki elemanı sil
         */
        #endregion

        #region Çözümler
        // 1)
        //Blok head3 = new Blok();
        //Blok bl3 = new Blok();
        //bl3.data = -1;
        //bl3.next = head3;
        //head3 = bl3; // Bu eşitlemeyi yapmasydık yeni eklediğimiz data değeri -1 olan bloğa erişemeyecektik.


        // 2)
        //Blok h = new Blok();
        //Blok blok = new Blok();
        //blok.data = 100;
        //Blok b = h;
        //while (b.next != null)
        //{
        //    b = b.next;
        //}
        //b.next = blok;


        // 3)
        //Blok h = new Blok();
        //h = h.next;


        // 4)
        //Blok h = new Blok();
        //Blok node = new Blok();
        //while (node.next.next != null)
        //{
        //    node = node.next;
        //}
        //node.next = null;


        // 5)
        //Blok h = new Blok();
        //Blok b = head;
        //while (b.next.data != 5)
        //{
        //    b = b.next;
        //}
        //b.next = b.next.next;


        // 6)
        //Blok bl = new Blok();
        //bl.data = -5;
        //Blok tmp = head;
        //while (tmp.data != 5)
        //{
        //    tmp = tmp.next;
        //}
        //bl.next = tmp.next;
        //tmp.next = bl;
        ////2.yol
        //Block head = null;
        //Block bl = head;
        //while (bl != null)
        //{
        //    if (bl.data == 5)
        //    {
        //        Block yeni = new Block();
        //        yeni.data = 10000000;
        //        yeni.next = bl.next;
        //        bl.next = yeni;
        //    }
        //    bl = bl.next;
        //}



        // 7)
        //Blok bl = new Blok();
        //bl.data = -5;
        //Blok curr = head;
        //while (curr.next.data != 5)
        //{
        //    curr = curr.next;
        //}
        //bl.next = curr.next;
        //curr.next = bl;


        // 8)
        //Blok curr = head;
        //int n = 1;
        //while (n < 8)
        //{
        //    n++;
        //    curr = curr.next;
        //}
        //Console.WriteLine(curr.data);


        // 9)
        //Blok bl = new Blok();
        //bl.data = -7;
        //Blok curr = head;
        //int n = 0;
        //while (n < 6)
        //{
        //    n++;
        //    curr = curr.next;
        //}
        //bl.next = curr.next;
        //curr.next = bl;


        // 10)
        //Blok first = new Blok();
        //Blok curr = head;
        //Blok lst = head;
        //while (curr != null)
        //{
        //    Blok tmp = new Blok(); // yeni bir linked list isteniliyor.
        //    tmp.data = curr.data;
        //    if (first == null) first = tmp;
        //    last.next = tmp;
        //    lst = tmp;
        //    curr = curr.next;
        //}


        // 11)


        // 12)
        //Blok curr = head;
        //Blok n = new Blok();
        //n.data = 99;
        //while (curr.next.next != null)
        //{
        //    curr = curr.next;
        //}
        //n.next = curr.next;
        //curr.next = n;










        #endregion


        #region Örnek Sorular - Recursive
        /*
         * Head bloğu ilk elemana bakan  uzunluğu bilinmeyen linked list yapsında :
         1-) Başlangıç bloğu head olan 10 elemanlı linlked list oluştur. 
         2-)Listenin son elemanından sonra data değeri 100 olan blok ekle
         3-)Listenin son elemanını sil
         4-)Data değeri 5 olan bloğu sil
         5-)Data değeri 5 olan bloktan sonra blok ekle
         6-)Data değeri 5 olan bloktan önce datası -5 olan bir blok ekle
         7-)Bu listenin 7.elemanını yazdır
         8-)7. elemandan sonra eleman ekle
         9-)Bu listenin aynısını ilk blok adı first olan yeni bir linked liste kopyala
         10-)Bu listenin aynısını ilk blok adı first olan yeni bir linked liste tersten kopyala
         11-)Son elemandan önce blok ekle
         12-)Kullanıcının seçtiği sayı kadar sondaki elemanı sil
         */
        #endregion

        #region Çözümler
        // 1)
        //Blok head = null;






        #endregion


        #region Çiftli Linked List
        /*
         * Tekli linked listler her ne kadar dizilerin yerine alternatif olarak kullanılabilseler de yapının kendine has dezavantajları vardır:
           1-) Head'i kaybedersek veya değişikliğe uğratırsak listeye tekrar ulaşmam mümkün değil.
           2-)Sadece tek yönü point etmesi büyük bir sıkıntı.
        
           Bu da bizi konumuz olan çiftli linked listlere getiriyor.
           Tekli linked listlerden daha gelişmiş olan bu yapı verileri saklamamızı ve ulaşmamızı daha kolay hale getiriyor.
        
           Hatırlarsanız tekli linked list yapısını kullanabilmek için adı Block olan bir sınıf tanımlamıştık.
           İşte bu yapıyı da kullanabilmek için böyle bir sınıfa ihtiyacımız var.
           Bu ihtiyacı iki şekilde giderebiliriz;
           1-) Önceki Block classına gidip çiftli linked listlere has olan prev özelliğini tanımlayabiliriz.
           2-) Yeni bir sınıf oluşturup Data,Next ve Prev özelliklerini yeniden tanımlayabiliriz.
         */

        // Örn: 10 Tane bloktan oluşan bir çiftli linked list oluştur.Ve data değerlerini ekrana bastır.

        //Blok bas = new Blok();
        //Blok son = new Blok();
        //bas.data = -1;
        //son = bas;
        //for (int i = 0; i < 10; i++)
        //{
        //    Blok node = new Blok();
        //    node.data = i;
        //    if (head.next == null)
        //    {
        //        head.next = node;
        //        node.prev = head;
        //    }
        //    son.next = node;
        //    node.prev = son;
        //    son = node;
        //}

        //Blok bl = bas;
        //while (bl !=null)
        //{
        //    Console.WriteLine(bl.data);
        //    bl = bl.next;
        //}
        #endregion


        #region Örnek Sorular - Çiftli Linked List
        /*
         * Head çiftli linked list'in herhangi bir bloğuna bakmaktadır
           1-)Dizinin eleman sayısını bul.
           2-)Listede en çok kez tekrar eden elemanı bul.
           3-)Listenin ilk elemanının önüne data değeri -11 olan bir blok ekle.
           4-)Listenin en sonuna data değeri 100 olan bir blok ekle .
           5-)Listenin sondan bir önceki elemanının önüne data değeri 101 olan bir blok ekle.
           6-)Data değeri 7'den sonra bir blok ekle.
           7-)Data değeri 7'den önce bir blok ekle.
           8-)Data değeri 7 olan bir blokları sil. 
           9-)7. Bloğu sil.
           10-)Bu yapıyı dairesel hale getir.
           11-)Liste içerisindeki data değeri 5 olan bloklardan 2. olanı    sil.
           12-)Tekli linked list yapısını çiftliye çevir. 
         */
        #endregion

        #region Çözümleri
        //// 1)
        //int adet = 0;
        //Blok tmp = bas;
        //while (tmp != null)
        //{
        //    Console.WriteLine(tmp.data);
        //    adet++;
        //    tmp = tmp.next;
        //}
        //Console.WriteLine(adet);

        //// 2)



        #endregion


        #region Vize Çalışma Soruları
        //1) Delete Nth Node From End of List
        //Blok lb = head;
        //Blok k = head;
        //while (k != null)
        //{
        //    Console.WriteLine(k.data);
        //    k = k.next;
        //}

        //int sayac = 0;
        //int N = 3;

        //while (lb != null)
        //{
        //    sayac++;
        //    lb = lb.next;
        //}//linked listin kaç eleman barındırdığını bulduk.

        //Blok temp = head;
        //for (int i = 1; i < (sayac - N); i++)
        //{
        //    temp = temp.next;
        //}
        //temp.next = temp.next.next;

        //Blok t = head;
        //while (t != null)
        //{
        //    Console.WriteLine(t.data);
        //    t = t.next;
        //}


        //2) Reverse a Linked List



        #endregion

        #region Stack
        //Bir stack yaapısının her elemanını head olacak şekilde çiftli linked liste aktar.



        #endregion


        //Blok i = new Blok();
        //Console.WriteLine(AddBlock(i,1));

        //Btree root = new Btree();
        //root.data = 5;
        //Insert(root, 3);
        //Insert(root, 6);
        //Insert(root, 10);
        //Insert(root, 2);
        //Insert(root, 1);
        //Insert(root, 8);
        //Insert(root, 0);
        //Insert(root, 7);
        //Insert(root, 4);

        //Write(root);


        //Final Çalışma
        //Console.WriteLine(Fibo(10));

        // 1 - Normal fibonacci çıktısı:

        int adet = 10;
        int a = 0;
        int b = 1;

        for (int i = 0; i <= adet; i++)
        {
            Console.WriteLine(a);
            int temp = a;
            a = b;
            b = temp + b;
        }


        // 2 - En yüksek seçmen sayısını bulma (il, ilçe, mahalle, sandık) -> (10,20,30,40)

        //int[,,,] secim = new int[10,20,30,40];

        //Random rnd = new Random();

        //for (int i = 0; i < 10; i++)
        //{
        //    for (int j = 0; j < 20; j++)
        //    {
        //        for (int k = 0; k < 30; k++)
        //        {
        //            for (int l = 0; l < 40; l++)
        //            {
        //                secim[i, j, k, l] = rnd.Next(1, 1000); // Rastgele seçmen sayısı
        //            }
        //        }
        //    }
        //}


        //int ebToplam = 0;
        //int toplam = 0;
        //for (int i = 0; i < 10; i++)
        //{
        //    for (int j = 0; j < 20; j++) // j'yi güncelle
        //    {
        //        for (int k = 0; k < 30; k++) // k'yi güncelle
        //        {
        //            for (int l = 0; l < 40; l++) // l'yi güncelle
        //            {
        //                toplam += secim[i, j, k, l];
        //            }
        //        }
        //    }
        //    if (toplam > ebToplam)
        //    {
        //        ebToplam = toplam;
        //    }
        //}
        //Console.WriteLine($"En yüksek seçmenin olduğu ilin seçmen sayısı: {ebToplam}");


        //int[,,,] seçmenSayıları = new int[10, 20, 30, 40];
        //Random random = new Random();

        //for (int i = 0; i < 10; i++)
        //{
        //    for (int j = 0; j < 20; j++)
        //    {
        //        for (int k = 0; k < 30; k++)
        //        {
        //            for (int l = 0; l < 40; l++)
        //            {
        //                seçmenSayıları[i, j, k, l] = random.Next(1, 1000); // Rastgele seçmen sayısı
        //            }
        //        }
        //    }
        //}

        //// En yüksek seçmen sayısını ve indisleri bul
        //int enYüksekSeçmenSayısı = 0;
        //int enYüksekIl = -1, enYüksekIlce = -1, enYüksekMahalle = -1, enYüksekSandik = -1;

        //for (int i = 0; i < 10; i++)
        //{
        //    for (int j = 0; j < 20; j++)
        //    {
        //        for (int k = 0; k < 30; k++)
        //        {
        //            for (int l = 0; l < 40; l++)
        //            {
        //                if (seçmenSayıları[i, j, k, l] > enYüksekSeçmenSayısı)
        //                {
        //                    enYüksekSeçmenSayısı = seçmenSayıları[i, j, k, l];
        //                    enYüksekIl = i;
        //                    enYüksekIlce = j;
        //                    enYüksekMahalle = k;
        //                    enYüksekSandik = l;
        //                }
        //            }
        //        }
        //    }
        //}

        //// Sonuçları yazdır
        //Console.WriteLine($"En yüksek seçmen sayısı: {enYüksekSeçmenSayısı}");
        //Console.WriteLine($"İl: {enYüksekIl}, İlçe: {enYüksekIlce}, Mahalle: {enYüksekMahalle}, Sandık: {enYüksekSandik}");




        // 3 - Kendisine integer olarak verilen bir int sayının tersini alarak, basamaklarına ayırıp çiftli linked liste ekleme
        //Console.WriteLine("Bir sayı girin: ");
        //int number = Convert.ToInt32(Console.ReadLine());

        //ReversedList(number);
        //Display();


        // 4 - QueueNode adında bir sınıf yazın. Bu sınıftan türetilen nesneler data ve next özelliklerine sahip olmalı.
        // A.Bu kuyruğun uzunluğunu recursive hesaplayan programı yazın. (5 p)
        // B.Kuyruğun tüm elemanlarını stağa aktarınız.Stak metotlarını  tanımlamanıza gerek yoktur.Stağa aktardığınızda pop sırası ile Dequeue sırası aynı olmalı, stacktan elemanlar kuyruktaki sıraya göre pop edilmeli(20p)

        //Enqueue(1);
        //Enqueue(2);
        //Enqueue(3);
        //Enqueue(4);
        //Enqueue(5);
        //Enqueue(6);
        //Enqueue(7);
        //Enqueue(8);

        //Queue fNode = front;
        //int l = LengthRecursive(fNode);
        //Console.WriteLine("Queue length is: " + l);

        //MoveToStack();
        //Console.WriteLine("------------");
        //for (int i = 0; i < l; i++)
        //{
        //    Console.WriteLine(Pop());
        //}


        // 5 - Root, çiftli linked list ile oluşturulmuş binarytree yapısının kök bloğuna bakmaktadır.
        // Bu ağaç yapısının yaprak seviyesindeki elemanların sayısını bulunuz(25p)

        Console.WriteLine("-------------");

        root.data = 25;
        for (int i = 0; i < btree.Length; i++)
        {
            insert(root, btree[i]);
        }

        siraliYazdir(root);
        Console.WriteLine(leafFind(root));






        Console.ReadLine();
    }

    //recursive ekleme
    //static Blok newNode(int data)
    //{
    //    Blok bl = new Blok();
    //    bl.data = data;
    //    bl.next = null;
    //    return bl;
    //}

    //static Blok AddBlock(Blok head, int data)
    //{
    //    if (head == null) return newNode(data);
    //    head.next = AddBlock(head.next, (data+1));
    //    return head;
    //}

    #region Binary Tree


    static public void Insert(Btree root, int data)
    {
        if (root == null) root = new Btree();
        if (root.data < data)
        {
            if (root.right != null)
            {
                Insert(root.right, data);
            }
            else
            {
                Btree bt = new Btree();
                bt.data = data;
                bt.right = null;
                bt.left = null;
                root.right = bt;
            }
        }
        else
        {
            if (root.left != null)
            {
                Insert(root.left, data);
            }
            else
            {
                Btree bt = new Btree();
                bt.data = data;
                bt.left = null;
                bt.right = null;
                root.left = bt;
            }
        }
    }


    static public void Write(Btree root)
    {
        if (root == null)
        {
            return;
        }
        Write(root.left);
        Console.Write(root.data + "-");
        Write(root.right);
    }

    #endregion


    #region Final Çalışma
    // 1.soru
    //static int Fibo(int n)
    //{
    //    if (n <= 1) return n;
    //    return Fibo(n - 1) + Fibo(n - 2);       
    //}

    // 3.soru
    //static Blok head;
    //static Blok last;

    //static void AddNode(int data)
    //{
    //    Blok bl = new Blok();
    //    bl.data = data;
    //    if(head == null)
    //    {
    //        head = bl; last = bl;
    //    }
    //    else
    //    {
    //        last.next = bl;
    //        bl.prev = last;
    //        last = bl;
    //    }
    //}
    //static void Display()
    //{
    //    Blok curr = head;
    //    while (curr != null)
    //    {
    //        Console.WriteLine(curr.data);
    //        curr = curr.next;
    //    }
    //}
    //static void ReversedList(int number)
    //{
    //    while (number > 0)
    //    {
    //        int digit = number % 10;
    //        AddNode(digit);
    //        number = number / 10;
    //    }
    //}


    // 4.soru
    //static Queue front;
    //static Queue rear;

    //static void Enqueue(int data)
    //{
    //    Queue q = new Queue();
    //    q.data = data;
    //    if (rear == null)
    //    {
    //        rear = q; front = q;
    //    }
    //    else
    //    {
    //        rear.next = q;
    //        rear = q;
    //    }
    //}

    //static int Dequeue()
    //{
    //    if (front == null)
    //    {
    //        Console.WriteLine("Queue is empty.");
    //    }
    //    int tmp = front.data;
    //    front = front.next;
    //    if (front == null)
    //    {
    //        rear = null;
    //    }
    //    return tmp;
        
    //}

    //static int LengthRecursive(Queue head)
    //{
    //    if (head == null)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        return 1 + LengthRecursive(head.next);
    //    }
    //}

    //static void MoveToStack()
    //{
    //    Queue f = front;
    //    while (f != null)
    //    {
    //        int data = f.data;  
    //        Push(data);
    //        Console.Write(data + " ");
    //        f = f.next;  
    //    }
    //    Console.WriteLine();
    //}

    //// Dizi ile stack oluşturma
    //static int sp = -1;
    //static int[] array = new int[10];

    //static void Push(int data)
    //{
    //    if (sp == array.Length - 1)
    //    {
    //        Console.WriteLine("Stack is full.");
    //    }
    //    array[++sp] = data;
    //}
    //static int Pop()
    //{
    //    if (sp == -1)
    //    {
    //        Console.WriteLine("Stack is empty.");
    //    }
    //    return array[sp--];
    //}



    // 5.soru
    static Btree root = new Btree();
    static int[] btree = {18, 31, 9, 21, 13, 6, 86, 76, 88};

    static void insert(Btree root, int data)
    {
        if(data < root.data)
        {
            if (root.left == null)
            {
                Btree bt = new Btree();
                bt.data = data;
                root.left = bt;
                // 2. yazma şekli
                //root.left = new Btree();
                //root.left.data = data;
            }
            else
            {
                insert(root.left, data);
            }
        }
        else
        {
            if (root.right == null)
            {
                Btree bt = new Btree();
                bt.data = data;
                root.right = bt;
                // 2. yazma şekli
                //root.right = new Btree();
                //root.right.data = data;
            }
            else
            {
                insert(root.right, data);
            }
        }
    }
    static void siraliYazdir(Btree root)
    {
        if (root == null) return;

        siraliYazdir(root.left);
        Console.WriteLine(root.data);
        siraliYazdir(root.right);
    }

    static int leafCount = 0;
    static int leafFind(Btree root)
    {
        if (root == null) return 0;

        if (root.right == null && root.left == null)
        {
            leafCount++;
        }

        leafFind(root.left);
        leafFind(root.right);

        return leafCount;
    }





    #endregion

}



