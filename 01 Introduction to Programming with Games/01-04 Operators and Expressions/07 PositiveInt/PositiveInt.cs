using System;

class PositiveInt
{
    static void Main()
    {
        //Write an expression that checks if a given positive integer n<=100 is prime.
        int number = int.Parse(Console.ReadLine());

        bool solution = false;

        if ((number == 2) || (number == 3) || (number == 5) ||
            (number == 7) || (number == 9))
        {
            solution = true;
        }

        if ((number % 2 != 0) && (number % 3 != 0) && (number % 5 != 0) &&
            (number % 7 != 0) && (number % 9 != 0) && (number % 4 != 0) &&
            (number % 6 != 0))
        {
            solution = true;
        }

        Console.WriteLine($"Is the number {number} prime? {solution}!");
    }
}