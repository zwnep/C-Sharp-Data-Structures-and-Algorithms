using System;
using System.Collections.Generic;

namespace QueueQuestions
{
    class Program
    {
        //Örnek Soru-1:
        //QueueNode adında bir sınıf yazın. Bu sınıftan türetilen nesneler data ve next özelliklerine sahip olmalı.

        //A. Bu kuyruğun uzunluğunu recursive  hesaplayan programı yazın. 
        //B. Kuyruğun tüm elemanlarını stağa aktarınız.Stak metotlarını  tanımlamanıza gerek yoktur.Stağa aktardığınızda pop sırası ile Dequeue sırası aynı olmalı, stacktan elemanlar kuyruktaki sıraya göre pop edilmeli.

        class QueueNode
        {
            public int data;
            public QueueNode next;
        }

        static QueueNode rear = null;
        static QueueNode front = null;

        static void Enqueue(int data)
        {
            QueueNode node = new QueueNode();
            node.data = data;
            node.next = null;
            if(rear == null)
            {
                front = node;
                rear = node;
            }
            else
            {
                rear.next = node;
                rear = node;                            
            }
        }

        static int Dequeue()
        {
            int tmp = front.data;
            front = front.next;
            if (front == null) rear = null;
            return tmp;
        }
        //kuyruk yapımız oluştu.

        //A- kuyruğun uzunluğu.

        //1.çözüm
        static int sayac = 0;
        static int height(QueueNode front)
        {
            if (front == null) return -1;
            sayac++;
            height(front.next);
            return sayac;

        }

        //2.çözüm:
        static int adet = 0;
        static int uzunluk()
        {
            if (front == null) return 404;
            //Console.WriteLine(front.data);
            adet++;
            front = front.next;
            uzunluk();
            return adet;

        }


        //B- Kuyruğun tüm elemanlarını stağa aktarınız. Stak metotlarını  tanımlamanıza  gerek yoktur. Stağa aktardığınızda pop sırası ile Dequeue sırası aynı olmalı, stacktan elemanlar kuyruktaki sıraya göre pop edilmeli

        static Stack<int> stack = new Stack<int>();

        static void aktar()
        {
            if (front == null) Console.WriteLine("Stack boş.");
            int data = Dequeue();
            aktar();
            stack.Push(data);
        }
        //aktar metoduyla stack'a aktardığımızda pop sırasıyla Dequeue sırasını aynı yapmış olduk.



        //Örnek soru-2:
        //13-) Diziler ile kodlanan bir kuyruk yapısı için hangileri doğrudur?

        //i-İlk başta rear -1 değerine sahiptir.
        //ii-eleman sayısını bulmak için recursive metod kullanılır.
        //iii-rear ve front aynı değere sahipse kuyruk boştur.

        //Cevap : 1 ve 3
        //ii-  Yanlış eleman sayısını hesaplamak için normal bir metod yeterlidir.


        //Örnek soru-3:
        // static void Kuyruk_ekle_pointer(int data)
        // {
        //     ciftli c =new ciftli();
        //     c.data = data;
        //     c.next = null;
        //     if(....){rear_ = c; front_ = c;}
        //     else{......... rear_.next = c ; rear_ = c;}
        // }

        //Yukarıdaki kod çiftli linked list ile kuyruğa eleman ekleme işlemi yapmaktadır.
        //Noktalı yerlere sırası ile hangi kodlar gelmelidir?

        //A-) rear_.next=null
        //    c.prev = rear_.prev;

        //B-) rear_.prev == nuull
        //    c = rear_.next;

        //C-) rear_ == c
        //    c.next = rear_prev;

        //D-) rear_ == null
        //    c.prev = rear_;

        //E-) Hiçbiri

        //Cevap : D şıkkıdır.



        static void Main(string[] args)
        {
            Enqueue(1);
            Enqueue(2);
            Enqueue(3);
            Enqueue(4);
            Console.WriteLine(height(front));

            Console.WriteLine("**********");

            Console.WriteLine(uzunluk());



        }
    }
}
