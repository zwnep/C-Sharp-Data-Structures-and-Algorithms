using System;

namespace multiplying_by_plus
{
    class Program
    {
        static void Main(string[] args)
        {
            //find positive numbers by multiplying using addition


            Console.Write("Enter the number to sum: ");
            int number = Convert.ToInt16(Console.ReadLine());
            Console.Write("Enter the number of repetitions: ");
            int repNum = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine(multiplyFunction(number, repNum));

            static int multiplyFunction(int num1, int repNum)
            {
                if (repNum > 1) return num1 + multiplyFunction(num1,--repNum);
                return num1;
            }
        }
    }
}
