using System;

namespace data_structure_stack
{
    class Program
    {
        //static int[] stack = new int[100];
        //static int sp = -1; // sp'nin açılımı stack pointer olup -1 göstermesi linked listlerdeki blockları null'a işaret ettirmeye benzetilebilir.

        //static void push(int data)
        //{
        //    if (sp >= stack.Length) return; //Stack alanımızından fazla veri atanıp atanmaması için önlem aldık.
        //    sp++;
        //    stack[sp] = data;
        //}

        //static int pop()
        //{
        //    if (sp <= -1) return -1; // Yine stack'te olmayan verileri çekip patlatmasın diye önlem alındı.
        //    int tmp = stack[sp];
        //    sp--;
        //    return tmp;

        //}
        //Şimdi stackımız; push ve pop kumutlarımız hazır artık kullanabiliriz.



        //Linked Listlerle stack oluşturma. -Çiftli Linked Lidt yapısıyla-
        class Block
        {
            public int data;
            public Block next;
            public Block prev;
        }

        static Block sp = null; 

        static void push(int data)
        {
            Block bl = new Block();
            bl.data = data;
            bl.next = null;
            bl.prev = null;
            if (sp == null)
            {
                sp = bl;
                return;
            }
            bl.next = sp;
            sp.prev = bl;
            sp = bl;
        }
        //Yukarıdaki koddan ve linked list'in yapısından da anlayacağımız üzere veri geldikçe stack büyüyor.
        static int pop()
        {
            int tmp = sp;
            sp = sp.next;
            return tmp;
        }

        //Peek metodu stack'taki veriyi pop etmeden bakmamıza yarar. Yani stack'ten almadan görmemize yarar.
        static int peek()
        {
            return sp.data;
        }
        //Dizilerde peek metodu
        //static int peekArray()
        //{
        //    return stack[sp];
        //}

        //Stack'larda son işleyeceğimiz yer olan matematiksel işlemlerin sayıya çevrilmesidir.
        //Stackların kullanım alanlarından biri olan bu konuda bilgisayarın verilen formülleri nasıl sayıya çevirdiğini göreceğiz.

        //Mesela : a= b*c/d*(e-f)
        //Formülü verilmiş olsun bunu bildiğimiz matematiksel üstünlükler çerçevesinde yapmalıyız.
        //Yani parantez > bölme veya çarpma > toplama veya çıkarma
        //Eğer üstünlüklerine göre işlemi yapmazsak sonucu yanlış elde  ederiz.

        //Bunun için 3 terimi kullanıyoruz.
        //1- İnfix => Verilen matematiksel işlemdir.
        //2- Postfix => Verilen infix ifadede önce operandların yazıldığı sonra üstünlüğüne göre operatörlerin yazılmasıdır.
        //3- Prefix => Verilen infix ifadede önce operatörlerin yazılıp sonra operandların yazılmasıdır.

        //NOT: Prefixi postfixin tersi gibi düşünebiliriz.

        //ÖR: a*b infix ifadesini postfixe ve prefixe dönüştürünüz.
        //postfix => ab*
        //prefix => *ab

        //ÖR:a+b* c İnfix ifadesini postfixe ve prefixe dönüştürünüz.
        //Postfix => abc*+
        //Prefix =>  +*abc

        //ÖR:a-b+c infix ifadesini postfixe çevir.
        //Postfix => ab-c+

        //ÖR:a* b-c infix ifadesini postfixe çevir.
        //Postfix => ab* c-

        //ÖR:a+b* c/d-f infix ifadesini postfixe çevir.
        //Postfix => abc* d/+f-

        //ÖR:a* b-f/(g-h* j*k+m)-z infix ifadesini postfixe çevir.
        //Postfix => ab* fghj*k*-m+/-z-

        //Not: Bazı infixlerin birden fazla postfix ifadesi olabilir.
        //ÖR: a+b+c infix ifadesini postfixe çevir.
        //Postfix => abc++
        //Postfix => ab+c+
        //Örnekten de görülebileceği gibi iki postfix ifade de doğrudur.


        //Not: İnfixten postfixe çevirmeyi öğrendik şimdi postfixten infixe çevirmeye bakalım:
        //Bunun mantığı bir operatör görene kadar ifadede git ve görünce son iki operandı işleme dahil et

        //ÖR: abc* d/+f- postfix ifadesini infixe çevir.
        //1.Adım: a(b* c) d/+f-
        //2.Adım: a((b* c)/d)+f-
        //3.Adım: (a+((b* c)/d))f-
        //4.Adım: ((a+((b* c)/d))-f) //Okunacak başka operatör kalmayınca parantezleri kaldır
        //5.Adım: a+b* c/d-f


        //Şimdi kodlaması :
        //static int[] stack = new int[100];
        //static int sp = -1;
        //static void push(int data)
        //{
        //    if (sp >= stack.Length) return;
        //    sp++;
        //    stack[sp] = data;
        //}
        //static int pop()
        //{
        //    if (sp <= -1) return -1;
        //    int tmp = stack[sp];
        //    sp--;
        //    return tmp;
        //}
        //static int Peek()
        //{
        //    return stack[sp];
        //}
        //static void Main(string[] args)
        //{
        //    string infix = "a+b*c/d-e";
        //    string postfix = "";
        //    string op = "$-+/*()";
        //    int[] once = { 0, 1, 1, 2, 2 };
        //    push((byte)'$');
        //    for (int i = 0; i < infix.Length; i++)
        //    {
        //        if (op.IndexOf(infix[i]) == -1)
        //        {
        //            while (op.IndexOf(infix[i]) == -1)
        //            {
        //                postfix += infix[i++];
        //            }
        //            continue;
        //        }
        //        if (infix[i] == '(')
        //        {
        //            while (Peek() != (byte)'(')
        //            {
        //                postfix += (char)pop();
        //            }
        //            pop();
        //            continue;
        //        }
        //        int a = Peek();
        //        if (once[op.IndexOf(infix[i])] > once[op.IndexOf((char)a)])
        //        {
        //            push(infix[i]);
        //        }
        //        else
        //        {
        //            postfix += (char)pop();
        //        }
        //    }
        //    while (Peek() != (byte)'$')
        //    {
        //        postfix += (char)pop();
        //    }
        //    Console.WriteLine(postfix);




