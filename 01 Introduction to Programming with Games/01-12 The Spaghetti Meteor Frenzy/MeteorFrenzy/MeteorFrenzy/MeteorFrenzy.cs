using System;
using System.Collections.Generic;
using System.Threading;


public class MeteorFrenzy
{
    public static bool isGameOver = false;

    public static int score = 0;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hardest
    }

    public static Difficulty currentDifficulty = Difficulty.Easy;

    public static int threadSleep = 200;

    public static int qLane = 1;

    public static int wLane = 11;

    public static int eLane = 21;

    public static int rLane = 31;

    public static int firstRow = 10;

    public static int secondRow = 20;

    public static int thirdRow = 30;

    public static int fourthRow = 40;

    public static int topAndBottomRightMargin = 41;

    public static int currentLane = 1;

    public static int lastLane = currentLane;

    public static int tillTheEndOfTheWindowWidth = 13;

    public static int rocketCount = 3;

    public static Random rng = new Random();

    public static List<Meteors> meteorList = new List<Meteors>();

    public static List<PowerUps> powerUpsList = new List<PowerUps>();

    public static int[] meteorSpawnPositions = new int[] { 3, 13, 23, 33 };

    public static List<int> meteorGenerator = new List<int>();

    //this is here in the startup file, because it didn't manage to read my Enum when I separated
    //it as a class file...
    public class UI
    {
        public int Score;
        public int RocketCount;
        public Difficulty Difficulty;

        public UI(Difficulty difficulty)
        {
            this.Score = score;
            this.RocketCount = rocketCount;
            this.Difficulty = difficulty;
        }

        public void Draw()
        {
            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.SetCursorPosition(firstRow, 0 + i);
                Console.Write("|");
                Console.SetCursorPosition(secondRow, 0 + i);
                Console.Write("|");
                Console.SetCursorPosition(thirdRow, 0 + i);
                Console.Write("|");
                Console.SetCursorPosition(fourthRow, 0 + i);
                Console.Write("|");
            }

            Console.SetCursorPosition(topAndBottomRightMargin, 0);
            Console.Write(new string('^', tillTheEndOfTheWindowWidth));
            Console.SetCursorPosition(topAndBottomRightMargin, Console.WindowHeight - 1);
            Console.Write(new string('v', tillTheEndOfTheWindowWidth));

            Console.SetCursorPosition(topAndBottomRightMargin + 1, 10);
            Console.Write("ROCKETS: ");
            Console.SetCursorPosition(topAndBottomRightMargin + 6, 11);
            Console.Write(rocketCount);

            Console.SetCursorPosition(topAndBottomRightMargin + 1, 20);
            Console.Write("DIFFICULTY: ");
            Console.SetCursorPosition(topAndBottomRightMargin + 5, 21);
            Console.Write(Difficulty);

            Console.SetCursorPosition(topAndBottomRightMargin + 1, 30);
            Console.Write("SCORE: ");
            Console.SetCursorPosition(topAndBottomRightMargin + 5, 31);
            Console.Write(score);
        }

        public void Delete()
        {
            Console.SetCursorPosition(topAndBottomRightMargin, 1);
            Console.Write(new string(' ', 9));
            Console.SetCursorPosition(topAndBottomRightMargin, Console.WindowHeight - 1);
            Console.Write(new string(' ', 9));

            Console.SetCursorPosition(topAndBottomRightMargin + 1, 10);
            Console.Write("            ");
            Console.SetCursorPosition(topAndBottomRightMargin + 6, 11);
            Console.Write("            ");

            Console.SetCursorPosition(topAndBottomRightMargin + 1, 20);
            Console.Write("                 ");
            Console.SetCursorPosition(topAndBottomRightMargin + 5, 21);
            Console.Write("                 ");

            Console.SetCursorPosition(topAndBottomRightMargin + 1, 30);
            Console.Write("            ");
            Console.SetCursorPosition(topAndBottomRightMargin + 5, 31);
            Console.Write("            ");
        }

        public void UpdateUI(int score)
        {
            this.Score = score;
            this.RocketCount = rocketCount;
            this.Difficulty = currentDifficulty;
        }
    }

    public class Meteors
    {
        public Vector2 Position;

        public Vector2 Velocity;

        public List<string> Elements;

        public int[] meteorListGenerator = new int[] { 0, 3, 6, 9 };

        public Meteors(Vector2 position)
        {
            this.Position = position;
            this.Velocity = new Vector2(0, 1);
            this.Elements = new List<string>
            {
                " __",      //0
                "|o \\",
                "|___|",
                " ___ ",    //3
                "|  o|",
                "|__/ ",
                " ___ ",    //6
                "|   |",
                " \\_o|",
                "  __",     //9
                " /  |",
                "|o__|"
            };
        }

        public void Draw()
        {
            int randomFigureStart = meteorListGenerator[rng.Next(meteorListGenerator.Length)];
            int randomFigureEnd = randomFigureStart + 3;
            for (int i = randomFigureStart; i < randomFigureEnd; i++)
            {
                if (this.Position.Y == Console.BufferHeight - 15)
                {
                    isGameOver = true;
                    Console.Clear();
                    Console.SetCursorPosition(20, 20);
                    Console.WriteLine("Game Over, bruv!");
                    Console.SetCursorPosition(24, 21);
                    Console.WriteLine("Score: {0}", score);
                    Thread.Sleep(10000);
                    break;
                }
                Console.SetCursorPosition(this.Position.X, this.Position.Y + i);
                Console.Write(this.Elements[i]);
            }
        }

        public void Delete()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(this.Position.X, this.Position.Y);
                Console.Write("     ");
            }
            Console.SetCursorPosition(this.Position.X, this.Position.Y + 5);
            Console.Write(new string(' ', 4));
        }

        public void Move()
        {
            this.Position.Add(this.Velocity);
        }
    }

    public class PowerUps
    {
        public Vector2 Position;

        public Vector2 Velocity;

        public string Element;
        
        public PowerUps(Vector2 position)
        {
            this.Position = position;
            this.Velocity = new Vector2(0, 1);
            this.Element = string.Empty;
            
        }

        public void Draw()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y);

            if (this.Element == "->")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("->");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (this.Element == "==>")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("==>");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Delete()
        {
            Console.SetCursorPosition(this.Position.X, this.Position.Y - 1);
            Console.Write("       ");
        }

        public void Move()
        {
            this.Position.Add(this.Velocity);
        }
    }

    static void Main()
    {
        //NOTE: Set Font to 16!
        Console.BufferHeight = Console.WindowHeight = 50;
        Console.BufferWidth = Console.WindowWidth = 55;
        Console.CursorVisible = false;

        Spacecraft spacecraft = new Spacecraft();
        UI ui = new UI(Difficulty.Easy);

        for (int i = 0; i < 101; i++)
        {
            meteorGenerator.Add(i);
        }

        while (!isGameOver)
        {
            spacecraft.Draw(currentLane);
            lastLane = currentLane;
            InputHandler(spacecraft);
            ui.Draw();
            ui.UpdateUI(score);
            ChangeDifficulty();

            if (rng.Next(meteorGenerator.Count) / 5 == 0)
            {
                Meteors meteor = new Meteors(
                    new Vector2(meteorSpawnPositions[rng.Next(meteorSpawnPositions.Length)], 0));
                meteorList.Add(meteor);
            }
            else if (rng.Next(meteorGenerator.Count) / 3 == 0)
            {
                PowerUps powerUp = new PowerUps(
                    new Vector2(meteorSpawnPositions[rng.Next(meteorSpawnPositions.Length)], 0));
                int whichPowerUpIsIt = rng.Next(0, 2);
                if (whichPowerUpIsIt == 0)
                {
                    powerUp.Element = "->";
                }
                else if (whichPowerUpIsIt == 1)
                {
                    powerUp.Element = "==>";
                }
                powerUpsList.Add(powerUp);
            }

            foreach (var rocket in spacecraft.RocketAmmo)
            {
                rocket.Move();
            }

            foreach (var rocket in spacecraft.RocketAmmo)
            {
                rocket.Draw(spacecraft);
            }

            foreach (var rocket in spacecraft.RocketAmmo)
            {
                rocket.Delete();
            }

            foreach (var meteor in meteorList)
            {
                meteor.Move();
            }

            foreach (var meteor in meteorList)
            {
                meteor.Draw();
            }

            foreach (var meteor in meteorList)
            {
                meteor.Delete();
            }

            foreach (var powerUp in powerUpsList)
            {
                powerUp.Move();
            }

            foreach (var powerUp in powerUpsList)
            {
                powerUp.Draw();
            }

            foreach (var powerUp in powerUpsList)
            {
                powerUp.Delete();
            }

            Thread.Sleep(threadSleep);

            RocketMeteorCollision(spacecraft.RocketAmmo, meteorList);
        }
    }

    public static void InputHandler(Spacecraft spacecraft)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            if (userInput.Key == ConsoleKey.Q && currentLane != qLane)
            {
                spacecraft.Draw(qLane);
                spacecraft.Delete(lastLane);
                currentLane = qLane;
                score++;
            }
            else if (userInput.Key == ConsoleKey.W && currentLane != wLane)
            {
                spacecraft.Draw(wLane);
                spacecraft.Delete(lastLane);
                currentLane = wLane;
                score++;
            }
            else if (userInput.Key == ConsoleKey.E && currentLane != eLane)
            {
                spacecraft.Draw(eLane);
                spacecraft.Delete(lastLane);
                currentLane = eLane;
                score++;
            }
            else if (userInput.Key == ConsoleKey.R && currentLane != rLane)
            {
                spacecraft.Draw(rLane);
                spacecraft.Delete(lastLane);
                currentLane = rLane;
                score++;
            }
            else if (userInput.Key == ConsoleKey.Spacebar)
            {
                if (rocketCount > 0)
                {
                    Rocket rocket = new Rocket(
                        new Vector2(spacecraft.Position.X, spacecraft.Position.Y - 5));
                    spacecraft.RocketAmmo.Add(rocket);
                    rocketCount--;
                }
            }
        }
    }

    public static void RocketMeteorCollision(List<Rocket> rockets, List<Meteors> meteors)
    {
        for (int rocket = 0; rocket < rockets.Count; rocket++)
        {
            for (int meteor = 0; meteor < meteors.Count; meteor++)
            {
                if (rockets[rocket].Position.Y == meteors[meteor].Position.Y)
                {
                    score += 20;
                    rockets.Remove(rockets[rocket]);
                    meteors.Remove(meteors[meteor]);
                }
            }
        }
    }

    public static void ChangeDifficulty()
    {
        if (score > 10 && currentDifficulty == Difficulty.Easy)
        {
            currentDifficulty = Difficulty.Medium;
            threadSleep = 150;

            for (int i = 5; i < 100; i += 5)
            {
                meteorGenerator.Add(i);
            }

        }
        else if (score > 30 && currentDifficulty == Difficulty.Medium)
        {
            currentDifficulty = Difficulty.Hardest;
            threadSleep = 50;

            for (int i = 5; i < 500; i += 5)
            {
                meteorGenerator.Add(i);
            }
        }
    }
}