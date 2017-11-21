using System;
using System.Linq;

class PrintMatrices
{
    static void Main()
    {
        Console.Write("How many rows and columns do you want, mastah: ");
        int n = int.Parse(Console.ReadLine());

        int[,] theMatrix = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("The's matrix elements [{0}, {1}] are: ", row, col);
                theMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("Here's the matrix you've input, mastah:");
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                Console.Write("{0} ", theMatrix[row, col]);
            }
            Console.WriteLine();
        }


        /* if the input was on a single row:
        int[] currentRow = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        in the second for loop:
        theMatrix[row, col] = currentRow[col]; */

    }
}