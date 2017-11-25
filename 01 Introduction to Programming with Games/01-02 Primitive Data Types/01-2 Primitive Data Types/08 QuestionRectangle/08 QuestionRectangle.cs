using System;

class QuestionRect
{
    static void Main()
    {
        char piece = '¿';
        for (int i = 0; i < 6; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                Console.Write(piece);
            }
            Console.WriteLine();
        }
    }
}