namespace AdventOfCode.Day9;

using static Enumerable;

public class Day9
{
    public static int Part1() => DoDay9(1);
    public static int Part2() => DoDay9(9);

    private static int DoDay9(int offset)
    {
        var points = new List<Point>(Range(0, 10).Select(_ => new Point()));
        var visited = new Dictionary<Point, bool>();
        File.ReadAllLines("Day9/input.txt")
            .Select(x => x.Split(' '))
            .Select(x => (direction: x[0], distance: int.Parse(x[1])))
            .ToList()
            .ForEach(command => Range(0, command.distance)
                .ToList()
                .ForEach(_ =>
                {
                    Action<Point> move = command.direction switch
                    {
                        "L" => point => point.X -= 1,
                        "R" => point => point.X += 1,
                        "U" => point => point.Y += 1,
                        "D" => point => point.Y -= 1,
                    };
                    move(points.First());
                    points.Adjust();
                    visited[points[offset]] = true;
                }));
        return visited.Count;
    }
}

internal record Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

internal static class Extensions
{
    public static void Adjust(this List<Point> points) =>
        Range(1, 9).ToList()
            .Where(z => Math.Abs(points[z - 1].X - points[z].X) > 1 || Math.Abs(points[z - 1].Y - points[z].Y) > 1)
            .ToList().ForEach(x =>
            {
                points[x].X += Math.Min(Math.Max(-1, points[x - 1].X - points[x].X), 1);
                points[x].Y += Math.Min(Math.Max(-1, points[x - 1].Y - points[x].Y), 1);
            });
}