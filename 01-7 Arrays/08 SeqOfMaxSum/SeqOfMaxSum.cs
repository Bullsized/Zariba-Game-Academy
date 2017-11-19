using System;


class SeqOfMaxSum
{
    static void Main()
    {
        Console.Write("Enter the size of the array: ");
        int n = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter {0} index: ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int bestStart = 0;
        int bestEnd = 0;
        int startIndex = 0;
        long bestSum = 0;
        long currentSum = 0;


        for (int i = 0; i < numbers.Length; i++)
        {
            if (currentSum <= 0)
            {
                startIndex = i;
                currentSum = 0;
            }

            currentSum += numbers[i];

            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestStart = startIndex;
                bestEnd = i;
            }
        }

        Console.Write("Best series: ");
        for (int i = bestStart; i <= bestEnd; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }
        Console.WriteLine("\nMaximum sum: {0}", bestSum);
    }
}