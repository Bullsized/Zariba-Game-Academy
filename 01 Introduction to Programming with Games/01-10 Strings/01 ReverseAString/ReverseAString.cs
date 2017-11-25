using System;

class ReverseAString
{
    static void Main()
    {
        Console.Write("Please input which word you want reversed, mastah: ");
        string toBeReversed = Console.ReadLine();

        char[] letsReverse = toBeReversed.ToCharArray();

        int length = letsReverse.Length;

        char[] reversedString = new char[length];

        int zeroIncreaser = 0;

        for (int i = length - 1; i >= 0; i--)
        {
            reversedString[zeroIncreaser] = letsReverse[i];
            zeroIncreaser++;
        }

        Console.WriteLine("And here it is: " + string.Join("", reversedString));
    }
}