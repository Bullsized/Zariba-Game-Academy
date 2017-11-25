using System;

class SortThreeInts
{
    static void Main()
    {
        //Sort 3 integer numbers using if statements.
        int a = int.Parse(Console.ReadLine());

        int b = int.Parse(Console.ReadLine());

        int c = int.Parse(Console.ReadLine());

        if (a > b)
        {
            if (a > c)
            {
                if (b > c)
                {
                    Console.WriteLine("{0} {1} {2}", c, b, a);
                }
                else
                {
                    Console.WriteLine("{0} {1} {2}", b, c, a);
                }
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", b, a, c);
            }
        }
        else if (b > c)
        {
            if (a > c)
            {
                Console.WriteLine("{0} {1} {2}", c, a, b);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", a, c, b);
            }
        }
        else
        {
            Console.WriteLine("{0} {1} {2}", a, b, c);
        }
    }
}