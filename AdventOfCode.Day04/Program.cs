var pairs = File.ReadAllText("input.txt")
    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
    .Select(l => l.Split(',')
        .Select(e => e.Split('-')
                .Select(int.Parse).ToArray())
        .ToArray())
    .Select(elves => new ValueTuple<IEnumerable<int>, IEnumerable<int>>(
            Enumerable.Range(elves[0][0], elves[0][1] - elves[0][0] + 1),
            Enumerable.Range(elves[1][0], elves[1][1] - elves[1][0] + 1)))
    .ToList();

int PartOne()
{
    return pairs
        .Select(p =>
            new ValueTuple<int, int>(
                p.Item1.Intersect(p.Item2).Count(),
                int.Min(p.Item1.Count(), p.Item2.Count())))
        .Aggregate(0, (acc, count) => acc + (count.Item1 == count.Item2 ? 1 : 0));
}

int PartTwo()
{
    return pairs
        .Select(p => p.Item1.Intersect(p.Item2).Count())
        .Aggregate(0, (acc, count) => acc + (count > 0 ? 1 : 0));
}

Console.WriteLine($"Part one: {PartOne()}");
Console.WriteLine($"Part two: {PartTwo()}");
