using System.Reflection;

Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Name.StartsWith("Day"))
    .Select(x => x.GetMethods().Where(y => y.Name is "Part1" or "Part2")).SelectMany(z => z).ToList().ForEach(m =>
        Console.WriteLine($"{m.DeclaringType!.Name} {m.Name} result: {m.Invoke(null, null)}"));