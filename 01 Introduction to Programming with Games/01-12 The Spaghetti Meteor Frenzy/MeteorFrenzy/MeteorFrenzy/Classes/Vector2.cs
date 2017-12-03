public class Vector2
{
    public int X;
    public int Y;

    public Vector2(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public void Add(Vector2 value)
    {
        this.X += value.X;
        this.Y += value.Y;
    }

    public bool IsColliding(Vector2 value, int length)
    {
        if (this.X >= value.X && this.X < value.X + length && this.Y == value.Y)
        {
            return true;
        }

        return false;
    }
}