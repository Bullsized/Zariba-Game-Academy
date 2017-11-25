using System;

class Matrix
{
    static void Main()
    {
        /* Write a program that reads from the console a positive integer number N (N < 20) and 
        outputs a matrix like the following:
	    n = 3                           n = 4
       1  2  3                        1  2  3  4
       2  3  4                        2  3  4  5
       3  4  5                        3  4  5  6
                                      4  5  6  7
       */
        byte rotation = byte.Parse(Console.ReadLine());
        if (rotation >= 20)
        {
            throw new ArgumentException("ooo kolko si pros i ima li smisal~");
        }

        for (int i = 0; i < rotation; i++)
        {
            for (int k = 1 + i; k <= rotation + i; k++)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
        }
    }
}