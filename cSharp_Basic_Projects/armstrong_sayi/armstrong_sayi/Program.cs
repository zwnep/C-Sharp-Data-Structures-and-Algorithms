using System;

namespace armstrong_sayi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("sayı girin: ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            int toplam = 0;
            int gecici = sayi;
            int basamakDeğeri = 0;

            while (gecici > 0)
            {
                basamakDeğeri = gecici % 10;
                toplam = basamakDeğeri + toplam;
                gecici = gecici / 10;
            }

            if (sayi == toplam) Console.WriteLine("girilen sayının basamak sayılarını toplamı kendisine eşittir.");

            else Console.WriteLine("sayı armstrong değildir.");
        }
    }
}
