namespace AdventOfCode.Day6;

public class Day6
{
    public static int Part1() => ReadFileToOffset(4);

    public static int Part2() => ReadFileToOffset(14);

    private static int ReadFileToOffset(int end)
    {
        var file = File.ReadAllText("Day6/input.txt");
        var start = 0;

        while (start + end < file.Length)
        {
            if (file.Substring(start, end).Distinct().Count() == end)
            {
                return start + end;
            }

            start++;
        }

        return 0;
    }
}