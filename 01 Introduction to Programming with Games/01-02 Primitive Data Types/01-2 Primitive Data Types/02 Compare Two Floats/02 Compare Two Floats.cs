using System;

class CompareTwoDec
{
    static void Main()
    {
        decimal firstFloat = decimal.Parse(Console.ReadLine());
        decimal secondFloat = decimal.Parse(Console.ReadLine());

        if (Math.Abs(firstFloat - secondFloat) == 0.00001m)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}