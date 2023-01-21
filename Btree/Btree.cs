using System;
using System.Collections.Generic;

namespace BtreeMetodları
{
    class Program
    {
        class Block
        {
            public int data;
            public Block prev;
            public Block next;
        }

        static int[] Btree = new int[100];

        class blockBtree
        {
            public int data;
            public blockBtree left;
            public blockBtree right;
        }

        static void btreeYaz(int parent)
        {
            Console.WriteLine(Btree[parent*2+1]);
            Console.WriteLine(Btree[parent*2+2]);
        }

        //Recursive yazmak istersek
        static void btreeYazRecursive(int[] btree, int indis)
        {
            if (indis >= btree.Length) return;

            Console.WriteLine(btree[indis]);

            btreeYazRecursive(btree, indis*2+1); //LEFT CHILD
            btreeYazRecursive(btree, indis*2+2); //RIGHT CHILD
        }

        //Ağaçlarda arama
        static bool bulundu = false;

        static void findBtree(int[] btree, int indis, int data)
        {
            if (indis >= btree.Length) return;
            if (btree[indis] == data) bulundu = true;

            findBtree(btree, indis*2+1, data);
            findBtree(btree, indis*2+2, data);

            //Burada O(2^n) karmaşıklığa sahip.
        }

        static void addBtree(blockBtree bNode, int deger)
        {
            //Ağaca veri ekleme sadece yapraklarda olur. Araya eleman ekleme yapılmaz.

            if (bNode == null) return;
            if(bNode.data < deger)
            {
                if (bNode.right != null)
                {
                    addBtree(bNode.right,deger);
                }
                else
                {
                    blockBtree bt = new blockBtree();
                    bt.data = deger;
                    bt.left = null;
                    bt.right = null;
                    bNode.right = bt;                    
                }
            }
            else
            {
                if (bNode.left != null)
                {
                    addBtree(bNode.left,deger);
                }
                else
                {
                    blockBtree bt = new blockBtree();
                    bt.data = deger;
                    bt.left = null;
                    bt.right = null;
                    bNode.left = bt;
                }
            }
        }

        static int btreeSearch(blockBtree btree, int arananDeger)
        {
            if (btree == null) return 0;
            if (btree.data == arananDeger) return 1;

            if (btree.data < arananDeger) return btreeSearch(btree.right, arananDeger);
            else return btreeSearch(btree.left, arananDeger);
        }

        static blockBtree linkedlistBtreeOlustur(int[] btree, int indis)
        {
            if (indis >= btree.Length) return null;
            blockBtree bt = new blockBtree();
            bt.data = btree[indis];
            bt.left = linkedlistBtreeOlustur(btree,indis*2+1);
            bt.right = linkedlistBtreeOlustur(btree,indis*2+2);
            return bt;
        }


        //Örnek Soru-1:
        //Linked list ile oluşturulmuş bir binarytree'de search yap.(recursive)

        static int[] binaryTree = new int[100];

        static int find(blockBtree bt, int aranan)
        {
            if (bt == null) return 0;
            if (bt.data == aranan) return 1;
            return find(bt.left, aranan) + find(bt.right,aranan); 
        }

        //Btree olamdan arama yapılamaz o yüzden önce Btree'nin oluşturulması lazım.
        static blockBtree olustur(int[] bt, int indis)
        {
            if (indis >= bt.Length) return null;
            blockBtree node = new blockBtree();
            node.data = binaryTree[indis];
            node.left = olustur(bt, indis*2+1);
            node.right = olustur(bt, indis*2+2);
            return node;
        }


        //Örnek Soru-2:
        //Linked listle oluşturulmuş bir tree'yi diziye aktar.

        static int[] btree = new int[100];

        static blockBtree Olustur(int[] btree, int indis)
        {
            if (indis >= btree.Length) return null;
            blockBtree bl = new blockBtree();
            bl.data = btree[indis];
            indis = indis * 2 + 1;
            bl.left = Olustur(btree, indis);
            indis++;
            bl.right = Olustur(btree, indis);
            return bl;
        }

        static void aktar(blockBtree bl, int[] bt, int indis)
        {
            if (bl == null) return;
            bt[indis] = bl.data;
            aktar(bl.left, bt, indis*2+1);
            aktar(bl.right, bt, indis*2+2);
        }


        static void yaz(int[] bt, int indis)
        {
            if (indis >= bt.Length) return;
            if (bt[indis] != 0) Console.WriteLine(bt[indis]);
            yaz(bt, indis*2+1);
            yaz(bt, indis*2+2);
        }

        //Final Sorusu-1:
        //Linked List ile oluşturulmuş Btree'nin derinliğini bulma

        static int height = -1;
        static int[] tree = new int[100];

        //ilk önce bir ağaç oluşturuyoruz.
        static blockBtree bTreeOlustur(int[] tree, int indis)
        {
            if (indis >= tree.Length) return null;
            blockBtree newblok = new blockBtree();
            newblok.data = tree[indis];
            indis = indis * 2 + 1;
            newblok.left = bTreeOlustur(tree,indis);
            indis++;
            newblok.right = bTreeOlustur(tree,indis);
            return newblok;
        } 

