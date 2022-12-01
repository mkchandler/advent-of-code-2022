string input = File.ReadAllText("input.txt");

long PartOne()
{
    long highestCalories = input
        .Split("\n\n")
        .Select(elf => elf
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(0L, (acc, value) => acc + long.Parse(value)))
        .Max();

    return highestCalories;
}

long PartTwo()
{
    long highestThreeElves = input
        .Split("\n\n")
        .Select(elf => elf
            .Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(0L, (acc, value) => acc + long.Parse(value)))
        .OrderDescending()
        .Take(3)
        .Sum();

    return highestThreeElves;
}

Console.WriteLine($"Part one: {PartOne()}");
Console.WriteLine($"Part two: {PartTwo()}");
