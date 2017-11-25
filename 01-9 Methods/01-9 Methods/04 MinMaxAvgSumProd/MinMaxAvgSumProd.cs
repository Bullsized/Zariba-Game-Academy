using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class MinMaxAvgSumProd
{
    static void Main()
    {
        List<int> testArray = new List<int>();

        Random randomDigit = new Random();

        for (int i = 0; i < 15; i++)
        {
            testArray.Add(randomDigit.Next(101));
        }

        GetTheMinimumNumber(testArray);
        GetTheMaximumNumber(testArray);
        GetTheAverageAndSumNumber(testArray);
        GetTheProduct(testArray);
    }

    public static void GetTheProduct(List<int> testArray)
    {
        BigInteger product = 1;
        for (int i = 0; i < testArray.Count(); i++)
        {
            product *= testArray[i];
        }
        Console.WriteLine("The product of all the integers in the array is: " + product);
    }

    public static void GetTheAverageAndSumNumber(List<int> testArray)
    {
        int sum = 0;
        for (int i = 0; i < testArray.Count(); i++)
        {
            sum += testArray[i];
        }
        Console.WriteLine("The sum of all the integers in the array is: " + sum);
        Console.WriteLine("The average number of all the integers in the array is: " + (sum / testArray.Count()));
    }

    public static void GetTheMinimumNumber(List<int> testArray)
    {
        int minNumber = int.MaxValue;

        for (int i = 0; i < testArray.Count(); i++)
        {
            if (minNumber > testArray[i])
            {
                minNumber = testArray[i];
            }
        }

        Console.WriteLine("The smallerst integer in the array is: " + minNumber);
    }

    public static void GetTheMaximumNumber(List<int> testArray)
    {
        int maxNumber = int.MinValue;

        for (int i = 0; i < testArray.Count(); i++)
        {
            if (maxNumber < testArray[i])
            {
                maxNumber = testArray[i];
            }
        }

        Console.WriteLine("The largest integer in the array is: " + maxNumber);
    }

    //everything can be done in just one method, with one for cycle, mdaaaam:
    //BigInteger product = 1;
    //int sum = 0;
    //int minNumber = int.MaxValue;
    //int maxNumber = int.MinValue;

    //for (int i = 0; i < testArray.Count(); i++)
    //{
    //    product *= testArray[i];

    //    sum += testArray[i];

    //    if (minNumber > testArray[i])
    //    {
    //        minNumber = testArray[i];
    //    }

    //    if (maxNumber < testArray[i])
    //    {
    //        maxNumber = testArray[i];
    //    }
    //}
    //Console.WriteLine("The smallerst integer in the array is: " + minNumber);
    //Console.WriteLine("The largest integer in the array is: " + maxNumber);
    //Console.WriteLine("The average number of all the integers in the array is: " + (sum / testArray.Count()));
    //Console.WriteLine("The sum of all the integers in the array is: " + sum);
    //Console.WriteLine("The product of all the integers in the array is: " + product);

    //and still more - linq can do everything in few rows, .Min, .Max, .Average, etc... o daa
}