using System;
using System.Numerics;

class RectMatrix
{
    public static void Main()
    {
        Console.Write("Input rows of the rectangle, mastah: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Input columns of the rectangle, mastah: ");
        int m = int.Parse(Console.ReadLine());

        int[,] theMatrix = new int[n, m];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("The's matrix elements [{0}, {1}] are: ", row, col);
                theMatrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        BigInteger biggestSum = int.MinValue;

        int[] resultStartIndex = new int[2];

        for (int i = 0; i < theMatrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < theMatrix.GetLength(1) - 2; j++)
            {
                BigInteger testSum =    theMatrix[i, j] + theMatrix[i, j + 1] + theMatrix[i, j + 2] +
                                        theMatrix[i + 1, j] + theMatrix[i + 1, j + 1] + theMatrix[i + 1, j + 2] +
                                        theMatrix[i + 2, j] + theMatrix[i + 2, j + 1] + theMatrix[i + 2,j + 2];

                if (testSum > biggestSum)
                {
                    biggestSum = testSum;
                    resultStartIndex[0] = i;
                    resultStartIndex[1] = j;
                }
            }
        }

        Console.WriteLine($"Sum = {biggestSum}");

        Console.WriteLine("Zee 3x3 numbahs are:");
        for (int i = resultStartIndex[0]; i < resultStartIndex[0] + 3; i++)
        {
            for (int j = resultStartIndex[1]; j < resultStartIndex[1] + 3; j++)
            {
                Console.Write(theMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}