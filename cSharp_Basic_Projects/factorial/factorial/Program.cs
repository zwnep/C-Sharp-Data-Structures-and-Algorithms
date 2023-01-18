using System;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculates the factorial of the entered number
            #region solution1
            Console.WriteLine("Enter the number: ");
            int num = Convert.ToInt16(Console.ReadLine());
            int fNum = 1;
            for (int i = num; i > 0; i--)
            {
                fNum = fNum * i;
            }
            Console.WriteLine("Result: " + fNum);
            #endregion

            #region solution2
            Console.WriteLine(factorial(6));
            #endregion

        }

        static int factorial(int number)
        {
            if (number == 1) return 1;
            return number * factorial(number - 1);
        }

    }
}
