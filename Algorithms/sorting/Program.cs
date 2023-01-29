using System;

namespace sorting
{
    class Program
    {
        //Sorting, bir eleman dizisini, belirli sıralama kurallarına göre sıralama yapar.

        static void Main(string[] args)
        {
            //Proje 1
            //[22,27,16,2,18,6] -> Insertion Sort

            //Yukarı verilen dizinin sort türüne göre aşamalarını yazınız.

            //Big - O gösterimini yazınız.

            //Time Complexity: Dizi sıralandıktan sonra 18 sayısı aşağıdaki case'lerden hangisinin kapsamına girer? Yazınız

            //Average case: Aradığımız sayının ortada olması
            //Worst case: Aradığımız sayının sonda olması
            //Best case: Aradığımız sayının dizinin en başında olması.


            //[7,3,5,8,2,9,4,15,6] dizisinin Selection Sort'a göre ilk 4 adımını yazınız.


            //ÇÖZÜMLER

            //[16,22,27,2,18,6]
            //[2,16,22,27,18,6]
            //[2,16,18,22,27,6]
            //[2,6,16,18,22,27]


            //Big - O: n^2

            //18 sayısı, dizi sıralandıktan sonra dizinin ortasındadır. Bu yüzden Avarage Case kapsamına girer.

            //[7,3,5,8,2,9,4,15,6]
            //[2,3,5,8,7,9,4,15,6]
            //[2,3,4,8,7,9,5,15,6]
            //[2,3,4,5,7,9,8,15,6]
            //[2,3,4,5,6,9,8,15,7]




        }
    }
}
