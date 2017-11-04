using System;

class FiveIntegerNums
{
    //disclaimer - tasks 5 and 6 are the same like tasks 5(8) and 6 from 01-4 Operators and Expressions

    static void Main()
    {
        //done by yours trully <3
        int digitOne = 5;    //int.Parse(Console.ReadLine())
        int digitTwo = 0;    //int.Parse(Console.ReadLine())
        int digitThree = -2; //int.Parse(Console.ReadLine())
        int digitFour = -3;  //int.Parse(Console.ReadLine())
        int digitFive = 1;   //int.Parse(Console.ReadLine())

        int[] allDigits = new int[5] { digitOne, digitTwo, digitThree, digitFour, digitFive };

        //constant, which we want to subset
        int zero = 0;

        //see how many times we've subset zero
        int counter = 0;

        //check if just the single digit equals zero
        for (int i = 0; i < allDigits.Length; i++)
        {
            if (allDigits[i] == zero)
            {
                counter++;
                Console.WriteLine(counter + ".) " + allDigits[i] + " = " + zero);
            }
        }

        //this checks the sum of the first digit with all the other digits
        // 5 + 5
        // 5 + 0
        // 5 + -2
        // 5 + -3
        // 5 + 1
        int checkFirstDigit = 0;
        for (int i = 0; i < allDigits.Length; i++)
        {
            if (allDigits[checkFirstDigit] + allDigits[i] == zero)
            {
                counter++;
                Console.WriteLine($"{counter}.) {allDigits[checkFirstDigit]} + {allDigits[i]} = {zero}");
            }
        }

        //this checks the sum of the second digit with all the other digits
        // 0 + 0
        // 0 + -2
        // 0 + -3
        // 0 + 1
        int checkSecondDigit = 1;
        for (int i = 1; i < allDigits.Length; i++)
        {
            if (allDigits[checkSecondDigit] + allDigits[i] == zero)
            {
                counter++;
                Console.WriteLine($"{counter}.) {allDigits[checkSecondDigit]} + {allDigits[i]} = {zero}");
            }
        }

        //this checks the sum of the third digit with all of the other digits
        // -2 + -2
        // -2 + -3
        // -2 + 1
        int checkThirdDigit = 2;
        for (int i = 2; i < allDigits.Length; i++)
        {
            if (allDigits[checkThirdDigit] + allDigits[i] == zero)
            {
                counter++;
                Console.WriteLine($"{counter}.) {allDigits[checkThirdDigit]} + {allDigits[i]} = {zero}");
            }
        }

        //this check the sum of the fourth and fifth digits with themselves
        //  -3 + -3
        //  1 + 1
        int checkLastDigits = 3;
        for (int i = 3; i < allDigits.Length; i++)
        {
            if (allDigits[checkLastDigits] + allDigits[i] == zero)
            {
                counter++;
                Console.WriteLine($"{counter}.) {allDigits[checkLastDigits]} + {allDigits[i]} = {zero}");
            }
            checkLastDigits++;
        }

        //this checks all the triple sums
        //  5 + 0 + -2  
        //  5 + 0 + -3  
        //  5 + 0 + 1               
        //  5 + -2 + -3 
        //  5 + -2 + 1        
        //  5 + -3 + 1  
        //  0 + -2 + -3
        //  0 + -2 + 1
        //  0 + -3 + 1
        //  -2 + -3 + 1

        int firstIncreasingCounter = 0;
        int secondIncreasingCounter = 0;
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0: firstIncreasingCounter = 0; break;
                case 1: firstIncreasingCounter = 1; break;
                case 2: firstIncreasingCounter = 2; break;
            };

            for (int k = 1 + firstIncreasingCounter; k < 4; k++)
            {
                switch (k)
                {
                    case 1: secondIncreasingCounter = 0; break;
                    case 2: secondIncreasingCounter = 1; break;
                    case 3: secondIncreasingCounter = 2; break;
                };

                for (int j = 2 + secondIncreasingCounter; j < 5; j++)
                {

                    int iIndex = allDigits[i];
                    int kIndex = allDigits[k];
                    int jIndex = allDigits[j];
                    if (iIndex + kIndex + jIndex == zero)
                    {
                        counter++;
                        Console.WriteLine($"{counter}.) {iIndex} + {kIndex} + {jIndex} = {zero}");
                    }
                }
            }
        }
        //indexing reference:
        // 0 1  2  3 4
        // 5 0 -2 -3 1 
    }
}