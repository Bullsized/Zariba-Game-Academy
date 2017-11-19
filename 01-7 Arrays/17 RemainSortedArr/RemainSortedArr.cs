using System;

class RemainSortedArr
{
    static int[] output;

    static int maxLength;

    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for (int index = 0; index < n; index++)
        {
            Console.Write("Enter element {0}: ", index);
            arr[index] = int.Parse(Console.ReadLine());
        }
        output = new int[n];
        int[] subset = new int[n];
        for (int elementsInSubset = 1; elementsInSubset <= n; elementsInSubset++)
        {
            GenerateSubset(arr, subset, 0, 0, elementsInSubset);
        }

        for (int i = 0; i <= maxLength; i++)
        {
            Console.WriteLine("{0} ", output[i]);
        }
    }

    static void GenerateSubset(int[] arr, int[] subset, int index, int current, int elementsInSubset)
    {
        if (index == elementsInSubset)
        {
            CheckSubsets(subset, elementsInSubset);
            return;
        }

        for (int i = current; i < arr.Length; i++)
        {
            subset[index] = arr[i];
            GenerateSubset(arr, subset, index + 1, i + 1, elementsInSubset);
        }
    }

    static void CheckSubsets(int[] subset, int elementsInSubset)
    {
        for (int i = 1; i < elementsInSubset; i++)
        {
            if (subset[i] < subset[i - 1])
            {
                return;
            }
            if (i > maxLength)
            {
                maxLength = i;
                for (int j = 0; j <= maxLength; j++)
                {
                    output[j] = subset[j];
                }
            }
        }
    }
}