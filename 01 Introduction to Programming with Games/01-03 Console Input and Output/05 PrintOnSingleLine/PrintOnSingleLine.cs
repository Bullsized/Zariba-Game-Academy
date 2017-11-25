using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrintOnSingleLine
{
    static void Main()
    {
        //Write a program that reads an integer number n from the console and prints all the 
        //numbers in the interval[1..n], each on a single line.

        int numberN = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numberN; i++)
        {
            if (i == numberN)
            {
                Console.Write(i);
                break;
            }
            Console.Write(i + ", ");
        }
        Console.WriteLine();
    }
}