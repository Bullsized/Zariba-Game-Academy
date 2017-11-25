using System;
using System.Collections.Generic;

class CountNumber
{
    static void Main()
    {
        List<int> testArray = new List<int>();

        fillRandomNumbersInAnArray(testArray);

        Console.Write("Please, mastah, input which single digit you want to check how many times it's in the array: ");

        int desiredNum = int.Parse(Console.ReadLine());

        int counter = 0;

        counter = CountHowManyTimesIsTheNumInTheArray(testArray, desiredNum, counter);

        Console.WriteLine($"The desired single digit {desiredNum} is {counter} times in the array!");
    }

    public static void fillRandomNumbersInAnArray(List<int> testArray)
    {
        Random randomDigit = new Random();

        for (int i = 0; i < 100; i++)
        {
            testArray.Add(randomDigit.Next(10));
        }
    }

    public static int CountHowManyTimesIsTheNumInTheArray(List<int> testArray, int desiredNum, int counter)
    {
        for (int j = 0; j < testArray.Count; j++)
        {
            if (testArray[j] == desiredNum)
            {
                counter++;
            }
        }

        return counter;
    }
}