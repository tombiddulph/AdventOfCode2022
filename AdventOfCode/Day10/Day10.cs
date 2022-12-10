namespace AdventOfCode.Day10;

public class Day10
{
    public static int Part1() =>
        File.ReadLines("Day10/input.txt").Select(x => x.Split(' '))
            .Select(x => (command: x[0], val: x.Length == 2 ? int.Parse(x[1]) : 0))
            .Aggregate((dict: new Dictionary<int, int> {[0] = 0}, val: 1), (acc, instruction) =>
                (instruction.command is "addx"
                    ? (Func<(Dictionary<int, int>, int)>) (() =>
                    {
                        var curr = acc.dict.Keys.Max();
                        acc.dict[++curr] = acc.val;
                        acc.dict[++curr] = acc.val;
                        acc.val += instruction.val;
                        return acc;
                    })
                    : () =>
                    {
                        acc.dict[acc.dict.Keys.Max() + 1] = acc.val;
                        return acc;
                    })()).dict.Aggregate((cycles: new[] {20, 60, 100, 140, 180, 220}, val: 0), (acc, pair) =>
                (acc.cycles.Contains(pair.Key)
                    ? (Func<(int[], int)>) (() =>
                    {
                        acc.val += pair.Key * pair.Value;
                        return acc;
                    })
                    : () => acc)()).val;


    public static string Part2() =>
        "\n" + string.Join("\n", File.ReadLines("Day10/input.txt").Select(x => x.Split(' '))
            .Select(x => (command: x[0], val: x.Length == 2 ? int.Parse(x[1]) : 0)).Aggregate(
                (display: "", crtPos: 0, strPos: 0),
                (acc, instruction) =>
                {
                    acc.display += new string(Enumerable.Range(0, instruction.command is "addx" ? 2 : 1).Select(_ =>
                            acc.crtPos++ % 40 >= acc.strPos && (acc.crtPos - 1) % 40 <= acc.strPos + 2 ? '#' : '.')
                        .ToArray());
                    acc.strPos += instruction.val;
                    return acc;
                }).display.Chunk(40).Select(x => new string(x)));
}