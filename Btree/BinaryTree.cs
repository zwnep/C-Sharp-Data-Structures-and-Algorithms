using System;
using System.Collections.Generic;

namespace data_structure_btree
{
    class Program
    {
        //Binary Tree
        //En küçük tree yapısı olan olan binary tree veya ikili ağaç olarak türkçeleştirebileceğimiz bu veri yapısını en az bir bloktan oluşup iki adet pointer'a sahiptir.
        //Geçtiğimiz diğer veri yapılarında da olduğu gibi binary treelerinde birçok kullanım alanı vardır.

        //Örnek verecek olursak;
        //1-)Sıkıştırma algoritmalarında
        //2-)Sıralama algoritmalarında
        //3-)Search algoritmalarında
        //4-)Veritabanı sistemlerinde vb.sistemlerde kullanılır.

        //Şimdi gelelim tree terminolojisine,
        //Tree'yi oluşturan bloklara node veya düğüm denir.
        //Tree'nin en tepesindeki node'a root yani kök denir.
        //Tree'nin en alt kısmdaki node'lara ise leaf yani yaprak denir.
        //Tree'de bulunan ve işaret eden node'ara parent,
        //işaret edilen nodelara ise child node denir.

        //Son olarak levellerden bahsedecek olursak
        //Rootun bulunduğu level, root level yada sıfırıncı level olarak geçer.
        //Root'tan leaflere doğru inildikçe birinci level,ikinci level şeklide artarken son levele, leaf level denir.

        //ÖR:      O => root(root level)
        //       /   \
        //      O     O => (1. level)
        //     / \   / \
        //    O O O O   0 => leaf(leaf level)

        //Şimdi eğer mantığını anladıysak gelelim bizi ilgilendiren kısma yani kodlamsına.
        //Binary treeler tıpkı stackta ve kuyrukta olduğu gibi iki yapıyla kodlanabilir.
        //1-)Diziler
        //2-)Linked Listler


        //İlk önce dizilerle kodlamasına başlayalım.

        static int[] btree = new int[100]; //tree olarak kullanacağımız dizimizi oluşturduk.

        //static void yaz(int[] btree, int indis)
        //{
            //if (indis >= btree.Length) return;
            //if (btree[indis] != 0) Console.WriteLine(btree[indis]);
            //Şu anda içindeki verilere ulaşabiliriz ancak dizi şekline değil de tree şeklinde bastırmak lazım, bunun için;
            //yaz(btree, indis*2+1); //tree'nin SOL tarafındaki elemanları bastırmamıza yarar.
            //yaz(btree, indis*2+2); //tree'nin SAĞ tarafındaki elemanları bastırmamıza yarar.
            //İkisini birlikte kullanımı tree'deki bütün elemanları yazdırır.
        //}
        //Tabi bu yazdırma işleminin verimli başarılı olabilmesi için binary tree dizimize ona göre eleman ataması yapmalıyız.
        //Yani;
        //ÖR:        (15)
        //          /   \
        //         /     \
        //      (11)     (26)
        //     /   \     /   \
        //    /     \   /     \
        //   (8)  (12) (20)  (30)
        //  /  \   \           \
        // /    \   \           \
        //(6)  (9)  (14)        (35)  şeklinde bir binary treemiz olsun.

        //Bu treeyi dizimize kodlarken önce 15'i sonra 11'i sonra 26'yı olacak şekilde level level sırasıyla yazmamız lazım.
        //Yani diziye atama şu şekilde olmalı.

