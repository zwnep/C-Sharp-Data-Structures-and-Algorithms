using System;

namespace Btree
{
    class Program
    {
        class blockBtree
        {
            public int data;
            public blockBtree left;
            public blockBtree right;

            public blockBtree(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        class Tree
        {
            public blockBtree root;
            public Tree()
            {
                root = null;
            }

            //Ağacın root'unu oluşturan metod
            public blockBtree newNode(int data)
            {
                root = new blockBtree(data);
                return root;
            }

            public blockBtree insert(blockBtree root, int data)
            {
                blockBtree node = new blockBtree(data);

                if (root != null)
                {
                    if (data < root.data) //ekleme işlemi yapılırken eklenen node'un da içinde left'i ve right'ı olacaktır. Bu sebeten recursive bir yapı olacaktır.
                    {
                        root.left = insert(root.left, data);
                    }
                    else
                    {
                        root.right = insert(root.right, data);
                    }
                }
                else
                {
                    root = newNode(data);                    
                }

                return root;
            }

            //Ağaç üzerinde dolaşma
            //1- preOrder --> önce köke uğra
            public void preOrder(blockBtree root)
            {
                if (root != null)
                {
                    Console.Write(root.data + " ");
                    preOrder(root.left);
                    preOrder(root.right);
                }
            }

            //2- inOrder --> ortada köke uğra
            public void inOrder(blockBtree root)
            {
                if (root != null)
                {                    
                    inOrder(root.left);
                    Console.Write(root.data + " ");
                    inOrder(root.right);
                }
            }

            //3- postOrder --> sonda köke uğra
            public void postOrder(blockBtree root)
            {
                if (root != null)
                {
                    postOrder(root.left);
                    postOrder(root.right);
                    Console.Write(root.data + " ");                    
                }
            }


            //Ağacın eleman sayısı ve yüksekliği
            //Bir ağaç oluşturulduğunda ilk eleman root'dur.
            //Ağacın yüksekliği en alttaki yaprak düğümün köke olan yüksekliğidir. Yani root 0'dır, eleman arttıkça yükseklik duruma göre değişir.

            public int size(blockBtree root)
            {
                if (root == null) return 0;
                else
                {
                    return size(root.left) + 1 + size(root.right);
                }
            }

            public int height(blockBtree root)
            {
                if (root == null) return -1;
                else
                {
                    int l, r;
                    l = height(root.left);
                    r = height(root.right);
                    if (l > r) return l + 1;
                    else return r + 1;
                }
            }
        }


        static void Main(string[] args)
        {

            #region TREE VERİ YAPISI

            /* Doğrusal veri yapıları olan diziler, bağlı listeler, yığınlar ve kuyruklardan farklı olarak, 
             * doğrusal olmayan hiyerarşik bir veri yapısıdır*/
            /* Döngü içermeyen veri yapısıdır (İki çocuğun birbirine bağlanması). Recursive olarak yazılır*/
            /* Node (Düğüm)           -> ağacın elemanlarıdır */
            /* Edges (Dal/Kenar)      -> süğümleri birbirine bağlar*/
            /* Root (Kök)             -> ağacın en tepesindeki elemanıdır*/
            /* Parent (baba)          -> Çocuğu olan düğümlerdir*/
            /* Child (Çocuk)          -> Düğüme bağlı olan alt düğümlerdir*/
            /* Leaf (Yaprak)          -> Çocuğu olmayan düğümlerdir*/
            /* Subtree                -> Bir düğümün alt ağaçlarıdır*/
            /* Sibling (kardeş düğüm) -> Aynı babaya sahip düğümlerdir*/
            /* Descendant (varisler)  -> Bir düğüme bağlı tüm alt düğümlere o düğümün varisleri denir*/
            /* Ancestor (ata)         -> Bir düğümden köke kadar izlenen yoldaki diğer tüm düğümler, o düğümün atalardır*/
            /* Path (yol)             -> Bir düğümün aşşağıya doğru bir başka düğüme gidebilmek için üzerinden geçilmesi gerek düğümlerin listesi */
            /* Depth of Tree (Ağacın derinliği) -> Kök düğümden en uçtaki yaprak düğüme kadar olan uzaklıkdır / kök düğümün derinliği 1 dir*/
            /* Derinlik               -> Bir düğümün kök düğüme olan uzaklığıdır*/
            /* Height (yükseklik)     -> O düğümden kendisiyle ilişkili en uzak yaprak düğüme giden yolun uzunluğudur*/
            /* Düzey                  -> İki düğüm arasındaki yolun üzerinde bulunan düğümlerin sayısı /Kök düğümün düzeyi 1 / doğrudan köke bağlı düğümlerin düzeyi 2 */
            /*Degree (derece)         -> Bir düğümün derecesi çocuk sayısına eşittir*/
            /**/

            #endregion

            Tree btree = new Tree();
            btree.root = btree.insert(btree.root, 10);
            btree.root = btree.insert(btree.root, 15);
            btree.root = btree.insert(btree.root, 5);
            btree.root = btree.insert(btree.root, 20);
            btree.root = btree.insert(btree.root, 3);
            btree.root = btree.insert(btree.root, 12);
            btree.root = btree.insert(btree.root, 9);


            Console.WriteLine("root: " + btree.root.data);
            Console.WriteLine("root.right: " + btree.root.right.data);
            Console.WriteLine("root.left: " + btree.root.left.data);

            Console.WriteLine("*************************************");

            //Ağaç üzerindeli elemanlara bu şekilde dolaşmak belli bir sayıdan sonra imkansızlaşıyor.

            //Ağaç üzerinde dolaşma 3 farklı şekilde olur.
            //1- preOrder(önce kök)
            //2- inOrder(ortada kök)
            //3- postOrder(en son kök)

            Console.Write("preOrder: ");
            btree.preOrder(btree.root);
            Console.WriteLine();
            Console.Write("inOrder: ");
            btree.inOrder(btree.root);
            Console.WriteLine();
            Console.Write("postOrder: ");
            btree.postOrder(btree.root);

            Console.WriteLine("*************************************");

            //Eleman sayısı ve yükseklik
            Console.WriteLine("\nEleman sayısı: " + btree.size(btree.root));

            Console.WriteLine("\nYükseklik: " + btree.height(btree.root));





            Console.ReadKey();
        }
    }
}
