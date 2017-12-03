using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

class Arkanoid
{
    public enum Difficulty
    {
        EASY,
        MEDIUM,
        HARD,
        INSANE
    }

    public enum PowerUpTypes
    {
        MAGNET,
        DOUBLE_BALL,
        GUNS,
        EXPLOSION
    }

    public const int BALL_VELOCITY = 1;
    public const int BLOCK_WIDTH = 6;
    public const int PADDLE_STEP = 3;

    public static Random rng = new Random();
    public static bool isGameOver = false;
    public static int playfieldHeight;
    public static Difficulty difficulty = Difficulty.EASY;
    public static int blocksDestroyed = 0;
    public static int lives = 3;

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

    public class Paddle
    {
        public Vector2 Position;
        public string Elements;

        public Paddle()
        {
            this.Position = new Vector2(Console.WindowWidth / 2, playfieldHeight - 3);
            this.Elements = "(#############)";
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(this.Elements);
        }

        public void Delete()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(new string(' ', this.Elements.Length));
        }

        public void MoveBy(int x)
        {
            if (this.Position.X + x < 1 || this.Position.X + x > Console.WindowWidth - Elements.Length)
            {
                return;
            }

            this.Position.Add(new Vector2(x, 0));
        }

        public void Reset()
        {
            this.Position = new Vector2(Console.WindowWidth / 2, playfieldHeight - 3);
        }
    }

    public class Ball
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public char Element;

        public Ball()
        {
            this.Position = new Vector2(Console.WindowWidth / 2 - 17, playfieldHeight - 4);
            this.Velocity = new Vector2(1, -1);
            this.Element = 'O';
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(this.Element);
        }

        public void Delete()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(' ');
        }

        public void Update()
        {
            if (this.Position.X <= 1 || this.Position.X >= Console.WindowWidth - 1)
            {
                this.Velocity.X = -this.Velocity.X;
            }

            if (this.Position.Y == 1 || this.Position.Y == playfieldHeight - 1)
            {
                this.Velocity.Y = -this.Velocity.Y;
            }

            this.Position.Add(this.Velocity);
        }

        public void Reset()
        {
            this.Position = new Vector2(Console.WindowWidth / 2, playfieldHeight - 4);
            this.Velocity = new Vector2(1, -1);
        }
    }

    public class Block
    {
        public Vector2 Position;
        public string Elements;
        public ConsoleColor Color;

        public bool HasPowerUp;

        public Block(Vector2 position, bool hasPowerUp)
        {
            this.Position = position;
            this.Elements = new string(' ', BLOCK_WIDTH);
            this.Color = (ConsoleColor)rng.Next(1, 16);

            this.HasPowerUp = hasPowerUp;
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.BackgroundColor = this.Color;
            Console.Write(this.Elements);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public void Delete()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(this.Elements);
        }
    }
    
    public class PowerUp
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public PowerUpTypes Type;

        public char Element;
        public ConsoleColor Color;

        public PowerUp(Vector2 position, PowerUpTypes type)
        {
            this.Position = position;
            this.Velocity = new Vector2(0, 1);
            this.Type = type;

            switch (type)
            {
                case PowerUpTypes.MAGNET:
                    this.Element = '%';
                    this.Color = ConsoleColor.Green;
                    break;
                case PowerUpTypes.DOUBLE_BALL:
                    this.Element = '*';
                    this.Color = ConsoleColor.Yellow;
                    break;
                case PowerUpTypes.GUNS:
                    this.Element = '^';
                    this.Color = ConsoleColor.Cyan;
                    break;
                case PowerUpTypes.EXPLOSION:
                    this.Element = '$';
                    this.Color = ConsoleColor.Red;
                    break;
                default:
                    break;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this.Element);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public void Delete()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);
            Console.Write(' ');
        }

        public void Update()
        {
            this.Position.Add(this.Velocity);
        }
    }

    static void Main()
    {
        // Game Plan
            // Class Paddle
            // Input Handler
            // Class Ball
            // Collision with Game Field
            // Collision Ball Paddle
            // Class Block
            // Level Generation
            // Collision Ball Blocks
            // UI
                // DIfficulty
                // Score
                // Lives
            // Game Lose Check
            // Game Win Check
            // PowerUp

        Console.BufferHeight = Console.WindowHeight = 40;
        Console.BufferWidth = Console.WindowWidth = 80;
        playfieldHeight = Console.BufferHeight - 5;

        Console.CursorVisible = false;

        Paddle paddle = new Paddle();
        List<Ball> balls = new List<Ball>();
        balls.Add(new Ball());
        List<Block> blocks = new List<Block>();
        LoadLevel(blocks);

        List<PowerUp> powerUps = new List<PowerUp>();

        DrawPlayfield();
        DrawBlocks(blocks);

        // Game Loop
        while (!isGameOver)
        {
            InputHandler(paddle);

            foreach (var ball in balls)
            {
                ball.Update();
            }
            foreach (var powerUp in powerUps)
            {
                powerUp.Update();
            }

            UpdateDifficulty(paddle);

            BallPaddleCollision(balls, paddle);
            BallBlocksCollision(balls, blocks, powerUps);
            PowerUpPaddleCollision(powerUps, paddle, balls);
            PowerUpPlayfiledCollision(powerUps);

            DrawBlocks(blocks);
            DrawUI();
            paddle.Draw();
            foreach (var ball in balls)
            {
                ball.Draw();
            }
            foreach (var powerUp in powerUps)
            {
                powerUp.Draw();
            }

            CheckGameLost(balls, paddle);
            CheckGameWin(blocks);

            Thread.Sleep(80 - ((int)difficulty * 10));

            paddle.Delete();
            foreach (var ball in balls)
            {
                ball.Delete();
            }
            foreach (var powerUp in powerUps)
            {
                powerUp.Delete();
            }
        }
    }

    private static void DrawBlocks(List<Block> blocks)
    {
        foreach (var block in blocks)
        {
            block.Draw();
        }
    }

    private static void DrawUI()
    {
        Console.SetCursorPosition(3, playfieldHeight + 1);
        Console.Write("Difficulty: {0}", difficulty);

        Console.SetCursorPosition(3, playfieldHeight + 3);
        Console.Write("Score: {0}", blocksDestroyed);

        Console.SetCursorPosition(25, playfieldHeight + 1);
        Console.Write("Lives: {0}", lives);
    }

    public static void UpdateDifficulty(Paddle paddle)
    {
        if (blocksDestroyed > 20)
        {
            difficulty = Difficulty.INSANE;
            paddle.Elements = "(#)";
        }
        else if (blocksDestroyed > 10)
        {
            difficulty = Difficulty.HARD;
            paddle.Elements = "(####)";
        }
        else if (blocksDestroyed > 5)
        {
            difficulty = Difficulty.MEDIUM;
            paddle.Elements = "(##########)";
        }
    }

    private static void DrawPlayfield()
    {
        Console.SetCursorPosition(0, playfieldHeight);
        Console.Write(new string('^', Console.WindowWidth));
    }

    public static void LoadLevel(List<Block> blocks)
    {
        string[] input = File.ReadAllLines("level.txt");

        for (int row = 0; row < input.Length; row++)
        {
            for (int symbol = 0; symbol < input[row].Length; symbol++)
            {
                if (input[row][symbol] != '0')
                {
                    bool hasPowerUp = false;   
                    if (input[row][symbol] == '2')
                    {
                        hasPowerUp = true;
                    }

                    Vector2 Position = new Vector2(symbol * (BLOCK_WIDTH + 1), row);
                    blocks.Add(new Block(Position, hasPowerUp));
                }
            }
        }
    }

    public static void InputHandler(Paddle paddle)
    {
        // Console.ReadKey()
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            // Hack
            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                paddle.MoveBy(-PADDLE_STEP);
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                paddle.MoveBy(PADDLE_STEP);
            }
        }
    }

    public static void BallPaddleCollision(List<Ball> balls, Paddle paddle)
    {
        foreach (var ball in balls)
        {
            if (ball.Position.IsColliding(paddle.Position, paddle.Elements.Length))
            {
                ball.Velocity.Y = -ball.Velocity.Y;

                //for (int i = 1; i <= 5; i++)
                //{
                //    if (ball.Position.X < paddle.Position.X + (paddle.Elements.Length / 5) * i)
                //    {
                //        ball.Velocity.X = (i - 3) * BALL_VELOCITY;
                //    }
                //}

                if (ball.Position.X < paddle.Position.X + (paddle.Elements.Length / 5) * 2)
                {
                    ball.Velocity.X = -BALL_VELOCITY;
                }
                else if (ball.Position.X < paddle.Position.X + (paddle.Elements.Length / 5) * 3)
                {
                    ball.Velocity.X = 0;
                }
                else
                {
                    ball.Velocity.X = BALL_VELOCITY;
                }
            }
        }
    }

    public static void BallBlocksCollision(List<Ball> balls, List<Block> blocks, List<PowerUp> powerUps)
    {
        foreach (var ball in balls)
        {
            for (int i = 0; i < blocks.Count; i++)
            {
                if (ball.Position.IsColliding(blocks[i].Position, blocks[i].Elements.Length))
                {
                    ball.Velocity.Y = -ball.Velocity.Y;

                    blocksDestroyed++;

                    if (blocks[i].HasPowerUp)
                    {
                        powerUps.Add(new PowerUp(blocks[i].Position, PowerUpTypes.DOUBLE_BALL));
                    }

                    blocks[i].Delete();
                    blocks.Remove(blocks[i]);
                    i--;
                }
            }
        }
    }

    public static void PowerUpPaddleCollision(List<PowerUp> powerUps, Paddle paddle, List<Ball> balls)
    {
        for (int i = 0; i < powerUps.Count; i++)
        {
            if (powerUps[i].Position.IsColliding(paddle.Position, paddle.Elements.Length))
            {
                balls.Add(new Ball());

                powerUps[i].Delete();
                powerUps.Remove(powerUps[i]);
                i--;
            }
        }
    }

    public static void PowerUpPlayfiledCollision(List<PowerUp> powerUps)
    {
        for (int i = 0; i < powerUps.Count; i++)
        {
            if (powerUps[i].Position.Y == playfieldHeight - 1)
            {
                powerUps.Remove(powerUps[i]);
                i--;
            }
        }
    }

    public static void CheckGameLost(List<Ball> balls, Paddle paddle)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].Position.Y == playfieldHeight - 1)
            {
                if (balls.Count > 1)
                {
                    balls.Remove(balls[i]);
                    i--;
                    continue;
                }

                lives--;

                if (lives == 0)
                {
                    isGameOver = true;
                    Console.Clear();

                    Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 1);
                    Console.Write("YOU LOST!");
                    Console.SetCursorPosition(Console.WindowWidth / 3, 5);
                    Console.Write("You achieved a score of {0}", blocksDestroyed * 10);
                    Console.SetCursorPosition(Console.WindowWidth / 3, 6);
                    Console.Write("Difficulty {0}", difficulty);
                    Console.SetCursorPosition(Console.WindowWidth / 3, 7);
                    Console.Write("LIVES:LIVES:LIVES:LIVES:LIVES: 0");
                }
                else
                {
                    balls[i].Reset();

                    paddle.Delete();
                    paddle.Reset();
                }
            }
        }
    }

    public static void CheckGameWin(List<Block> blocks)
    {
        if (blocks.Count == 0)
        {
            isGameOver = true;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("you won");
        }
    }
}