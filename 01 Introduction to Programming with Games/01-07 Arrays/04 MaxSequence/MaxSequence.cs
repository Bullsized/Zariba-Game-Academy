using System;
using System.Linq;

class MaxSequence
{
    static void Main()
    {
        int[] listOfDigits = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int bestStart = 0;
        int bestLength = 0;
        int start = listOfDigits[0];
        int workingLength = 1;

        for (int cycle = 1; cycle <= listOfDigits.Length - 1; cycle++)
        {
            if (start == listOfDigits[cycle])
            {
                workingLength++;
                if (workingLength > bestLength)
                {
                    bestStart = listOfDigits[cycle];
                    bestLength = workingLength;
                }
            }
            else
            {
                start = listOfDigits[cycle];
                workingLength = 1;
            }
        }

        while (bestLength > 0)
        {
            Console.Write(bestStart + " ");
            bestLength--;
        }
        Console.WriteLine();
    }
}