using System;

class ExchangeTwoIfs
{
    static void Main()
    {
        //Write an if statement that exchanges the values of 2 numbers if the first is bigger than the second

        int firstDigit = int.Parse(Console.ReadLine());

        int secondDigit = int.Parse(Console.ReadLine());

        int tempDigit;

        if (firstDigit > secondDigit)
        {
            tempDigit = firstDigit;
            firstDigit = secondDigit;
            secondDigit = tempDigit;
            Console.WriteLine("Exchanged Values: a = {0}; b = {1}", firstDigit, secondDigit);
        }
        else
        {
            Console.WriteLine("Digits stayed the same, for the first one was not bigger than the second: a = {0}; b = {1}", firstDigit, secondDigit);
        }
    }
}