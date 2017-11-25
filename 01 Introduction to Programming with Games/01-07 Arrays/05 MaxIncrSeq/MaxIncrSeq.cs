using System;
using System.Linq;

class MaxIncrSeq
{
    static void Main()
    {
        int[] listOfDigits = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int start = 0;
        int workingLength = 1;

        int bestPosition = 0;
        int bestLength = 1;

        for (int i = 1; i < listOfDigits.Length; i++)
        {
            if (listOfDigits[i] > listOfDigits[i - 1])
            {
                workingLength++;
                if (workingLength > bestLength)
                {
                    bestLength = workingLength;
                    bestPosition = start;
                }
            }
            else
            {
                if (workingLength > bestLength)
                {
                    bestPosition = start;
                    bestLength = workingLength;
                }
                start = i;
                workingLength = 1;
            }
        }

        for (int i = bestPosition; i < bestPosition + bestLength; i++)
        {
            Console.Write(listOfDigits[i] + " ");
        }
        Console.WriteLine();
    }
}