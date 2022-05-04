using System;

namespace Study
{
    class Program
    {
        static public int X { get; set; } = 0;
        static public int Y { get; set; } = 0;
        static string[,] GenerateField()
        {
            string[,] field = new string[10, 10]
            {
                {"@", "_", "_", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "#", "#", "#", "_", "_", "_", "_", "_", "_" },
                {"_", "#", "_", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "#", "_", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "#", "#", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "_", "_", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "#", "#", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "_", "_", "_", "_", "#", "_", "_", "_", "_" },
                {"_", "#", "#", "#", "_", "#", "_", "_", "_", "_" },
                {"_", "_", "_", "#", "_", "#", "_", "_", "_", "x" }
            };
            return field;
        }
        static void DisplayField(string[,] field)
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static bool IsWallUp(string[,] field)
        {
            if(field[X-1, Y] == "#")
            {
                return true;
            }
            return false;
        }
        static bool IsWallDown(string[,] field)
        {
            if (field[X + 1, Y] == "#")
            {
                return true;
            }
            return false;
        }
        static bool IsWallLeft(string[,] field)
        {
            if (field[X, Y - 1] == "#")
            {
                return true;
            }
            return false;
        }
        static bool IsWallRight(string[,] field)
        {
            if (field[X, Y + 1] == "#")
            {
                return true;
            }
            return false;
        }
        static bool IsFinishUp(string[,] field)
        {
            if (field[X - 1, Y] == "x")
            {
                return true;
            }
            return false;
        }
        static bool IsFinishDown(string[,] field)
        {
            if (field[X + 1, Y] == "x")
            {
                return true;
            }
            return false;
        }
        static bool IsFinishLeft(string[,] field)
        {
            if (field[X, Y-1] == "x")
            {
                return true;
            }
            return false;
        }
        static bool IsFinishRight(string[,] field)
        {
            if (field[X, Y+1] == "x")
            {
                return true;
            }
            return false;
        }
        static void Move(string[,] field)
        {
            while(true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                try
                {
                    switch (key)
                    {
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                        case ConsoleKey.W:
                            if (IsWallUp(field)) continue;
                            if (IsFinishUp(field)) FinalScreen();
                            field[X, Y] = "_";
                            field[X - 1, Y] = "@";
                            X--;
                            break;
                        case ConsoleKey.A:
                            if(IsWallLeft(field)) continue;
                            if (IsFinishLeft(field)) FinalScreen();
                            field[X, Y] = "_";
                            field[X, Y - 1] = "@";
                            Y--;
                            break;
                        case ConsoleKey.S:
                            if (IsWallDown(field)) continue;
                            if (IsFinishDown(field)) FinalScreen();
                            field[X, Y] = "_";
                            field[X + 1, Y] = "@";
                            X++;
                            break;
                        case ConsoleKey.D:
                            if(IsWallRight(field)) continue;
                            if (IsFinishRight(field)) FinalScreen();
                            field[X, Y] = "_";
                            field[X, Y + 1] = "@";
                            Y++;
                            break;
                    }
                }
                catch
                {
                    field[X, Y] = "@";
                    continue;
                }
                finally
                {
                    Console.Clear();
                    DisplayField(field);
                }
            }
            
        }

        static void FinalScreen()
        {
            Console.Clear();
            Console.WriteLine("\t┌───────────────────────────────────────┐");
            Console.WriteLine("\t│                                       │");
            Console.WriteLine("\t│        You completed this game!       │");
            Console.WriteLine("\t│           Congratulations!            │");
            Console.WriteLine("\t│       Send this to your friend!       │");
            Console.WriteLine("\t│                                       │");
            Console.WriteLine("\t│          Press Escape to quit         │");
            Console.WriteLine("\t│                                       │");
            Console.WriteLine("\t└───────────────────────────────────────┘");
            while(true)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default: continue;
                }
            }
        }

        static void Main(string[] args)
        {
            string[,] field = GenerateField();
            DisplayField(field);
            Move(field); 
        }
    }
}