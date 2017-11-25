using System;


class Program
{
    static void Main()
    {
        string[] inputText = Console.ReadLine().Split();
        Array.Reverse(inputText);
        Console.WriteLine(string.Join(" ", inputText));
    }
}