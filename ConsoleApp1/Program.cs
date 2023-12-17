using System;
using System.Threading;

class ChristmasTree
{
    static void Main(string[] args)
    {
        Console.WriteLine("Wpisz ile poziomów ma mieć drzewko:");
        int treeLevels = int.Parse(Console.ReadLine());

        Console.WriteLine("Wpisz ile poziomów ma mieć pień:");
        int trunkHeight = int.Parse(Console.ReadLine());

        while (true) 
        {
            Console.Clear();
            GenerateTree(treeLevels);
            GenerateTrunk(treeLevels, trunkHeight);
            Thread.Sleep(1000); 
        }
    }

    static void GenerateTree(int levels)
    {
        for (int i = 0; i < levels; i++)
        {
            
            Console.Write(new string(' ', levels - i - 1));

           
            for (int j = 0; j < (2 * i + 1); j++)
            {
                if (RandomLight() && j % 2 == 0) 
                {
                    Console.ForegroundColor = GetRandomConsoleColor();
                    Console.Write('o');
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('*');
                    Console.ResetColor();
                }
            }

            Console.WriteLine();
        }
    }

    static void GenerateTrunk(int levels, int height)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i < height; i++)
        {
            Console.Write(new string(' ', levels - 1));
            Console.WriteLine("|||");
        }
        Console.ResetColor();
    }

    static bool RandomLight()
    {
        Random rnd = new Random();
        return rnd.Next(2) == 0; // Randomly return true or false
    }

    static ConsoleColor GetRandomConsoleColor()
    {
        var consoleColors = Enum.GetValues(typeof(ConsoleColor));
        Random rnd = new Random();
        return (ConsoleColor)consoleColors.GetValue(rnd.Next(consoleColors.Length));
    }
}
