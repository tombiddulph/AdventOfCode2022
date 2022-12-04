namespace AdventOfCode.Day3;

public class Day3
{
    private static readonly List<char> Characters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();

    public static int Part1() =>
        (from readAllLine in File.ReadAllLines("Day3/input.txt")
            let first = readAllLine[..(readAllLine.Length / 2)]
            let second = readAllLine[(readAllLine.Length / 2)..]
            select first.Intersect(second).Single()
            into match
            select Characters.IndexOf(match) + 1).Sum();

    public static int Part2()
    {
        var lines = File.ReadAllLines("Day3/input.txt");
        var result = 0;
        for (var index = 0; index < lines.Length; index+=3)
        {
            result += Characters.IndexOf(lines.Skip(index).Take(3)
                .Aggregate((x, y) => new string(x.Intersect(y).ToArray())).First()) + 1;
        }

        return result;
    }
    
}