using System;

class CheckBrackets
{
    static void Main()
    {
        Console.Write("Give us the equation, precious: ");

        string equation = Console.ReadLine();

        int openParenthesis = 0;
        int closeParenthesis = 0;

        for (int i = 0; i < equation.Length; i++)
        {
            if (equation[i] == '(')
            {
                openParenthesis++;
            }
            else if (equation[i] == ')')
            {
                closeParenthesis++;
            }
        }

        if (openParenthesis == closeParenthesis)
        {
            Console.WriteLine("The parenthesis are put correctly!");
        }
        else
        {
            Console.WriteLine("Nah bruv, wrong equation!");
        }
    }
}