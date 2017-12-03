using System;
using System.Collections.Generic;


public class Rocket
{
    public Vector2 Position;
    public Vector2 Velocity;
    public List<string> Elements;

    public Rocket(Vector2 position)
    {
        this.Position = position;
        this.Velocity = new Vector2(0, -1);
        this.Elements = new List<string>
            {
                " _",
                "/ \\",
                "\\ /",
                "|||"
            };
    }

    public void Draw(Spacecraft spacecraft)
    {
        if (this.Position.Y == 2)
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                Console.SetCursorPosition(this.Position.X, this.Position.Y + i);
                Console.Write(new string(' ', this.Elements[i].Length));
            }
            Console.SetCursorPosition(this.Position.X, this.Position.Y + 5);
            Console.Write(new string(' ', 9));
        }
        for (int i = 0; i < Elements.Count; i++)
        {
            Console.SetCursorPosition(this.Position.X + 3, this.Position.Y + 1 + i);
            Console.Write(this.Elements[i]);
        }
    }

    public void Delete()
    {
        for (int i = 0; i < Elements.Count; i++)
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y + i);
            Console.Write(new string(' ', this.Elements[i].Length));
        }
        Console.SetCursorPosition(this.Position.X, this.Position.Y + 5);
        Console.Write(new string(' ', 9));
    }

    public void Move()
    {
        this.Position.Add(this.Velocity);
    }
}