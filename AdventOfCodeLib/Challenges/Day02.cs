namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 2, Name = "Dive!")]
public class Day02 : IDayChallenge {
	private delegate (int x, int y, int aim) Operation(int mangitude, int x, int y, int aim);

	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) => FindSolution(inputLines, partOneActions);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => FindSolution(inputLines, partTwoActions);

	private static readonly Dictionary<string, Operation> partOneActions = new() {
		{ "up", (magnitude, x, y, aim) => (x, y - magnitude, aim) },
		{ "forward", (magnitude, x, y, aim) => (x + magnitude, y, aim) },
		{ "down", (magnitude, x, y, aim) => (x, y + magnitude, aim) }
	};

	private static readonly Dictionary<string, Operation> partTwoActions = new() {
		{ "up", (magnitude, x, y, aim) => (x, y, aim - magnitude) },
		{ "forward", (magnitude, x, y, aim) => (x + magnitude, y + magnitude * aim, aim) },
		{ "down", (magnitude, x, y, aim) => (x, y, aim + magnitude) }
	};

	private int FindSolution(string[] inputLines, Dictionary<string, Operation> actions) {
		int x = 0, y = 0, aim = 0;
		foreach ((string direction, int magnitude) in inputLines.Select(l => (l.Split(' ')[0], int.Parse(l.Split(' ')[1])))) {
			(x, y, aim) = actions[direction](magnitude, x, y, aim);
		}
		return Math.Abs(x * y);
	}
}
