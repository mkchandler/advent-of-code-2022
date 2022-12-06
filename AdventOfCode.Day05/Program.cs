var input = File.ReadAllText("input.txt")
    .Split("\n\n")
    .ToList();

var partOneStacks = CreateStacks();
var partTwoStacks = CreateStacks();

Stack<char>[] CreateStacks()
{
    var stacks = new Stack<char>[9];
    stacks[0] = new Stack<char>("SZPDLBFC".ToCharArray());
    stacks[1] = new Stack<char>("NVGPHWB".ToCharArray());
    stacks[2] = new Stack<char>("FWBJG".ToCharArray());
    stacks[3] = new Stack<char>("GJNFLWCS".ToCharArray());
    stacks[4] = new Stack<char>("WJLTPMSH".ToCharArray());
    stacks[5] = new Stack<char>("BCWGFS".ToCharArray());
    stacks[6] = new Stack<char>("HTPMQBW".ToCharArray());
    stacks[7] = new Stack<char>("FSWT".ToCharArray());
    stacks[8] = new Stack<char>("NCR".ToCharArray());
    return stacks;
}

var commands = input
    .Skip(1)
    .First()
    .Split('\n', StringSplitOptions.RemoveEmptyEntries)
    .Select(c => new Command(int.Parse(c[5..7]), int.Parse(c[12..14]) - 1, int.Parse(c[17..]) - 1))
    .ToList();

string PartOne()
{
    commands.ForEach(c =>
        Enumerable.Range(0, c.Move).ToList()
            .ForEach(_ => partOneStacks[c.To].Push(partOneStacks[c.From].Pop())));

    return partOneStacks.Aggregate(string.Empty, (acc, current) => acc + current.Peek());
}

string PartTwo()
{
    commands.ForEach(c =>
        Enumerable.Range(0, c.Move).ToList()
            .Select(_ => partTwoStacks[c.From].Pop())
            .Reverse()
            .ToList()
            .ForEach(from => partTwoStacks[c.To].Push(from)));

    return partTwoStacks.Aggregate(string.Empty, (acc, current) => acc + current.Peek());
}

Console.WriteLine($"Part one: {PartOne()}");
Console.WriteLine($"Part two: {PartTwo()}");

public record Command(int Move, int From, int To);
