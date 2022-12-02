string input = File.ReadAllText("input.txt");

IEnumerable<(string Opponent, string Self)> rounds = input
    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
    .Select(l => l.Split(' '))
    .Select(r => new ValueTuple<string, string>(r[0], r[1]))
    .ToList();

long PartOne()
{
    int totalScore = 0;

    foreach ((string opponent, string self) in rounds)
    {
        totalScore += (opponent, self) switch
        {
            ("A", "X") => 4,
            ("A", "Y") => 8,
            ("A", "Z") => 3,
            ("B", "X") => 1,
            ("B", "Y") => 5,
            ("B", "Z") => 9,
            ("C", "X") => 7,
            ("C", "Y") => 2,
            ("C", "Z") => 6,
            _ => 0
        };
    }

    return totalScore;
}

long PartTwo()
{
    int totalScore = 0;

    foreach ((string opponent, string self) in rounds)
    {
        totalScore += (opponent, self) switch
        {
            ("A", "X") => 3,
            ("A", "Y") => 4,
            ("A", "Z") => 8,
            ("B", "X") => 1,
            ("B", "Y") => 5,
            ("B", "Z") => 9,
            ("C", "X") => 2,
            ("C", "Y") => 6,
            ("C", "Z") => 7,
            _ => 0
        };
    }

    return totalScore;
}

Console.WriteLine($"Part one: {PartOne()}");
Console.WriteLine($"Part two: {PartTwo()}");
