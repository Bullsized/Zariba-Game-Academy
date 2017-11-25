using System;

class NandK
{
    static void Main()
    {
        //Write a program that calculates N!/K! for given N and K (1<K<N).
        long nDigit = FactorialWhileLoop(int.Parse(Console.ReadLine()));
        long kDigit = FactorialWhileLoop(int.Parse(Console.ReadLine()));
        Console.WriteLine(nDigit/kDigit);
    }

    public static long FactorialWhileLoop(int number)
    {
        long result = 1;
        while (number != 1)
        {
            result = result * number;
            number = number - 1;
        }
        return result;
    }
}