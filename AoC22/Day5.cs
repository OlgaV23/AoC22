using System.Text.RegularExpressions;

namespace AoC22;

public class Day5
{
    private static List<string> commands;
    private static List<List<char>> grid;

    public static void Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\Day5Input.txt");

        //parse crates
        var cratesData = text.Split("\r\n\r\n").ElementAt(0).Split('\n').Select(x => x.TrimEnd()).ToList();
        cratesData.Reverse();

        var cratesDataHeader = cratesData.First().ToString();
        var numberOfColumns = int.Parse(cratesDataHeader.Split(' ').Last().ToString()!);

        cratesData.RemoveAt(0);


        List<List<char>> matrix = new();


        for (var i = 0; i < numberOfColumns; i++)
        {
            matrix.Add(new List<char>());
        }

        foreach (var line in cratesData)
        {
            for (var i = 0; i < line.Length; i += 4)
            {
                if (line[i + 1] != ' ')
                {
                    matrix.ElementAt(i / 4).Add(line[i + 1]);
                }
            }
        }

        grid = matrix;

        //parse commands
        commands = text.Split("\r\n\r\n").ElementAt(1).Split('\n').Select(x => x.TrimEnd()).ToList();
    }

    public static string Result()
    {
        Data();

        foreach (var command in commands)
        {
            // parse command
            // move 1 from 2 to 1

            var pattern = new Regex(@"\d+");
            var match = pattern.Matches(command);

            var move = int.Parse(match[0].Value);
            var from = int.Parse(match[1].Value) - 1;
            var to = int.Parse(match[2].Value) - 1;

            var temp = grid[from].TakeLast(move).Reverse();

            foreach (var item in temp)
            {
                grid[to].Add(item);
            }

            grid[from].RemoveRange(grid[from].Count - move, move);

        }

        return grid.Aggregate("", (current, col) => current + col.Last());
    }

    public static string Result2()
    {
        Data();

        foreach (var command in commands)
        {
            var pattern = new Regex(@"\d+");
            var match = pattern.Matches(command);

            var move = int.Parse(match[0].Value);
            var from = int.Parse(match[1].Value) - 1;
            var to = int.Parse(match[2].Value) - 1;

            var temp = grid[from].TakeLast(move);

            foreach (var item in temp)
            {
                grid[to].Add(item);
            }

            grid[from].RemoveRange(grid[from].Count - move, move);

        }

        return grid.Aggregate("", (current, col) => current + col.Last());

    }
}