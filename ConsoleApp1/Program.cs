using System;
using System.Threading;

class ChristmasTree
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of levels for the Christmas tree:");
        int treeLevels = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the height of the trunk:");
        int trunkHeight = int.Parse(Console.ReadLine());

        // Generate the tree with placeholders for lights
        char[][] tree = GenerateTree(treeLevels);

        // Display each level of the tree one by one
        for (int i = 0; i < treeLevels; i++)
        {
            Console.Clear();
            DisplayTree(tree, i + 1);
            Thread.Sleep(500); // Delay between each level
        }

        // Display the trunk last
        GenerateTrunk(treeLevels, trunkHeight);

        // Wait for 3 seconds before showing lights
        Thread.Sleep(3000);

        // Start the light flashing loop
        StartLightFlashing(tree, treeLevels, trunkHeight);
    }

    static char[][] GenerateTree(int levels)
    {
        char[][] tree = new char[levels][];
        for (int i = 0; i < levels; i++)
        {
            tree[i] = new char[2 * i + 1];
            for (int j = 0; j < (2 * i + 1); j++)
            {
                tree[i][j] = '*'; // Initially, all are tree parts
            }
        }
        return tree;
    }

    static void DisplayTree(char[][] tree, int levelsToShow)
    {
        for (int i = 0; i < levelsToShow; i++)
        {
            // Print spaces for alignment
            Console.Write(new string(' ', tree.Length - i - 1));

            // Display tree parts
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string(tree[i]));
            Console.ResetColor();
        }
    }

    static void GenerateTrunk(int levels, int height)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow; // Closest to brown
        for (int i = 0; i < height; i++)
        {
            Console.Write(new string(' ', levels - 1));
            Console.WriteLine("|||");
        }
        Console.ResetColor();
    }

    static void StartLightFlashing(char[][] tree, int treeLevels, int trunkHeight)
    {
        // Initial color of the lights
        ConsoleColor lightColor = ConsoleColor.Yellow;

        while (true) // Loop for alternating lights
        {
            Console.Clear();
            DisplayTreeWithLights(tree, treeLevels, lightColor);
            GenerateTrunk(treeLevels, trunkHeight);
            Thread.Sleep(1000); // Wait for 1 second

            // Alternate light color
            lightColor = lightColor == ConsoleColor.Yellow ? ConsoleColor.Red : ConsoleColor.Yellow;
        }
    }

    static void DisplayTreeWithLights(char[][] tree, int levels, ConsoleColor lightColor)
    {
        for (int i = 0; i < levels; i++)
        {
            // Print spaces for alignment
            Console.Write(new string(' ', tree.Length - i - 1));

            // Display tree parts and lights
            for (int j = 0; j < tree[i].Length; j++)
            {
                if (j % 2 == 0) // Positions for lights
                {
                    Console.ForegroundColor = lightColor;
                    Console.Write('o');
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(tree[i][j]);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
    }
}
