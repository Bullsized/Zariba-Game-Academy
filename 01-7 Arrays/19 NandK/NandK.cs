using System;

class NandK
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {

            for (int j = 1; j <= k; j++)
            {
                Console.Write("{" + i + ", " + j + "}, ");

            }
        }
    }
}