        //oluşturduğumuz dizide derinlik/yükselik bulalım.
        static int derinlik(blockBtree treeNode, int localHeight)
        {
            if (treeNode == null) return 0;
            height++;
            if (localHeight > height) height = localHeight;
            derinlik(treeNode.left, localHeight);
            derinlik(treeNode.right, localHeight);
            return height;
        }


        //Final Sorusu-2:
        //1000 elemanlı int tipindeki bir dizi ile oluşturulanbir dizi Binary Tree'nin verilerini tutmaktadır. Bu dizinin tüm elemanlarını while kullanarak ekrana yazdırma.

        static int[] BinaryTree = new int[1000];

        static void yazdır(int[] bt, int indis)
        {
            if (indis >= bt.Length) return;
            while (bt[indis] != 0)
            {
                Console.WriteLine(bt[indis]);
            }
            yazdır(bt, indis*2+1);
            yazdır(bt, indis*2+2);
        }

        //stack kullanarak
        //Çözüm-1:

        //Stack çözümü kullanabilmemiz için öncelikle stack yapısını inşa etmemiz gerekiyor.
        static int[] binaryT = new int[1000];
        static Block sp = null;
        static void push(int data)
        {
            Block bl = new Block();
            bl.data = data;
            bl.next = null;
            bl.prev = null;
            if (sp == null) sp = bl; return;
            bl.next = sp;
            sp.prev = bl;
            sp = bl;
        }
        static int pop()
        {
            if (sp == null) Console.WriteLine("Stack boş");
            int tmp = sp.data;
            sp = sp.next;
            return tmp; 
        }
        static void Yazdır()
        {
            push(0);
            while (sp != null)
            {
                int indis = pop();
                Console.WriteLine(binaryT[indis]);
                indis = indis * 2 + 1;
                if (indis <= 1000) push(indis);
                indis++;
                if (indis <= 1000) push(indis);
            }

        }

        //Mazeret Sınavı:
        //Root çiftli linked list ile oluşturulmuş  binarytree yapısının kök bloğuna bakmaktadır. 
        //Bu ağaç yapısının yaprak seviyesindeki elemanların sayısını bulunuz.


        //Linked list için yapımızı oluşturduk.
        //class Block bunun aynısı olur; left -> next, right -> prev yazılır.
        class blockBT
        {
            public int data;
            public blockBT left;
            public blockBT right;
        }

        static int[] bt = {18, 31, 44, 9, 21, 13, 6, 86, 30, 76, 88};
        //static int[] bt = new int[100];

        static void insert(blockBT root, int data)
        {
            if(data > root.data)
            {
                if(root.right == null)
                {
                    root.right = new blockBT();
                    root.right.data = data;
                }
                insert(root.right, data);
            }
            else
            {
                if (root.left == null)
                {
                    root.left = new blockBT();
                    root.left.data = data;
                }
                insert(root.left, data);
            }
        }

        static void sıralıYazdır(blockBT root)
        {
            if (root == null) return;

            sıralıYazdır(root.left);
            Console.WriteLine(root.data);
            sıralıYazdır(root.right);
        }

        static int leafSayisi = 0;
        //Bir düğümün yaprak olabilmesi için sağ ve sol'unda düğüm olmaması gerekiyor.
        static void leafBul(blockBT root)
        {
            if (root == null) return;
            if (root.right == null && root.left == null) leafSayisi++;
            leafBul(root.right);
            leafBul(root.left);
        }



        //static int[] Btree = { 50, 17, 72, 12, 23, 54, 76, 9, 14, 19, 0, 0, 67 };

        static void Main(string[] args)
        {
            //BTREE
            Btree[0] = 50;
            Btree[1] = 17;
            Btree[2] = 72;
            Btree[3] = 12;
            Btree[4] = 23;
            Btree[5] = 54;
            Btree[6] = 76;
            Btree[7] = 9;
            Btree[8] = 14;
            Btree[9] = 19;
            Btree[10] = -1; // Null demektense -1 değerini verdik
            Btree[11] = -1; // -1 parent'ın child'ı yok demek.
            Btree[12] = 67;
            Btree[13] = -1;
            Btree[14] = -1;


            //Recursive Btree Yazdırma
            btreeYazRecursive(Btree, 0);

            //Recursive Olmayan Yazdırma
            Stack<int> stack = new Stack<int>();
            stack.Push(0); //Kök eleman

            while (stack.Count > 0)
            {
                int indis = stack.Pop();
                Console.WriteLine(Btree[indis]);
                indis = indis * 2 + 1;
                if (indis <= 14) stack.Push(indis);
                indis++;
                if (indis <= 14) stack.Push(indis);
            }

            //Btree İçinde Eleman Bulma
            Stack<int> st = new Stack<int>();
            st.Push(0); //Kök eleman
            bool bulundu = false;
            while (st.Count > 0)
            {
                int indis = st.Pop();
                Console.WriteLine(Btree[indis]);

                if (Btree[indis] == 76) bulundu = true; break;

                indis = indis * 2 + 1;

                if (indis < Btree.Length) st.Push(indis);

                indis++;

                if (indis < Btree.Length) st.Push(indis);
            }
            if (bulundu) Console.WriteLine("Bulundu.");
            else Console.WriteLine("Bulunamadı.");





          
        }
    }
}
