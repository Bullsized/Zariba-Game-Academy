using System;

class Program
{
    static void Main()
    {
        //Write a boolean expression that checks if an integer can be divided by 2, 3 and 5
        //without remainder(use logical operators).

        int number = 30;
        bool canBeDivided = number % 2 == 0 && number % 3 == 0 && number % 5 == 0;
        Console.WriteLine(canBeDivided);
    }
}