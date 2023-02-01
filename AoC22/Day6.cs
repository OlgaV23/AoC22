namespace ConsoleApp7;

public class Day6
{
    public static List<string> Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\Day6Input.txt");

        return text.Split("\n").ToList();
    }

    public static int Result()
    {
        var data = Data()[0].TrimEnd();

        for (var i = 0; i < data.Length; i++)
        {
            var temp = data.Substring(i, 4);

            if (temp.Length == temp.Distinct().Count())
            {
                return i + 4;
            }
        }

        return 0;
    }

    public static int Result2()
    {
        var data = Data()[0].TrimEnd();

        for (var i = 0; i < data.Length; i++)
        {
            var temp = data.Substring(i, 14);

            if (temp.Length == temp.Distinct().Count())
            {
                return i + 14;
            }
        }

        return 0;
    }
}