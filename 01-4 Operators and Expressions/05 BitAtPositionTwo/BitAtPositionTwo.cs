using System;

class BitAtPositionTwo
{
    static void Main()
    {
        //Write a boolean expression for finding if the bit at position 2 (counting from 0) of 
        //a given integer is 1 or 0.e.g.If 1-> true
        int givenInteger = int.Parse(Console.ReadLine());

        string binarySystemOfTheGivenInt = Convert.ToString(givenInteger, 2);

        char[] splitTheString = binarySystemOfTheGivenInt.ToCharArray();

        bool trueIfIsOne = splitTheString[2].ToString() == "1";

        Console.WriteLine($"Is the bit at position 2 one? {trueIfIsOne}!");

        Console.WriteLine($"And here's why: {binarySystemOfTheGivenInt}!");
    }
}