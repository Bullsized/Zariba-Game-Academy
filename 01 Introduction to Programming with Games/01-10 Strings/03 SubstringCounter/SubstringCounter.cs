using System;
using System.Linq;

class SubstringCounter
{
    static void Main()
    {
        Console.Write("Give us tha text, precious: ");
        string[] text = Console.ReadLine().ToLower().Split(new char[] { ' ', ',', '!', }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        Console.Write("Give us tha word, precious: ");
        string word = Console.ReadLine();

        int counter = 0;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == word)
            {
                counter++;
            }
        }

        Console.WriteLine($"The word {word} contains {counter} times in the text!");
    }
}