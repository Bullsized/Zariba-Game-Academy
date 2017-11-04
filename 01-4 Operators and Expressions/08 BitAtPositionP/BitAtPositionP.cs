using System;

class BitAtPositionP
{
    static void Main()
    {
        //Write a Boolean expression that returns if the bit at position p (counting from 0) in 
        //a given integer v has value of 1.
        int givenInteger = int.Parse(Console.ReadLine());

        string binarySystemOfTheGivenInt = Convert.ToString(givenInteger, 2);

        char[] splitTheString = binarySystemOfTheGivenInt.ToCharArray();

        bool trueIfIsOne = splitTheString[2].ToString() == "1";

        Console.WriteLine($"Is the bit at position 2 one? {trueIfIsOne}!");

        Console.WriteLine($"And here's why: {binarySystemOfTheGivenInt}!");

        //pretty much the same solution as task No.5 ...
    }
}