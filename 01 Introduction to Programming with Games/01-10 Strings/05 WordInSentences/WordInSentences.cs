using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split('.');

        string word = Console.ReadLine();

        List<string> containedSentencences = new List<string>();

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i].Contains(word))
            {
                containedSentencences.Add(text[i]);
            }
        }

        Console.WriteLine(string.Join(" ->", containedSentencences));
    }
}