using System;

namespace basamak_adedi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Girilen pozitif sayının kaç basamklı olduğunu bulma
            #region çözüm1
            Console.Write("Sayı: ");
            int sayi = Convert.ToInt16(Console.ReadLine());

            int basamak = 0;

            while (sayi > 0)
            {
                basamak++;
                sayi = sayi / 10;
            }

            Console.WriteLine(basamak);
            #endregion
            
            #region çözüm2
            Console.WriteLine(basamakHesaplama(1202));


        }

        static int basamakHesaplama(int sayi)
        {
            if (sayi > 1) return 1 + basamakHesaplama(sayi / 10);
            return 1;
        }
        #endregion
    }
}