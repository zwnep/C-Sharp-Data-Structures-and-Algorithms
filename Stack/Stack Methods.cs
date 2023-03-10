using System;
using System.Collections.Generic;
using System.IO;

namespace StackMethods
{
    class Program
    {
        #region Stack Veri Yapısı
        /*
         * Yığın veri yapısında ara elemanlara doğrudan erişim yoktur.
         * LİFO -> Last in First out / Son giren İlk çıkar prensibi ile verilere erişilir.
         * Yığın veri yapısında, dizilerden farkılı olarak veriye ancak belirli bir sırayla erişilebilir.
         * Yığının eleman sayısı çalışma zamanında arttırılıp azaltılabilir.
         * Yığından eleman ekleme çıkarma işlem SADECE en üstten(top) yapılır.
         * Yığın için yeterli bellek kalmazsa STACKOVERFLOW hatası alınır.
         * PUSH -> Yığına eleman ekleme
         * POP  -> Yığından eleman çıkarma
         * PEEK -> Yığının en üstündeki elemanı döndürür
         * İşletim sistemleri, oyun yazılımları, bazı yazılımlarda, compiler, infix ve postfix yapılarında, metot çağırmalarında stack kullanır.
         */
        #endregion


        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }

        //Dizi ile Stack Oluşturma
        static int[] stack = new int[100];
        static int sp = -1; //STACK POİNTER her zaman -1'den başlar.

        static void push(int data)
        {
            if (sp == stack.Length - 1) Console.WriteLine("Stack dolu. Eleman eklenemez.");
            sp++;
            stack[sp] = data;
            //stack[++sp] = data şeklinde de yazılabilirdi.
        }

        static int pop()
        {
            if (sp == -1) Console.WriteLine("Stack boş.");
            int tmp = stack[sp];
            sp--;
            return tmp;
        }


        //Linked Listlerle Stack Oluşturma
        static Block spLinked = null;

        static void Push(int data) //Çiftli Linked List
        {
            Block bl = new Block();
            bl.data = data;
            bl.next = null;
            bl.prev = null;
            if (spLinked == null) spLinked = bl; return;
            bl.next = spLinked;
            spLinked.prev = bl;
            spLinked = bl;
        }

        static int Pop() //Çiftli Linked List
        {
            int tmp = spLinked.data;
            spLinked = spLinked.next;
            return tmp;
        }


        #region Stack Palindromik Sayı
        static void palindrom(int sayı)
        {           
            string sayi = Convert.ToString(sayı);
            for (int i = 0; i < sayi.Length; i++)
            {
                push(sayi[i]);
            }
            for (int j = 0; j < sayi.Length; j++)
            {
                if (pop() == sayi[j]) Console.WriteLine("Palindrom");
                else Console.WriteLine("Palindrom değil");
            }
        }
        #endregion


        #region STACK Substring Bulma         
        //Stack<string> st = new Stack<string>();
        //st.Push(@"C:\"); //Bilgisayarınızdaki c dizinini stack'a ekler
        //while (st.Count > 0)
        //{
        //    string path = st.Pop();
        //    string[] dizinler = Directory.GetDirectories(path); //Direcctory'yi kullanabilmek için en üstte !! using System.IO !! eklenmeli
        //    string[] dosyalar = Directory.GetFiles(path);
        //    for (int i = 0; i < dizinler.Length; i++)
        //    {
        //        st.Push(dizinler[i]);
        //    }
        //    foreach (string item in dosyalar)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}        
        #endregion


        #region Stack Parantez Problemi //Açılan parantez kapatılmışmı
        /*
        string s = "([])";
        string left = "{[("; //burada sağ ve sol parantezlerin sıraları aynı olmalı
        string right = "}])";
        int hata = 0;
        for (int i = 0; i < s.Length; i++)
        {
            // IndexOf --> s'in içindeki karakter left'in içerisindeki herhangi bir karakterle eşleşirse bulunan stringin (leftin içindeki)indisini döner 
            int indis = left.IndexOf(s[i].ToString());
            if (indis != -1)
            {
                push(right[indis]);
            }
            else
            {
                indis = right.IndexOf(s[i].ToString());
                if (indis != -1)
                {
                    if (pop() != right[indis])
                    {
                        hata = 1;
                        break;
                    }
                }
            }
        }
        if (hata == 1)
        {
            Console.WriteLine("Hatalı");
        }
        else
        {
            Console.WriteLine("Hatasız");
        }*/
        #endregion


        #region Infix to Postfix
        //string infix = "a+b*c-d";
        //string postfix = "";
        //string op = "$(+-*/)";

        /*string oncelik = "0011220";
        push((byte)'$');
        for (int i = 0; i < infix.Length; i++)
        {
            if (op.IndexOf(infix[i])==-1)
            {
                postfix = postfix + infix[i];
                continue;
            }
            if (infix[i]=='(')
            {
                push((byte)'(');
                continue;
            }
            if (infix[i] == ')')
            {
                while (peek()!='(')
                {
                    postfix += (char)pop();
                }
              pop();
                continue;
            }
            int a = (byte)peek();
            a = op.IndexOf((char)a);
            if (oncelik[a]>oncelik[op.IndexOf(infix[i])])
            {
                postfix += (char)pop();
                push(infix[i]);
            }
            else
            {
                push(infix[i]);
            }
        }
        while (peek() != '$')
        {
            postfix += (char)pop();
        }
        Console.WriteLine(postfix);
        */
        #endregion


        #region Postfix to Infix
        // string postfix = "ab*c+d-"; //--> a*b+c-d
        //string op = "+-*/";
        /* string operand = "abcd";
         int[] deger = { 1,2,3,3 }; //a=1 b=2 c=3 d=2
         Stack<int> st = new Stack<int>();
         for (int i = 0; i < postfix.Length; i++)
         {
             if (operand.IndexOf(postfix[i])!=-1)
             {
                 int indis = operand.IndexOf(postfix[i]);
                 st.Push(deger[indis]);
                 continue;
             }
             int karakter2 = st.Pop();
             int karakter1 = st.Pop();
             int sonuc = 0;
             if (postfix[i] == '*') sonuc = carp(karakter1, karakter2);
             if (postfix[i] == '/') sonuc = bolme(karakter2, karakter1);
             if (postfix[i] == '+') sonuc = topla(karakter2, karakter1);
             if (postfix[i] == '-') sonuc = fark(karakter2, karakter1);
             st.Push(sonuc);
         }
         Console.WriteLine(st.Pop());*/
        #endregion
























        static void Main(string[] args)
        {
            push(1);
            push(2);
            push(3);
            push(4);
            Console.WriteLine(pop());
            Console.WriteLine(pop());
            Console.WriteLine(pop());
            Console.WriteLine(pop());
            Push(10);
            Push(20);
            Push(30);
            Console.WriteLine(Pop());
            Console.WriteLine(Pop());
            Console.WriteLine(Pop());

            Console.WriteLine("----------");

            for (int i = 0; i < 100; i++)
            {
                push(i);
            }
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(pop());
            }
            Console.ReadLine();
        }
    }
}
