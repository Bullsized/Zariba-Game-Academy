using System;
using System.Collections.Generic;
using System.Linq;

class BinSearch
{
    static void Main()
    {
        Console.WriteLine("Enter ze numbahs: ");
        List<int> numbers = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .OrderBy(num => num)
                            .ToList();

        Console.Write("Enter ze numbah K: ");
        int maxNum = int.Parse(Console.ReadLine());

        NumberComparer comparer = new NumberComparer();

        int index = numbers.BinarySearch(maxNum, comparer);

        if (index >= 0)
        {
            Console.WriteLine(numbers[index]);
        }
        else
        {
            index = Math.Abs(index) - 2;

            if (index >= 0)
            {
                Console.WriteLine(numbers[index]);
            }
            else
            {
                Console.WriteLine("No numbers less than/equal to {0} were found!", maxNum);
            }
        }
    }

    class NumberComparer : IComparer<int> 
    {
        public int Compare(int firstDigit, int secondDigit)
        {
            return firstDigit.CompareTo(secondDigit);
        }
    }
}