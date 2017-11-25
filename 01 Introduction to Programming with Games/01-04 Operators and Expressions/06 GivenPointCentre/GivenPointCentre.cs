using System;

class GivenPointCentre
{
    static void Main()
    {
        //Write an expression that checks if a given point (x,y) is 
        //within a circle with radius 4 and centre at (0,0)
        decimal x = decimal.Parse(Console.ReadLine());

        decimal y = decimal.Parse(Console.ReadLine());
        
        decimal circleRadius = 4m;

        if ((x * x + y * y) <= (circleRadius * circleRadius))
        {
            Console.WriteLine("The point is within the circle!");
        }
        else
        {
            Console.WriteLine("The point is not within the circle!");
        }
    }
}