using System;
using System.Text;

class IdenticalLetters
{
    static void Main()
    {
        Console.Write("Input the broken string, mastah: ");
        string word = Console.ReadLine();

        char prevChar = '~';
        StringBuilder editedWord = new StringBuilder();
        foreach (char chr in word)
        {
            if (chr != prevChar)
            {
                editedWord.Append(chr);
                prevChar = chr;
            }
        }

        Console.WriteLine("Here, I fixed it: " + editedWord);
    }
}