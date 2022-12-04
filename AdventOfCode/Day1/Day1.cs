namespace AdventOfCode.Day1;

public static class Day1
{
    public static int Part1() =>
        File.ReadAllText("Day1/input.txt")
            .Split("\n\n")
            .Select(s => s.Split('\n').Select(int.Parse).Sum())
            .Max();
    
    public static int Part2() =>  File.ReadAllText("Day1/input.txt")
        .Split("\n\n")
        .Select(s => s.Split('\n').Select(int.Parse).Sum())
        .OrderDescending()
        .Take(3)
        .Sum();
}