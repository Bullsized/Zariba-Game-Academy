using System;

class GetNumberN
{
    static void Main()
    {
        //Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 
        int numberN = int.Parse(Console.ReadLine());
        long sum = numberN;
        for (int i = 0; i < numberN; i++)
        {
            sum += i;
        }
        Console.WriteLine(sum);
    }
}