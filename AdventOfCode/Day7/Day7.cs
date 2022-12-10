namespace AdventOfCode.Day7;

public class Day7
{
    public static int Part1()
    {
        var directories = DoDay7();
        var total = directories.Where(x => x.Size < 100000).Sum(Y => Y.Size);
        return DoDay7().Where(x => x.Size < 100000).Sum(y => y.Size);
    }

    public static int Part2()
    {
        var directories = DoDay7();
        var available = 70000000 - directories.First(o => o.Path == "/").Size;
        return directories.Where(o => o.Size >= (30000000 - available)).Min(o => o.Size);
    }

    private static List<Directory> DoDay7()
    {
        Directory current = new()
        {
            Path = "/"
        };
        var directories = new List<Directory>
        {
            current
        };

        foreach (var line in File.ReadLines("Day7/input.txt"))
        {
            if (line.StartsWith("$"))
            {
                if (line.StartsWith("$ cd"))
                {
                    var folder = line.Split(" ").Last();
                    switch (folder)
                    {
                        case "/":
                            current = directories.First(x => x.Path is "/");
                            break;
                        case "..":
                        {
                            var split = current.Path.Split('/');
                            var path = $"/{string.Join('/', split.Take(split.Length - 1))}".Replace("//", "/");
                            current = directories.First(x => x.Path == path);
                            break;
                        }
                        default:
                            current = new Directory
                            {
                                Path = Path.Combine(current.Path, folder)
                            };
                            directories.Add(current);
                            break;
                    }
                }
            }
            else if (!line.StartsWith("dir"))
            {
                var size = int.Parse(line.Split(" ").First());
                foreach (var dir in directories.Where(x => current.Path.StartsWith(x.Path)))
                {
                    dir.Size += size;
                }
            }
        }

        return directories;
    }
}

class Directory
{
    public string Path { get; set; }
    public int Size { get; set; }
}