using System;

namespace data_stracture_Queue
{
    class Program
    {
        //Stacklar kadar kullanım alanı fazl olmasa da önemli bir veri yapısıdır.
        //Kuyruklarla ilgili dikkat edilmesi gereken konu, kuyruğun problemin doğasına göre oluşturulmasıdır.
        //Kuyruklar stacklerin aksine FİFO(First In First Out) veya LİLO(Last İn Last Out) mantığıyla çalışırlar.
        //Kuyruğa eleman almak için Enqueue;
        //Kuyruktan eleman çıkarmak için Dequeue kullanılır. Stack'teki push ve pop metodlarına benzetilebilir.
        //Tek fark stack'te giriş ve çıkış için tek yer olduğundan tek bir pointer varken; Kuyrukta giriş ve çıkış için farklı yerler kullanıldığından 2 pointer vardır.

        //Kuyruklar aynı stack'ler gibi 2 yolla oluşturulmaktadır.
        //1- Diziler
        //2- Linked Listler

        //Dizilerle kuyturk oluşturma
        //static int[] queue = new int[100];
        //static int front = 0;
        //static int rear = -1;
        //static int elemansayisi()
        //{
        //    return rear - front + 1;
        //}
        //static void enqueue(int data)
        //{
        //    rear++;
        //    queue[rear] = data;
        //}
        //static int dequeue()
        //{
        //    int temp = queue[front];
        //    front++;
        //    return temp;
        //}

        // Genel itibari ile kuyruk yapımız bu şekilde
        //Şimdi gelelim kuyruğun birkaç sorununa;
        //Öncelikle queue dizimize 5 eleman atsak sonra bunları dequeue yapsak ardından 6 tane eleman atmaya kalktığımızda out of range hatası alırız.
        //Çünkü elimizdeki pointerları(front ve rear) hiç azaltmadık.Bunun çözümü kuyruğu dairesel hale getirmektir.

        //static void Enqueue(int data)
        //{
        //    rear++;
        //    rear = rear % 10; //Bunu yapmamızın sebebi dizideki pointer'ların sürekli dizinin sınırları içinde kalacak şekilde optimize etmek.
        //    queue[rear] = data;
        //}
        //static int Dequeue()
        //{
        //    int tmp = queue[front];
        //    front++;
        //    front = front % 10; //Burada mod alabileceğimiz gibikuyruğumuzu dinamik tutmak adına "front = front % queue.length" de yazılabilirdi.
        //    return tmp;
        //}


        //İkinci çözüm veri hareketi diye türkçeleştirebileceğimiz data movement'dır.
        //Data movement şu şekilde çalışır;

        //[1] <-rear
        //[3]
        //[5]
        //[6]
        //[7]
        //[9] <-front
        //Bu dizi ile oluşturulan bir kuyruk yapısı olsun
        //Diyelim ki iki kez dequeue yaptık yeni hali şu şekilde olur;

        //[1] <-rear
        //  [3]
        //  [5]
        //  [6]<-front
        //  [0]
        //  [0]
        //  Şimdi sıfır olan yerleri kullanabilmek için front ve rearı ve arasındaki verileri dizinin en başına alıyorum
        //  [0]
        //  [0]
        //  [1] <-rear
        //  [3]
        //  [5]
        //  [6] <-front
        //  Yani önden hizmet ettiğimiz veriyi dequeue yaptığımız eleman sayısı kadarki boşalan yeri tekrar kullanabilmek için bütün verileri başa çekiyoruz
        //Bunun kodlaması da şu şekildedir;
        //static void move()
        //{
        //    for (int i = 0; i < elemansayisi(); i++)
        //    {
        //        queue[i] = queue[front + i];
        //    }
        //    front = 0;
        //    rear = elemansayisi() - 1;
        //}
        //static void enqueue(int data)
        //{
        //    rear++;
        //    if (rear == queue.Length)
        //    {
        //        Move();
        //        rear++;
        //    }
        //    queue[rear] = data;
        //}
        //
        //Hem kuyruğun bu dez avantajını ortadan kaldıran hemde kullanımını kolaylaştıran linked listlerle kuyruk oluşturulması;
        //Bunun için önceklikle integer olan pointerlarımızın imzasını Block olarak değiştirmeliyiz yani ;

        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }

        static Block front = null;
        static Block rear = null;

        //Kuyruğa eleman ekleme
        static void enqueue(int data)
        {
            Block bl = new Block();
            bl.data = data;
            bl.next = null;
            bl.prev = null;
            if (rear == null)
            {
                front = bl;
                rear = bl;
                return;
            }
            rear.next = bl;
            bl.prev = rear;
            rear = bl;
        }

        //Kuyruktan eleman çıkarma
        static int dequeue()
        {
            Block tmp = front;
            front = front.next;
            if (front == null) //Kuyruktaki son elemanı çektiğimizde rear'ı da null yapıyoruz.
            {
                rear = null;
            }
            return tmp.data;
        }

        //Soru: [500,500]'lük dizide birler ve sıfırlar vardır. 1'lerin sağında,solunda,üstünde,altında ve çaprazlarında 1 varsa bu birler bir öbek oluşturuyor.Kuyruk ile en büyük öbeği bulunuz.

        static void Main(string[] args)
        {
            enqueue(1);
            enqueue(2);
            enqueue(3);
            enqueue(4);
            enqueue(5);
            Console.WriteLine(dequeue());
     
        }
    }
}
