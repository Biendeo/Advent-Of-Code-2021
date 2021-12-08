namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 8, Name = "Seven Segment Search")]
public class Day08 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public readonly static int[] EdgesInOneFourSevenAndEight = { 2, 3, 4, 7 };

	public int PartOne(string[] inputLines) => ParseInput(inputLines).Sum(s => s.digits.Count(d => EdgesInOneFourSevenAndEight.Contains(d.Length)));

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => ParseInput(inputLines).Sum(s => {
		List<string> signalToDigits = Enumerable.Repeat("not found", 10).ToList();
		foreach ((int index, Func<string, bool> predicate) in new List<(int index, Func<string, bool> predicate)> {
			(1, signal => signal.Length == 2),
			(4, signal => signal.Length == 4),
			(7, signal => signal.Length == 3),
			(8, signal => signal.Length == 7),
			(3, signal => signal.Length == 5 && signalToDigits[7].All(c => signal.Contains(c))),
			(9, signal => signal.Length == 6 && signalToDigits[4].All(c => signal.Contains(c))),
			(6, signal => signal.Length == 6 && signalToDigits[1].Any(c => !signal.Contains(c))),
			(0, signal => signal.Length == 6 && !signalToDigits.Contains(signal)),
			(5, signal => signal.Length == 5 && signal != signalToDigits[3] && signal.All(c => signalToDigits[6].Contains(c))),
			(2, signal => signal.Length == 5 && signal != signalToDigits[3] && signal != signalToDigits[5])
		}) AssignIntoDigits(signalToDigits, s.signals, index, predicate);
		return signalToDigits.IndexOf(s.digits[0]) * 1000 + signalToDigits.IndexOf(s.digits[1]) * 100 + signalToDigits.IndexOf(s.digits[2]) * 10 + signalToDigits.IndexOf(s.digits[3]);
	});

	private IEnumerable<(string[] signals, string[] digits)> ParseInput(string[] inputLines) => inputLines.Select(s => (signals: s.Split(" | ")[0].Split(' ').Select(s => UnshuffleString(s)).ToArray(), digits: s.Split(" | ")[1].Split(' ').Select(s => UnshuffleString(s)).ToArray()));

	private string UnshuffleString(string s) => string.Concat(s.OrderBy(c => c));

	private void AssignIntoDigits(List<string> signalToDigits, string[] signals, int index, Func<string, bool> predicate) => signalToDigits[index] = signals.Single(predicate);
}
