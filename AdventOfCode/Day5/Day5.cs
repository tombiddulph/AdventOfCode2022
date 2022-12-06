using System.Text.RegularExpressions;

namespace AdventOfCode.Day5;

public class Day5
{
    public static string Part1() => GetDay5Result(File.ReadAllLines("Day5/input.txt"), false);

    public static string Part2() => GetDay5Result(File.ReadAllLines("Day5/input.txt"), true);

    private static string GetDay5Result(string[] lines, bool inOrder)
    {
        
        var craneCOunt = (int)Math.Ceiling(lines[0].Length / 4.0);
        var cranes = new List<char>[craneCOunt];
        for (var i = 0; i < craneCOunt; i++)
        {
            cranes[i] = new List<char>();
        }
        

        // cranes
        var l = 0;
        for ( ; l < lines.Length && lines[l][1] != '1'; l++)
        {
            var line = lines[l];
            var crane = 0;
            foreach(var crate in line.Chunk(4).Select(x => x[1]))
            {
                if (crate != ' ')
                {
                    cranes[crane].Add(crate);
                }
                crane++;
            }
        }

        // instructions
        l += 2;
        for ( ; l < lines.Length; l++)
        {
            var line = lines[l];
            var parts = line.Split(' ');
            var count = int.Parse(parts[1]);
            var from = cranes[int.Parse(parts[3]) - 1];
            var to = cranes[int.Parse(parts[5]) - 1];

            if (inOrder)
            {
                to.InsertRange(0, from.Take(count));
            }
            else
            {
                for (var j = 0; j < count; j++)
                {
                    to.Insert(0, from[j]);
                }
            }
            from.RemoveRange(0, count);
        }

        // the code
        return string.Join("", cranes.Select(x => x[0]));
    }
}