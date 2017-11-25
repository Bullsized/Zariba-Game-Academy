using System;

class HelloUser
{
    static void Main()
    {
        Console.Write("Please input your name, mastah: ");

        string name = Console.ReadLine();
        GreetingsMethod(name);

    }

    public static void GreetingsMethod(string name)
    {
        Console.WriteLine("Hello, " + name + "!");
    }
}