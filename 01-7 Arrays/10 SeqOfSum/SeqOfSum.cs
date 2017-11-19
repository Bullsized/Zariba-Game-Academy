using System;
using System.Collections.Generic;
using System.Linq;

class SeqOfSum
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int searchedSum = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            bool isFoundSequence = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                List<int> sequence = new List<int>();

                for (int j = i; j < numbers.Length; j++)
                {
                    sequence.Add(numbers[j]);

                    if (sequence.Sum() == searchedSum)
                    {
                        isFoundSequence = true;
                        Console.WriteLine(string.Join(" ", sequence));
                    }
                }
            }

            Console.Write(!isFoundSequence ? "- There are no sequences with sum " + searchedSum + "\n" : "");
        }
    }