namespace AoC22;

public class Day0
{
    public static List<string> Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\DayInput.txt");

        return text.Split("\n").ToList();
    }

    public static int Result()
    {
        return 0;
    }

    public static int Result2()
    {
        return 0;
    }
}