namespace AoC22;

public class Day1
{
    public static List<List<int>> Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\Day1Input.txt");

        return text.Split("\n\n").Select(item => item.Split("\n")
                .Select(int.Parse)
                .ToList())
            .ToList();
    }

    public static int Result()
    {
        return Data().Select(item => item.Sum()).Max();
    }

    public static int Result2()
    {
        return Data().OrderByDescending(item => item.Sum()).Take(3).Sum(x => x.Sum());
    }
}