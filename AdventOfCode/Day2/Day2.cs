namespace AdventOfCode.Day2;

public class Day2
{
    public static int Part1() =>
                 File.ReadLines("Day2/input.txt")
            .Select(x => x.Split(' '))
            .Select(readLine => readLine switch
            {
                ["A", _] => readLine[1] switch
                {
                    "X" => 4,
                    "Y" => 8,
                    "Z" => 3
                },
                ["B", _] => readLine[1] switch
                {
                    "X" => 1,
                    "Y" => 5,
                    "Z" => 9
                },
                ["C", _] => readLine[1] switch
                {
                    "X" => 7,
                    "Y" => 2,
                    "Z" => 6
                }
            })
            .ToList().Sum();

    public static int Part2() =>
        File.ReadLines("Day2/input.txt")
            .Select(x => x.Split(' '))
            .Select(readLine => readLine switch
            {
                ["A", _] => readLine[1] switch
                {
                    "X" => 3,
                    "Y" => 4,
                    "Z" => 8
                },
                ["B", _] => readLine[1] switch
                {
                    "X" => 1,
                    "Y" => 5,
                    "Z" => 9
                },
                ["C", _] => readLine[1] switch
                {
                    "X" => 2,
                    "Y" => 6,
                    "Z" => 7
                }
            })
            .ToList().Sum();
}