namespace AoC22;


public class Day3
{
    private static readonly char[] Casing =
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z',
        'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
        'W', 'X', 'Y', 'Z'
    };

    public static List<string> Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\Day3Input.txt");

        return text.Split("\n").ToList();
    }

    public static int Result()
    {
        var temp = new List<string[]>();

        foreach (var item in Data())
        {
            string[] strings = {
                item[..(item.Length/2)],
                item.Substring(item.Length / 2, item.Length/2) };

            temp.Add(strings);
        }

        return temp.Sum(item => Array.IndexOf(Casing, item[0].Intersect(item[1]).ElementAt(0)) + 1);
    }

    public static int Result2()
    {
        var sum = 0;

        var data = Data();

        for (var i = 0; i < data.Count; i += 3)
        {
            var qwe = data[i].Intersect(data[i + 1]).Intersect(data[i + 2]).ElementAt(0);

            sum += Array.IndexOf(Casing, qwe) + 1;
        }

        return sum;
    }
}