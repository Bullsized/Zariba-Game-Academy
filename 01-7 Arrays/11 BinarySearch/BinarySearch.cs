using System;

class BinarySearch
{
    static void Main()
    {       
        int n = int.Parse(Console.ReadLine());

        int searchedNumber = int.Parse(Console.ReadLine());

        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(numbers);

        int index = Array.BinarySearch(numbers, searchedNumber);

        Console.WriteLine(index);
    }
}