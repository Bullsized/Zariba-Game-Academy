using System;

class TwoPositiveInts
{
    static void Main()
    {
        //Write a program that reads two positive integer numbers and prints how many numbers p exist
        //between them such that the reminder of the division with p by 5 is 0(inclusive).Example: p(17, 25) = 2

        uint firstInt = uint.Parse(Console.ReadLine());
        uint secondInt = uint.Parse(Console.ReadLine());
        int counter = 0;
        for (uint i = firstInt; i <= secondInt; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}