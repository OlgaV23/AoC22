namespace AoC22;

public class Day2
{
    public static List<string> Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\source\repos\ConsoleApp7\ConsoleApp7\InputFiles\Day2Input.txt");

        return text.Split("\n").ToList();
    }

    static int CountResult1(string game)
    {
        var sum = 0;

        switch (game[2])
        {
            case 'X':
                sum += 1;
                break;
            case 'Y':
                sum += 2;
                break;
            case 'Z':
                sum += 3;
                break;
        }

        switch (game)
        {
            //lose
            case "A Z":
            case "B X":
            case "C Y":
                sum += 0;
                break;
            //win
            case "A Y":
            case "B Z":
            case "C X":
                sum += 6;
                break;
            //draw
            case "A X":
            case "B Y":
            case "C Z":
                sum += 3;
                break;
        }

        return sum;
    }

    public static int CountResult2(string game)
    {
        var newGame = game.Remove(2);

        if (game[2] == 'X')
            switch (game[0])
            {
                case 'A':
                    newGame += 'Z';
                    break;
                case 'B':
                    newGame += 'X';
                    break;
                case 'C':
                    newGame += 'Y';
                    break;
            }
        else if (game[2] == 'Y')
            switch (game[0])
            {
                case 'A':
                    newGame += 'X';
                    break;
                case 'B':
                    newGame += 'Y';
                    break;
                case 'C':
                    newGame += 'Z';
                    break;
            }
        else if (game[2] == 'Z')
            switch (game[0])
            {
                case 'A':
                    newGame += 'Y';
                    break;
                case 'B':
                    newGame += 'Z';
                    break;
                case 'C':
                    newGame += 'X';
                    break;
            }

        return CountResult1(newGame);
    }

    public static int Result()
    {
        return Data().Sum(line => CountResult1(line));
    }

    public static int Result2()
    {
        return Data().Sum(line => CountResult2(line));
    }
}