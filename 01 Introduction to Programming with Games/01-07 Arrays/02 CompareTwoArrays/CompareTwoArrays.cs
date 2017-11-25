using System;

class CompareTwoArrays
{
    static void Main()
    {
        Console.Write("Please enter a length for the first array: ");
        int lengthFirstArray = int.Parse(Console.ReadLine());
        Console.Write("Please enter a length for the second array: ");
        int lengthSecondArray = int.Parse(Console.ReadLine());

        int[] firstArray = new int[lengthFirstArray];
        int[] secondArray = new int[lengthSecondArray];

        Console.WriteLine("Let's fill the first array!");
        for (int i = 0; i < lengthFirstArray; i++)
        {
            Console.Write("Please enter an element for index {0}: ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("And now for the second array!");

        for (int i = 0; i < lengthSecondArray; i++)
        {
            Console.Write("Please enter an element for index {0}: ", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < Math.Min(lengthFirstArray, lengthSecondArray); i++)
        {
            if (firstArray[i] > secondArray[i])
            {
                Console.WriteLine("{0} is bigger than {1}! First array wins!", firstArray[i], secondArray[i]);
            }
            else if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("{0} is bigger than {1}! Second array wins!", secondArray[i], firstArray[i]);
            }
            else
            {
                Console.WriteLine("{0} equals {1}! Whoah!", firstArray[i], secondArray[i]);
            }
        }
    }
}