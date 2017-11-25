using System;

class Program
{
    static void Main()
    {
        //Write a program that reads a number N and calculates the sum of the first N 
        //members of the sequence of Fibonacci
        
        int n = int.Parse(Console.ReadLine());

        long firstDigit = 0;
        long secondDigit = 1;
        long thirdDigit = 0;
        long totalSum = 0;

        for (int i = 0; i < n - 1; i++)
        {
            firstDigit = secondDigit;
            secondDigit = thirdDigit;
            thirdDigit = firstDigit + secondDigit;
            totalSum = totalSum + thirdDigit;
        }

        Console.WriteLine($"The sum of the first {n} numbers of the Fibonacci's sequence is {totalSum}!");
    }
}