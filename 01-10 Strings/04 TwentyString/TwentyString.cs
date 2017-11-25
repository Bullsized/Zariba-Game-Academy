using System;
using System.Text;

class TwentyString
{
    static void Main()
    {
    Start:
        StringBuilder input = new StringBuilder(Console.ReadLine());

        int length = input.Length;

        if (length == 20)
        {
            Console.WriteLine(input);
        }
        else if (length < 20)
        {
            int differenceToTwenty = 20 - length;

            input.Append('*', differenceToTwenty);

            Console.WriteLine(input);
        }
        else
        {
            Console.WriteLine("Try again, bruv!");
            goto Start;
        }
    }
}