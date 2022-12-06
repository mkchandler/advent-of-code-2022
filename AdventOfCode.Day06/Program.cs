var input = File.ReadAllText("input.txt");

int PartOne()
{
    return FindStartOfPacketMarker(4);
}

int PartTwo()
{
    return FindStartOfPacketMarker(14);
}

int FindStartOfPacketMarker(int chunks)
{
    for (int i = 0; i < input.Length - chunks; i++)
    {
        List<char> chars = new(input[i..(i + chunks)]);

        if (chars.Distinct().Count() == chunks)
        {
            return i + chunks;
        }
    }

    return -1;
}

Console.WriteLine($"Part one: {PartOne()}");
Console.WriteLine($"Part two: {PartTwo()}");
