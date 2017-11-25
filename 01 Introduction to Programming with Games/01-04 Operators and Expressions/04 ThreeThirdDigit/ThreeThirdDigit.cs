using System;

class ThreeThirdDigit
{
    static void Main()
    {
        //Write an expression to check if the 3rd digit of an integer is 3.e.g. 2351 ? true

        int initialDivision = 2351 / 100;
        int findingTheThirdDigit = initialDivision % 10;
        bool result = (findingTheThirdDigit == 3);
        Console.WriteLine($"Is the third digit '3'? {result}!");
    }
}