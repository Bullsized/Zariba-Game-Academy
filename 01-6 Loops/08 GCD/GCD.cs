using System;

class GCD
{
    static void Main()
    {
        //Write a program that calculates the greatest common divisor (GCD) of given two numbers. 
        //Use the Euclidean algorithm(find it in Internet).
        int firstNum = int.Parse(Console.ReadLine());
        int secondNum = int.Parse(Console.ReadLine());

        while (firstNum != secondNum)
        {
            if (firstNum > secondNum)
            {
                firstNum = firstNum - secondNum;
            }
            else
            {
                secondNum = secondNum - firstNum;
            }
        }
        Console.WriteLine("The greatest common divisor is: {0}", firstNum);
    }
}