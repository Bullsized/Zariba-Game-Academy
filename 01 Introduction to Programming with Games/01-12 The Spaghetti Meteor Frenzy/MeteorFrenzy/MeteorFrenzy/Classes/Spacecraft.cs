using System;
using System.Collections.Generic;

public class Spacecraft
{
    public Vector2 Position;

    public List<string> Elements;

    public List<Rocket> RocketAmmo;

    public int startAtFirstLane = 7;

    public Spacecraft()
    {
        this.Position = new Vector2(0, Console.BufferHeight - startAtFirstLane);
        this.Elements = new List<string>
            {
                "    .",
                "   / \\",
                "  .|||.",
                " /|...|\\",
                "/ |   | \\",
                "\\/\\|||/\\/",
                "  ((.))"
            };

        this.RocketAmmo = new List<Rocket>();
    }

    public void Draw(int lane)
    {
        for (int i = 0; i < this.Elements.Count; i++)
        {
            Console.SetCursorPosition(lane, this.Position.Y + i);
            Console.Write(this.Elements[i]);
        }
        this.Position = new Vector2(lane, this.Position.Y);
    }

    public void Delete(int lane)
    {
        for (int i = 0; i < this.Elements.Count; i++)
        {
            Console.SetCursorPosition(lane, this.Position.Y + i);
            Console.Write(new string(' ', 9));
        }
    }
}