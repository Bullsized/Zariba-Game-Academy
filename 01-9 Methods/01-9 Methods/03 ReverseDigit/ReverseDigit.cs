using System;

class ReverseDigit
{
    static void Main()
    {
        Console.Write("Please, mastah, input the number you want reversed: ");
        char[] originalDigit = Console.ReadLine().ToCharArray();

        ReverseMethod(originalDigit);
    }

    public static void ReverseMethod(char[] originalDigit)
    {
        Array.Reverse(originalDigit);
        Console.WriteLine("And here'z your reversed num, mastah: " + string.Join("", originalDigit));
    }
}