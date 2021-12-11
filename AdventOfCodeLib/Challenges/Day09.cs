namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 9, Name = "Smoke Basin")]
public class Day09 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) => Helper.GetTwoDimensionalRange(0, inputLines.First().Length - 1, 0, inputLines.Length - 1)
		.Sum(a => Helper.GetNeighbors(a.x, a.y, 0, inputLines.First().Length - 1, 0, inputLines.Length - 1, false).All(b => inputLines[b.y][b.x] > inputLines[a.y][a.x]) ? inputLines[a.y][a.x] - '0' + 1 : 0);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) {
		HashSet<(int x, int y)> seenPositions = new();
		return Helper.GetTwoDimensionalRange(0, inputLines.First().Length - 1, 0, inputLines.Length - 1)
			.Select(a => SizeOfBasin(a.x, a.y, inputLines, seenPositions))
			.OrderByDescending(x => x)
			.Take(3)
			.Aggregate(1, (acc, x) => acc * x);
	}

	private int SizeOfBasin(int x, int y, string[] inputLines, HashSet<(int x, int y)> seenPositions) {
		if (inputLines[y][x] == '9' || seenPositions.Contains((x, y))) return 0;
		seenPositions.Add((x, y));
		return Helper.GetNeighbors(x, y, 0, inputLines.First().Length - 1, 0, inputLines.Length - 1, false).Sum(b => SizeOfBasin(b.x, b.y, inputLines, seenPositions)) + 1;
	}
}
