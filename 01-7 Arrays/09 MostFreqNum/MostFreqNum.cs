using System;
using System.Linq;

class MostFreqNum
{
    static void Main()
    {
        int[] numbers = new int[] { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
                        //Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int counter = 0;
        int longestOccurance = 0;
        int mostFrequentNumber = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            counter = 0;

            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == numbers[i])
                {
                    counter++;
                }
            }

            if (counter > longestOccurance)
            {
                longestOccurance = counter;
                mostFrequentNumber = numbers[i];
            }
        }

        Console.WriteLine(mostFrequentNumber);
    }
}