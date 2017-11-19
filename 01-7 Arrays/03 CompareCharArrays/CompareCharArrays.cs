using System;

class CompareCharArrays
{
    static void Main()
    {
        char[] firstArray = { 'a', 'b', 'c', 'z', 'd'};
        char[] secondArray = { 'a', 'b', 'c', 'd', 'z'};

        for (int i = 0; i < firstArray.Length; i++)
        {
            if (firstArray[i] < secondArray[i])
            {
                Console.WriteLine("1st char is earlier");
            }
            else if (firstArray[i] == secondArray[i])
            {
                Console.WriteLine("The two chars are equal");
            }
            else
            {
                Console.WriteLine("2nd char is earlier");
            }
        }
    }
}