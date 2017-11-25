using System;
using System.Collections.Generic;
using System.Linq;

class AnyNumType
{
    static void Main()
    {
        //ctrl + h, just replace "decimal" with float, double, etc.
        List<decimal> testArray = new List<decimal>();

        FillTheArray(testArray);

        decimal product = 1;
        decimal sum = 0;
        decimal minNumber = decimal.MaxValue;
        decimal maxNumber = decimal.MinValue;

        MakeTheTests(testArray, ref product, ref sum, ref minNumber, ref maxNumber);

        PrintTheResults(testArray, product, sum, minNumber, maxNumber);
    }

    public static void PrintTheResults(List<decimal> testArray, decimal product, decimal sum, decimal minNumber, decimal maxNumber)
    {
        Console.WriteLine("The smallerst integer in the array is: " + minNumber);
        Console.WriteLine("The largest integer in the array is: " + maxNumber);
        Console.WriteLine("The average number of all the integers in the array is: " + (sum / testArray.Count()));
        Console.WriteLine("The sum of all the integers in the array is: " + sum);
        Console.WriteLine("The product of all the integers in the array is: " + product);
    }

    public static void MakeTheTests(List<decimal> testArray, ref decimal product, ref decimal sum, ref decimal minNumber, ref decimal maxNumber)
    {
        for (int i = 0; i < testArray.Count(); i++)
        {
            product *= testArray[i];

            sum += testArray[i];

            if (minNumber > testArray[i])
            {
                minNumber = testArray[i];
            }

            if (maxNumber < testArray[i])
            {
                maxNumber = testArray[i];
            }
        }
    }

    public static void FillTheArray(List<decimal> testArray)
    {
        Random randomDigit = new Random();

        for (int i = 0; i < 15; i++)
        {
            testArray.Add(randomDigit.Next(101));
        }
    }
}