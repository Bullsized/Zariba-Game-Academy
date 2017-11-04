using System;

class SwitchPrinting
{
    static void Main()
    {
        //Write a program that enters a number from 10 to 19 and prints on the console the 
        //name of the number. E.g. 11 – “eleven”. Use switch.
        int desiredInt = int.Parse(Console.ReadLine());

        switch (desiredInt)
        {
            case 10: Console.WriteLine("The name of the number is: ten!"); break;
            case 11: Console.WriteLine("The name of the number is: eleven!"); break;
            case 12: Console.WriteLine("The name of the number is: twelve!"); break;
            case 13: Console.WriteLine("The name of the number is: thirteen!"); break;
            case 14: Console.WriteLine("The name of the number is: fourteen!"); break;
            case 15: Console.WriteLine("The name of the number is: fifteen!"); break;
            case 16: Console.WriteLine("The name of the number is: sixteen!"); break;
            case 17: Console.WriteLine("The name of the number is: seventeen!"); break;
            case 18: Console.WriteLine("The name of the number is: eighteen!"); break;
            case 19: Console.WriteLine("The name of the number is: nineteen!"); break;
            default: Console.WriteLine("You must imput a number between 10 and 19!"); break;
        }
    }
}