
namespace AdventOfCode.Day4;

public class Day4
{
    public static int Part1() =>
        (from line in File.ReadAllLines("Day4/input.txt")
            select line.Split(',')
            into split
            let left = split[0].Split('-').Select(int.Parse)
            let right = split[1].Split('-').Select(int.Parse)
            where (left.First() <= right.First() && left.Last() >= right.Last()) ||
                  (right.First() <= left.First() && right.Last() >= left.Last())
            select left).Count();

    public static int Part2() =>
        (from line in File.ReadAllLines("Day4/input.txt")
                .Select(x => x.Split(',')
                    .Select(y => y.Split('-')
                        .Select(int.Parse))
                    .SelectMany(z => z).ToList())
            let leftMin = line[0]
            let leftMax = line[1]
            let rightMin = line[2]
            let rightMax = line[3]
            where leftMin <= rightMax && rightMin <= leftMax
            select leftMin).Count();
}