using System;

class SortingAnArray
{
    static void Main()
    {
        int[] testArray = { 5, 3, 7, 2, 9, 15 };
        int n = testArray.Length;

        for (int x = 0; x < n; x++)
        {
            int minIndex = x;

            for (int y = x; y < n; y++)
            {
                if (testArray[minIndex] > testArray[y])
                {
                    minIndex = y;
                }
            }
            int temp = testArray[x];
            testArray[x] = testArray[minIndex];
            testArray[minIndex] = temp;
        }

        foreach (int i in testArray)
        {
            Console.Write(i + ", ");
        }
    }
}