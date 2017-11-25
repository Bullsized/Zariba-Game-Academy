using System;
class LargestOfThree
{
    static void Main(string[] args)
    {
        //Write a program that finds the largest of 3 integers, using if statements.

        int firstDigit = int.Parse(Console.ReadLine());

        int secondDigit = int.Parse(Console.ReadLine());

        int thirdDigit = int.Parse(Console.ReadLine());

        if ((firstDigit >= secondDigit && firstDigit >= thirdDigit))
        {
            Console.WriteLine("{0} is the biggest integer.", firstDigit);
        }
        else if (secondDigit >= firstDigit && secondDigit >= thirdDigit)
        {
            Console.WriteLine("{0} is the biggest integer.", secondDigit);
        }
        else
        {
            Console.WriteLine("{0} is the biggest integer.", thirdDigit);
        }


        //second solution
        Console.WriteLine("The biggest integer is " + 
                            Math.Max(firstDigit, 
                            (Math.Max(secondDigit, thirdDigit))
                                    )
                    + ".");
    }
}