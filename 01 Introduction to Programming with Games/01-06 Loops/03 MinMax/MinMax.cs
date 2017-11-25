using System;
using System.Collections.Generic;
using System.Linq;

class MinMax
{
    static void Main()
    {
        //Write a program that reads from the console a sequence of N integer numbers and returns 
        //the minimal and maximal of them.
        List<int> sequenceOfInts = new List<int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            sequenceOfInts.Add(i);
        }
        Console.WriteLine(sequenceOfInts.Min() + Environment.NewLine + sequenceOfInts.Max());
    }
}