        static void Main(string[] args)
        {
            //btree[0] = 15;
            //btree[1] = 11;
            //btree[2] = 26;
            //btree[3] = 8;
            //btree[4] = 12;
            //btree[5] = 20;
            //btree[6] = 30;
            //btree[7] = 6;
            //btree[8] = 9;
            //btree[9] = 0;
            //btree[10] = 14;
            //btree[11] = 0;
            //btree[12] = 0;
            //btree[13] = 0;
            //btree[14] = 35;

            //Boş node'lar sıfır atamazsak bastırılma sırasında yanlış değerlendirilecek.
            //Şimdi herşey hazır metodumuzu parametreleri ile çağıralım.
            //yaz(btree,0);

            //Yaz metodumuzun içerisinde birkaç değişiklik yaptığımızda sonuçlarımızdaki değişimlere beraber bakalım.
            //Eğer yaz metodu şu şekilde olsaydı;
            //yaz(btree, indis * 2 + 1);
            //Console.WriteLine(btree[indis]);
            //yaz(btree, indis * 2 + 2);
            //Önce sol node'lar sonra sağ node'lar bastırılacaktır.
            //Peki son olarak şu şekilde olsaydı;
            //yaz(btree, indis * 2 + 1);
            //yaz(btree, indis * 2 + 2);
            //Console.WriteLine(btree[indis]);
            //Önce child node'lar sonra parent node'lar bastırılacaktır.

            //  **NOT**:Recursive binary tree işlemlerinde 100.000 levelden sonra stack overflow hatası verebilir.Öncesinde vermez.

            //btree[0] = 15;
            //btree[1] = 11;
            //btree[2] = 26;
            //btree[3] = 8;
            //btree[4] = 12;
            //btree[5] = 20;
            //btree[6] = 30;
            //btree[7] = 6;
            //btree[8] = 9;
            //btree[9] = 0;
            //btree[10] = 14;
            //btree[11] = 0;
            //btree[12] = 0;
            //btree[13] = 0;
            //btree[14] = 35;

            //while (sp != null)
            //{
            //    int indis = pop();
            //    Console.WriteLine(btree[indis]);
            //    indis = indis * 2 + 1;
            //    if (indis <= 15) push(indis);
            //    indis++;
            //    if (indis <= 15) push(indis);

            //}



            //Bu soruyu kendimiz stack oluşturmadan hazır stack oluşturarak da çözebiliriz.

            //btree[0] = 15;
            //btree[1] = 11;
            //btree[2] = 26;
            //btree[3] = 8;
            //btree[4] = 12;
            //btree[5] = 20;
            //btree[6] = 30;
            //btree[7] = 6;
            //btree[8] = 9;
            //btree[9] = 0;
            //btree[10] = 14;
            //btree[11] = 0;
            //btree[12] = 0;
            //btree[13] = 0;
            //btree[14] = 35;

            //Stack<int> st = new Stack<int>();
            //st.Push(0);
            //while (st.Count > 0 )
            //{
            //    int indis = st.Pop();
            //    Console.WriteLine(btree[indis]);
            //    indis = indis * 2 + 1;
            //    if (indis < 15) st.Push(indis);
            //    indis++;
            //    if (indis < 15) st.Push(indis);
            //}
            //şimdiye kadar diziler üzerinden binary tree'yi inceledik.Artık linked listlerle binary tree oluşturma kısmındayız.

            //Hatırlarsanız linked listlerde next ve prev pointerları vardı. Binary tree oluştururken de buna benzer pointerlara ihtiyacımız olacak.

            //Bu pointerların adlandırması left ve right olsun;
            //Son olarak bir de bu bloğun datası olsun.
            //Bunun için yeni bir class tanımlayacağız.

            btree[0] = 15;
            btree[1] = 11;
            btree[2] = 26;
            btree[3] = 8;
            btree[4] = 12;
            btree[5] = 20;
            btree[6] = 30;
            btree[7] = 6;
            btree[8] = 9;
            btree[9] = 0;
            btree[10] = 14;
            btree[11] = 0;
            btree[12] = 0;
            btree[13] = 0;
            btree[14] = 35;

            //istersek elemanları yazdırmak için ayrı bir metod kullanabiliriz.
            static void write(Blockbtree bt)
            {
                if (bt == null) return;
                Console.WriteLine(bt.data);
                write(bt.left);
                write(bt.right);
            }
            //Metodun içinde head ile çağrılırsa elemanları yazdıracaktır.
        }



        //B-Tree'leri Linked Listler yardımıyla oluşturma

