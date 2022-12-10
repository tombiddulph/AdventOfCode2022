namespace AdventOfCode.Day8;

public class Day8
{
    public static int Part1()
    {
        var file = File.ReadLines("Day8/input.txt").ToList();
        var trees = LoadTrees(file);
        
        return trees.Sum(tree => trees switch
        {
            _ when tree.Key.x is 0 && tree.Key.y is 0 => 1,
            _ when trees.Where(x => Top(x, tree)).All(x => LessThanCurrent(x, tree)) => 1,
            _ when trees.Where(x => Bottom(x, tree)).All(x => LessThanCurrent(x, tree)) => 1,
            _ when trees.Where(x => Left(x, tree)).All(x => LessThanCurrent(x, tree)) => 1,
            _ when trees.Where(x => Right(x, tree)).All(x => LessThanCurrent(x, tree)) => 1,
            _ => 0
        });
    }


    private static bool Top(KeyValuePair<(int x, int y), int> a, KeyValuePair<(int x, int y), int> b) =>
        a.Key.x == b.Key.x && a.Key.y < b.Key.y;

    private static bool Bottom(KeyValuePair<(int x, int y), int> a, KeyValuePair<(int x, int y), int> b) =>
        a.Key.x == b.Key.x && a.Key.y > b.Key.y;

    private static bool Left(KeyValuePair<(int x, int y), int> a, KeyValuePair<(int x, int y), int> b) =>
        a.Key.y == b.Key.y && a.Key.x < b.Key.x;

    private static bool Right(KeyValuePair<(int x, int y), int> a, KeyValuePair<(int x, int y), int> b) =>
        a.Key.y == b.Key.y && a.Key.x > b.Key.x;

    private static bool LessThanCurrent(KeyValuePair<(int x, int y), int> a, KeyValuePair<(int x, int y), int> b) =>
        a.Value < b.Value;

    public static int Part2()
    {
        var file = File.ReadLines("Day8/input.txt").ToList();
        var trees = LoadTrees(file);
        var height = file[0].Length;
        var width = file.Count;

        var score = 0;

        foreach (var (key, value) in trees)
        {
            int left = 0, right = 0, top = 0, bottom = 0;

            var x = key.x - 1;
            var y = key.y;

            var left2 = Enumerable.Range(x, 0).Where(z => trees[(z, y)] < value);
            while (x >= 0) //look left
            {
                var t = trees[(x, y)];
                left += 1;

                if (t >= value) break;
                x--;
            }

            x = key.x + 1;

            while (x < width) //look right
            {
                var t = trees[(x, y)];
                right += 1;

                if (t >= value) break;
                x++;
            }

            x = key.x;
            y = key.y - 1;

            while (y >= 0) //look up
            {
                var t = trees[(x, y)];
                top += 1;

                if (t >= value) break;
                y--;
            }

            y = key.y + 1;

            while (y < height)
            {
                var t = trees[(x, y)];
                bottom += 1;

                if (t >= value) break;
                y++;
            }

            score = Math.Max(score, left * right * top * bottom);
        }

        return score;
    }


    private static Dictionary<(int x, int y), int> LoadTrees(IReadOnlyList<string> file)
    {
        var trees = new Dictionary<(int x, int y), int>();
        for (var i = 0; i < file.Count; i++)
        {
            var line = file[i];
            for (var j = 0; j < line.Length; j++)
            {
                trees[(i, j)] = line[j] - '0';
            }
        }
        return trees;
    }
}