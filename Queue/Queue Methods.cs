using System;
using System.Collections.Generic;
using System.IO;

namespace QueueMethods
{
    class Program
    {

        #region Kuyruk Veri Yapısı
        /*
         * FİFO -> First in First Out / İlk giren İlk çıkar
         * rear -> Kuyruğun sonunu ifade eder ve eleman ekleme işlemi buradan başlar.
         * front -> Kuyruğun başını temsil eder ve eleman çıkarma işlemleri buradan başlar.
         * Enqueue -> Kuyruğa eleman eklenmesi / kuyruğun arkasından başlanır.
         * Dequeue -> Kuyruktan eleman çıkarılması / kuyruğun önünden başlanır.
         * Kuyruk doluyken eleman eklenmesi OVERFLOW hatası döndürür
         * Kuyruk boşken eleman silinmesi UNDERFLOW hatası döndürür
         */
        #endregion

        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }

        static int[] queue = new int[100];
        static int rear = -1; //kuyruğun sonunu ifade eder. Ekleme işlemi yapılır.
        static int front = 0; //kuyruğun başını ifade eder. Silme işlemi yapılır.

        static void Enqueue(int data) //kuyruğa veri ekleme
        {
            if (rear == -1) Console.WriteLine("UNDERFLOW");
            rear++;
            queue[rear] = data;
        }

        static int Dequeue() //kuyruktan veri çekme
        {
            int data = queue[front];
            front++;
            front = front % queue.Length;
            return data;
        }

        static int elemanSayisi()
        {
            return rear - front + 1;
        }


        //Linked List ile veri ekleme ve çıkarma
        static Block rearNew = null;
        static Block frontNew = null;

        static void linkedEnqueue(int data)
        {
            Block bl = new Block();
            bl.data = data;
            bl.next = null;
            bl.prev = null;

            if(rearNew == null)
            {
                rearNew = bl;
                frontNew = bl;
            }
            else
            {
                rearNew.next = bl;
                bl.prev = rearNew;
                rearNew = bl;
            }
        }

        static int linkedDequeue()
        {            
            int data = frontNew.data;
            frontNew = frontNew.next;
            if (frontNew == null) rearNew = null;
            return data;
        }



        static void Main(string[] args)
        {
            linkedEnqueue(1);
            linkedEnqueue(2);
            Console.WriteLine(linkedDequeue());




            Queue<string> q = new Queue<string>();
            q.Enqueue(@"c:\spark");
            while (q.Count > 0)
            {
                string st = q.Dequeue();
                Console.WriteLine(st);
                DirectoryInfo di = new DirectoryInfo(st);
                DirectoryInfo[] dirs = di.GetDirectories();
                foreach (DirectoryInfo item in dirs)
                {
                    q.Enqueue(item.FullName);
                }
            }
        }
    }
}
