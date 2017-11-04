using System;

class OddOrEven
{
    static void Main()
    {
        //1. Write an expression that checks if given integer is odd or even.
        int number = 77;
        bool even = number % 2 == 0 ? true : false;
        Console.WriteLine("Is {0} even? {1}!", number, even);
    }
}