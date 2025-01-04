using System.Collections.Generic;
using System.Threading;


namespace Snake_Game
{
    class SnakeGame
    {
        static int Width = 20;
        static int Height = 20;
        static int Score = 0;
        static Random Random = new Random();
        static List<(int, int)> Snake = new List<(int, int)>();
        static (int, int) Direction = (-1, 0);
        static (int, int) Head = (Width / 2, Height / 2);
        static (int, int) Fruit = (Random.Next(0, Width - 1), Random.Next(0, Height - 1));

        static bool GameOver = false;

        static void Main()
        {
            //SetUp()
            SetUp();

            while (!GameOver)
            {
                // Draw()

                Draw();

                // HandleInput()

                HandleInput();

                // SnakeMove()

                SnakeMovement();

                // CheckifOver()

                CheckIfOver();

                // CheckifSnakeEatFruit()

                CheckifSnakeEatFruit();

                Thread.Sleep(50);
            }
        }

        static void SetUp()
        {
            Snake.Clear();

            Head = (Width / 2, Height / 2);

            Snake.Add(Head);

            Fruit = (Random.Next(0, Width - 1), Random.Next(0, Height - 1));

        }

        static void Draw()
        {
            Console.Clear();
            for (int i = 0; i < Width; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (j == 0 || j == Width - 1)
                        Console.Write("#");
                    else if ((j, i) == Head)
                        Console.Write("O");
                    else if (Snake.Contains((j, i)))
                        Console.Write("o");
                    else if (Fruit == (j, i))
                        Console.Write("&");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < Width; i++)
            {
                Console.Write("#");
            }
            Console.WriteLine();

            Console.WriteLine($"The Score : {Score}");

        }

        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var Key = Console.ReadKey(true).Key;

                if (Key == ConsoleKey.UpArrow && Direction != (0, 1))
                    Direction = (0, -1);
                else if (Key == ConsoleKey.DownArrow && Direction != (0, -1))
                    Direction = (0, 1);
                else if (Key == ConsoleKey.RightArrow && Direction != (-1, 0))
                    Direction = (1, 0);
                else if (Key == ConsoleKey.LeftArrow && Direction != (1, 0))
                    Direction = (-1, 0);

            }
        }

        static void SnakeMovement()
        {
            Head = (Head.Item1 + Direction.Item1, Head.Item2 + Direction.Item2);

            Snake.Insert(0, Head);

            if (Head != Fruit)
                Snake.RemoveAt(Snake.Count - 1);

        }

        static void CheckIfOver()
        {
            if (Head.Item1 <= 0 || Head.Item1 >= Width || Head.Item2 < 0 || Head.Item2 > Height || Snake.GetRange(1, Snake.Count - 1).Contains(Head))
                GameOver = true;
        }

        static void CheckifSnakeEatFruit()
        {
            if (Head == Fruit)
            {
                Score++;

                Fruit = (Random.Next(0, Width - 1), Random.Next(0, Height - 1));
                if (Snake.Contains(Fruit))
                    Fruit = (Random.Next(0, Width - 1), Random.Next(0, Height - 1));

            }
        }

    }
}


