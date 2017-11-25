using System;


class ExchValues
{
    static void Main()
    {
        int firstInt = int.Parse(Console.ReadLine());
        int secondInt = int.Parse(Console.ReadLine());
        int thirdInt = 0;

        thirdInt = secondInt;
        secondInt = firstInt;
        firstInt = thirdInt;

        Console.WriteLine($"{firstInt} , {secondInt} , {thirdInt}");
        
    }
}