        class Blockbtree
        {
            public int data;
            public Blockbtree left;
            public Blockbtree right;
        }
        //Ağacı linked list yapısı ile oluşturacağımız için LL yapısına benzer bir class oluşturduk.
        //Bir binarytree'nin sağ çocuğu, sol çocuğu ve değerleri vardı.

        //Ağacı oluşturma işlemi:
        static Blockbtree make(int[] bt, int indis)
        {
            if (indis >= bt.Length) return null;
            if (bt[indis] != 0) Console.WriteLine(bt[indis]); // Buradaki if'e çok takılmayın değeri 0 olan blokları bastırmasın diye ekledim.
            Blockbtree bNode = new Blockbtree();
            bNode.data = bt[indis];
            indis = indis * 2 + 1;
            bNode.left = make(bt,indis);
            bNode.right = make(bt,indis++); //Burada da indisin bir fazlasıyla döndürmemizin sebebi binaryTree'lerde sağ çocuğu indis*2+2 ile geziyorduk.
            return bNode;
        }
        //Son olarak ise root'a yani köke ihtiyaç var.
        static Blockbtree root = null;

        //*************************************************************

        // Binary treemizi bastırma kısmında recursive çözüm her ne kadar işimizi görsede tehlikeli bir yanı vardır.

        //Konuyu biraz daha açmak gerekirse bir metodun alt alta iki kez recursive çağrılmasının hesap karmaşıklığı 2 ^ n 'dir.
        //Yani üstel bir büyüme gösteren bu algoritma uzun vadede tehlike arz etmektedir.

        //Recursive çözüme alternatif niteliğinde bir çözüm olan bir algoritma daha vardır.
        //Bu algoritma *stack* kullanımını içerir isterseniz anlatmayı bırakıp kodlama kısmına geçelim.

        //class Block
        //{
        //    public int data;
        //    public Block next;
        //    public Block prev;
        //}

        //static int[] btree = new int[100];
        //static Block sp = null;

        //static void push(int data)
        //{
        //    Block bl = new Block();
        //    bl.data = data;
        //    bl.next = null;
        //    bl.prev = null;
        //    if (sp == null) sp = bl;  return;
        //    bl.next = sp;
        //    sp.prev = bl;
        //    sp = bl;
        //}

        //static int pop()
        //{
        //    int tmp = sp.data;
        //    sp = sp.next;
        //    return tmp;
        //}
        //Yazdığımız kodları Main() içerisinde yazdıralım.

        //Örnek sorular - BTree:
        #region
        //1- Binary treede bir elemanın olup olmadığını buldur.(hem normal hem recursive çöz)
        //2- Binary treede bir elemanın kaç kez tekrar ettiğini buldur.(hem normal hem recursive çöz)
        //3- Linked list ile oluşturulmuş bir binarytree'de search yap.(recursive)
        //4- Linked listle oluşturulmuş bir tree'yi diziye aktar.
        //5- Binarytree'nin elemanlarını stacklarla yazdır.
        //6- Sırasız elemanları bulunan bir diziyi sıralı şekilde tree'ye aktar.

        //Çözümleri:
        //1- Binary treede bir elemanın olup olmadığını buldur.(hem normal hem recursive çöz)

        static int ara(int[] btree, int indis, int aranan)
        {
            if (indis >= btree.Length) return 0;
            if (btree[indis] < aranan) return ara(btree, indis * 2 + 2, aranan);
            else if (btree[indis] == aranan) return 1;
            else return ara(btree, indis*2+1, aranan);
        }

        //2- Binary tree'de bir elemanın kaç kez tekrar ettiğini buldur.(hem normal hem recursive çöz)

        //(RECURSİVE)
        static int[] binarytree = new int[100];

        static int adet = 0;

        static int find(int[] binarytree, int indis, int aranan)
        {
            if (indis <= binarytree.Length) return 0;
            if (binarytree[indis] == aranan) adet++;
            return find(binarytree,indis*2+1,aranan) + find(binarytree,indis*2+2,aranan);
        }

        #endregion


    }
}
