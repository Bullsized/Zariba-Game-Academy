using System;

class BiggerFromTwoNums
{
    static void Main()
    {
        //Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());
        Console.WriteLine(Math.Max(firstNum, secondNum));
    }
}