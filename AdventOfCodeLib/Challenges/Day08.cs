namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 8, Name = "Seven Segment Search")]
public class Day08 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public readonly static int[] EdgesInOneFourSevenAndEight = { 2, 3, 4, 7 };

	public int PartOne(string[] inputLines) => ParseInput(inputLines).Sum(s => s.digits.Count(d => EdgesInOneFourSevenAndEight.Contains(d.Length)));

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => ParseInput(inputLines).Sum(row => {
		List<string> signalToDigits = Enumerable.Repeat("not found", 10).ToList();
		foreach ((int index, Func<string, bool> predicate) in new List<(int index, Func<string, bool> predicate)> {
			(1, s => s.Length == 2),
			(4, s => s.Length == 4),
			(7, s => s.Length == 3),
			(8, s => s.Length == 7),
			(3, s => s.Length == 5 && signalToDigits[7].All(c => s.Contains(c))),
			(9, s => s.Length == 6 && signalToDigits[4].All(c => s.Contains(c))),
			(6, s => s.Length == 6 && signalToDigits[1].Any(c => !s.Contains(c))),
			(0, s => s.Length == 6 && !signalToDigits.Contains(s)),
			(5, s => s.Length == 5 && s != signalToDigits[3] && s.All(c => signalToDigits[6].Contains(c))),
			(2, s => s.Length == 5 && s != signalToDigits[3] && s != signalToDigits[5])
		}) AssignIntoDigits(signalToDigits, row.signals, index, predicate);
		return row.digits.Select((digit, i) => (digit, i)).Sum(x => signalToDigits.IndexOf(x.digit) * new[] { 1000, 100, 10, 1 }[x.i]);
	});

	private IEnumerable<(string[] signals, string[] digits)> ParseInput(string[] inputLines) => inputLines.Select(s => (signals: s.Split(" | ")[0].Split(' ').Select(s => UnshuffleString(s)).ToArray(), digits: s.Split(" | ")[1].Split(' ').Select(s => UnshuffleString(s)).ToArray()));

	private string UnshuffleString(string s) => string.Concat(s.OrderBy(c => c));

	private void AssignIntoDigits(List<string> signalToDigits, string[] signals, int index, Func<string, bool> predicate) => signalToDigits[index] = signals.Single(predicate);
}
