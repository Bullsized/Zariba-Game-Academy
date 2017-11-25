using System;

class TwentyInts
{
    static void Main()
    {
        int[] twentyIntsArray = new int[20];
        for (int i = 0; i < twentyIntsArray.Length; i++)
        {
            twentyIntsArray[i] = i * 5;
        }

        Console.WriteLine(string.Join(", ", twentyIntsArray));
    }
}