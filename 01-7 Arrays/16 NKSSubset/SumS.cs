using System;
using System.Collections.Generic;
using System.Linq;

class SumS
{
    static bool isFoundSubset = false;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int sum = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        PrintAllSubsetsWithGivenSum(numbers, sum);
    }

    static void PrintAllSubsetsWithGivenSum(int[] numbers, int searchedSum)
    {
        Console.WriteLine("All subsets with sum = {0}", searchedSum);

        int subsetsCount = (int)(Math.Pow(2, numbers.Length) - 1);

        List<int> subset = new List<int>();

        for (int i = 1; i <= subsetsCount; i++)
        {
            subset.Clear();

            for (int j = 0; j < numbers.Length; j++)
            {
                if (((i >> j) & 1) == 1)
                {
                    subset.Add(numbers[j]);
                }
            }

            if (subset.Sum() == searchedSum)
            {
                isFoundSubset = true;
                Console.WriteLine(string.Join(" ", subset));
            }
        }

        Console.WriteLine(!isFoundSubset ? "- There are no subsets with Sum " + searchedSum + "\n" : "");
    }
}