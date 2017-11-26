using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Hangman
{
    static void Main(string[] args)
    {
        //console size
        Console.BufferWidth = Console.WindowWidth = 40;
        Console.BufferHeight = Console.WindowHeight = 20;

        int lives = 6;

        //parse the file with all the words (file is in "\bin\Debug")
        string[] dictionaryWithWords = File.ReadAllLines("wordsEn.txt");

        //find a word with more than 4 letters
        Random rnd = new Random();

        string wordToGuess = string.Empty;

        while (wordToGuess.Length < 4)
        {
            wordToGuess = dictionaryWithWords[rnd.Next(dictionaryWithWords.Length)].ToLower();
        }

        //fill a char array with all the alphabet letters
        char[] alphabetArray = new char[26]; //it's not a magic number, it's the alphabet count number, duh
        int startToEndAlphabet = 0;

        for (char i = 'a'; i < '{'; i++)
        {
            alphabetArray[startToEndAlphabet] = i;
            startToEndAlphabet++;
        }

        //an array for all the guessed letters like this: "_ _ _ _ " where the dashes are the guessed chars
        List<char> guessedLetters = new List<char>();

        //an array for all the wrong letters
        List<char> wrongLetters = new List<char>();

        //draw lines for the letters of the current word
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters.Add('_');
            guessedLetters.Add(' ');
        }

        //one big loop to unite everything and check if the game is over
        while (true)
        {

            PrintHangmanWordAndLives(lives, guessedLetters);

            //parse a char
            bool isTheLetterCorrect = false;
            char currentLetter = '~'; //must be assigned so that it can be read out of the while loop

            while (!isTheLetterCorrect)
            {
                Console.Write("Give us your choice of letter, mastah: ");

                string currentParse = Console.ReadLine().ToLower(); //decided to go with even capital letters input

                //check if it's length is 1
                if (currentParse.Length > 1)
                {
                    Console.Clear();
                    Console.WriteLine("Give us a single letter, mastah!");
                    continue;
                }

                currentLetter = currentParse[0];

                //check if it's in the array
                if (!alphabetArray.Contains(currentLetter))
                {
                    Console.Clear();
                    Console.WriteLine("Give us a propah letter, mastah!: ");
                    continue;
                }

                if (guessedLetters.Contains(currentLetter))
                {
                    Console.Clear();
                    Console.WriteLine("You've already guessed that letter,     mastah! Please enter a new letter: ");
                    continue;
                }

                if (wrongLetters.Contains(currentLetter))
                {
                    Console.Clear();
                    Console.WriteLine("You tried that word and it didn't work, mastah! Please enter a new letter: ");
                    continue;
                }

                isTheLetterCorrect = true;
            }

            //check if the current letter is contained in the word to guess
            bool itsInTheWord = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (wordToGuess[i] == currentLetter)
                {
                    itsInTheWord = true;
                    guessedLetters[i * 2] = currentLetter; //multiplied by two because of the empty space for the string join
                    Console.Clear();
                    PrintHangmanWordAndLives(lives, guessedLetters);
                }

            }

            if (!itsInTheWord) //lowering the lives count
            {
                lives--;
                wrongLetters.Add(currentLetter);
            }

            //conditions to win/lose
            if (lives == 0) //game over, no lives
            {
                WriteAt("GAME OVAH, MASTAH", 12, 16);
                break;
            }

            if (!guessedLetters.Contains('_')) //no more letters to guess
            {
                WriteAt("HIP HOP ARRAY! YOU WON, MASTAH!!!", 4, 16);
                break;
            }

            Console.Clear();
        }

        //draw a frame?

    }

    private static void PrintHangmanWordAndLives(int lives, List<char> guessedLetters)
    {
        //two methods to draw the hangman dude
        DrawTheBody(lives);

        WriteAt(string.Join("", guessedLetters), 12, 11);

        //display the lives on screen
        WriteAt("Lives: " + lives.ToString(), 17, 13);
    }

    private static void DrawTheBody(int lives)
    {
        //draw the body
        //       ________
        //       |      |                Draw until this one < maybe with an array would've been better?
        //       |      O                < 6
        //       |     /|\				< 4 5 3
        //       |     / \				< 2 1
        //   ____|____________
        //  /    |           /|
        // /_______________ / |
        // |               | /
        // |_______________|/

        WriteAt("       ________", 10, 1);
        WriteAt("       |      |", 10, 2);

        switch (lives)
        {
            case 6:
                WriteAt("       |      ", 10, 3);
                WriteAt("       |     ", 10, 4);
                WriteAt("       |     ", 10, 5); break;
            case 5:
                WriteAt("       |      O", 10, 3);
                WriteAt("       |     ", 10, 4);
                WriteAt("       |     ", 10, 5); break;
            case 4:
                WriteAt("       |      O", 10, 3);
                WriteAt("       |      |", 10, 4);
                WriteAt("       |     ", 10, 5); break;
            case 3:
                WriteAt("       |      O", 10, 3);
                WriteAt("       |     /|", 10, 4);
                WriteAt("       |     ", 10, 5); break;
            case 2:
                WriteAt("       |      O", 10, 3);
                WriteAt("       |     /|\\", 10, 4);
                WriteAt("       |     ", 10, 5); break;
            case 1:
                WriteAt("       |      O", 10, 3);
                WriteAt("       |     /|\\", 10, 4);
                WriteAt("       |     /", 10, 5); break;
            case 0:
                WriteAt("       |      O", 10, 3);
                WriteAt("       |     /|\\", 10, 4);
                WriteAt("       |     / \\", 10, 5); break;
        }
        WriteAt("   ____|____________", 10, 6);
        WriteAt("  /    |           /|", 10, 7);
        WriteAt(" /_______________ / |", 10, 8);
        WriteAt(" |               | /", 10, 9);
        WriteAt(" |_______________|/", 10, 10);
        Console.WriteLine();
    }

    public static void WriteAt(string s, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(s);
    }

    //check if the enter button is pressed by mistake
    //ConsoleKeyInfo keyInfo = Console.ReadKey();
    //if (keyInfo.Key == ConsoleKey.Enter)
    //{
    //    Console.WriteLine("\nDon't smash the Enter button, mastah! Now, again, proper letter: ");
    //}
}