            static void Main(string[] args)
        {
            //Stack
            #region
            //Stackların bilgisayardaki kullanım alanları:
            //1- Interrupt'lar
            //2- Oyun geliştirmelerinde
            //3- Metodaların kullanımında
            // Belkide bizi en çok ilgilendiren madde olan 3. maddeyi biraz daha ayrıntılandıracak olursak,
            //Bir metodun içinde farklı bir metod çağıracak olursak
            /*
             * Static int Topla(int a,int b)// Burada basit bir metod tanımladık
              {
                   return a+b;
              }
         
              Static void Main(String[] args)
              {  
                   int a = 55;
                   int b = 44;
                   int c = Topla(a,b)//Burda da tanımladığımız metodu main metodunun içinde çağırdık.
                   Bildiğiniz üzere yukarıdan aşağı çalışan derleyici bu satıra gelince tanımlanan metodun adresine gidiyor.

                   Metodda işini bitiren derleyicinin dönüş adresine ihtiyacı var. Bunu da metoda gitmeden önce döneceği adresi stack'a atarak gideriyor.            
                   Console.WriteLine(c); 
              }
             * */

            //Gelelim stackların oluşturulmasına ve kullanımına.
            //Last In First Out veya First In Last Out(son gelen ilk çıkar, ilk giren son çıkar) prensibine dayalı bir mantıklar stackler oluşturmak için 2 yol vardır.
            //1- Diziler
            //2- Linked Listler

            //Hangi yolla oluşturulursa oluşturulsun stack'ı yönetmek için 2 komutumuz vardır.
            //1- Veri aktarmak için -> Push()
            //2Veri çekmek için -> Pop()
            //Bu iki komutu ve üzerinde işlem yapacağımız stack'ı gelin beraber tanımlayalım.

            //ÖR:
            //push(10);
            //push(20);
            //push(30);
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());
            //Console.WriteLine(pop());

            //Örnekten de anlaşılacağı gibi stack'a ilk giren 10 sayısı en son bastırılır.

            //Stack'a sadece int değerler atmak zorunda da değiliz.String karakterlerde atabiliriz
            //ÖR:

            //string st = "Merhaba";
            //for (int i = 0; i < st.Length; i++)
            //{
            //    push(st[i]);
            //}
            //while (sp != -1)
            //{
            //    Console.WriteLine((char)pop());
            //}
            //Bu örneği de çalıştırırsak stringimiz olan merhaba yazısını tersten görürüz.

            //Sorular:
            /*
             * 1- Verilern string palindromik olup olmadığını stackler yardımıyla bulunuz.
             * 2- Açık parantezi kapatma sorusunu stack yardımıyla çözünüz.(mantığı şı şekilde "{[(" şeklinde açılan parantezleri sırasıyla kapat.)
             * 3- [100.100]'lük , içinde 1-0'lar olan matriste sağ, sol, alt, üst şeklinde yan yana olan birer birer blok oluşturmaktadır. En büyüğünü bul.
             * 4- Bir stack yapısının her elemanını head olacak şekilde çiftli linked list'e bağla.
             * 5- 100 eleman bulunan stack'te 5. elemanı pop() et.
             * */

            //Çözümler:
            //1- Verilen string in palindromik olup olmadığını stacklar yardımı ile bulunuz.
            //string metin = "ey ana küçük evladına kabak eyler misin";
            //for (int i = 0; i < metin.Length; i++)
            //{
            //    push(metin[i]);
            //}
            //for (int i = 0; i < metin.Length; i++)
            //{
            //    if (metin[i] == pop()) Console.WriteLine("Palindrom.");
            //    else Console.WriteLine("Palindrom değil.");
            //}
            //Tam olarak bir çözüm olduğunu düşünmüyorum kanımca.

            //2- Açık parantezi kapatma sorunu.


            //5- 100 eleman bulunan bir stack'te 5. elemanı pop() etme.
            //int[] dizi = new int[100];
            //for (int i = 0; i < stack.Length; i++)
            //{
            //    push(i);
            //}
            //for (int i = 0; i < stack.Length; i++)
            //{
            //    dizi[i] = pop();
            //}
            //Console.WriteLine(dizi[4]);


            //Önceki başlıklarda diziler ile stack oluşturmayı görmüştük bu kısımda ise stacklari linked listleri kullanarak oluşturacağız.

            //Burada değişmeyen şey stack'in işleme mantığıdır yani last in first out olarak bildiğimiz son gelen elemanın ilk çıktığı mantıktır.
            //Stack yapımızı linked listler ile oluştururken dizilerdeki gibi;
            //1 -) Eleman ekleme(push)
            //2 -) Eleman silme(pop)
            //İşlemlerini kullancağız.            
            
        }
        #endregion
    }
}
