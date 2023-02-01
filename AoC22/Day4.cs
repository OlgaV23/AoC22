namespace AoC22;


public class Day4
{
    public static List<int[][]> Data()
    {
        var text = System.IO.File.ReadAllText(
            @"C:\Users\miair\Desktop\_Proj\_AoC22\AoC22\InputFiles\Day4Input.txt");

        List<int[][]> res = new();

        var temp1 = text.Split('\n').ToList()
            .Select(x => x.Split(',').ToArray());

        foreach (var line in temp1)
        {
            var range1 = line[0].TrimEnd().Split('-');
            var range2 = line[1].TrimEnd().Split('-');

            res.Add(new[] {
                new[] { int.Parse(range1[0]), int.Parse(range1[1]) },
                new[] { int.Parse(range2[0]), int.Parse(range2[1])}});
        }

        return res;
    }

    public static int Result()
    {
        var data = Data();

        return data.Count(line => IsSubset(line[0][0], line[0][1], line[1][0], line[1][1]));
    }

    private static bool IsSubset(int r1Min, int r1Max, int r2Min, int r2Max)
    {
        if (r1Min >= r2Min && r1Min <= r2Max)
        {
            if (r1Max <= r2Max)
            {
                return true;
            }
        }

        if (r2Min >= r1Min && r2Min <= r1Max)
        {
            if (r2Max <= r1Max)
            {
                return true;
            }
        }

        return false;
    }

    public static int Result2()
    {
        var data = Data();

        return data.Count(line => IsOverlap(line[0][0], line[0][1], line[1][0], line[1][1]));
    }

    private static bool IsOverlap(int r1Min, int r1Max, int r2Min, int r2Max)
    {
        return r1Min <= r2Max && r2Min <= r1Max;
    }
}