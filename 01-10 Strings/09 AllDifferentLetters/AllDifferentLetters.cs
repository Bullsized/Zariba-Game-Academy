using System;
using System.Collections.Generic;
using System.Linq;

class AllDifferentLetters
{
    static void Main()
    {
        string[] words = Console.ReadLine().Split();

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (!dictionary.ContainsKey(words[i]))
            {
                dictionary.Add(words[i], 1);
            }
            else
            {
                dictionary[words[i]]++;
            }
        }

        foreach (var kvp in dictionary.OrderByDescending(k => k.Value))
        {
            Console.WriteLine($"The word {kvp.Key} is contained {kvp.Value} times in the string ~");
        }
    }
}