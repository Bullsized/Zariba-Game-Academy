using System;
using System.Collections.Generic;

class Palindromes
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split(new char[] { ' ', '.' });
        List<string> palindromes = new List<string>();

        for (int i = 0; i < text.Length; i++)
        {
            string[] words = text[i].Split();
            for (int j = 0; j < words.Length; j++)
            {
                bool isPalindrome = false;
                char[] locka = words[j].ToCharArray();
                for (int chars = 0; chars < locka.Length / 2; chars++)
                {
                    if (locka[chars] == locka[locka.Length - 1 - chars])
                    {
                        isPalindrome = true;
                    }
                    else
                    {
                        break;
                    }
                }

                if (isPalindrome)
                {
                    palindromes.Add(words[j]);
                }
            }

        }

        Console.WriteLine(string.Join(" ", palindromes));
    }
}