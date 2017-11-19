using System;

class AllAlphaLetters
{
    static void Main()
    {
        char[] alphabet = new char[26];
        int zeroCounter = 0;
        for (int i = 97; i <= 122; i++)
        {
            alphabet[zeroCounter] = (char)i;
            zeroCounter++;
        }

        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = 0; j < alphabet.Length; j++)
            {
                if (word[i] == alphabet[j])
                {
                    Console.Write(j + " ");
                }
            }
        }
        Console.WriteLine();
    }
}
