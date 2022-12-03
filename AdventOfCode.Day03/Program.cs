var rucksacks = File.ReadAllText("input.txt")
    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
    .ToList();

var priorities = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

long PartOne()
{
    return rucksacks
        .Select(rucksack =>
            new ValueTuple<string, string>(
                rucksack.Substring(0, rucksack.Length / 2),
                rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2)))
        .Select(compartments => compartments.Item1.Intersect(compartments.Item2))
        .Aggregate(0, (sum, commonItem) => sum + priorities.IndexOf(commonItem.First()) + 1);
}

long PartTwo()
{
    return rucksacks
        .Chunk(3)
        .Select(group => group[2].Intersect(group[1].Intersect(group[0])))
        .Aggregate(0, (sum, commonItem) => sum + priorities.IndexOf(commonItem.First()) + 1);
}

Console.WriteLine($"Part one: {PartOne()}");
Console.WriteLine($"Part two: {PartTwo()}");
