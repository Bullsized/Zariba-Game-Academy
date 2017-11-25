using System;

class Trapezium
{
    static void Main()
    {
        //Write a program that evaluates the area of a trapezium, given its sides and height.

        double a = double.Parse(Console.ReadLine());

        double b = double.Parse(Console.ReadLine());

        double h = double.Parse(Console.ReadLine());

        double area = ((a + b) / 2) * h;

        Console.WriteLine("The area of your trapezoid is: {0}", area);
    }
}