namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 10, Name = "Syntax Scoring")]
public class Day10 : IDayChallenge {
	private static readonly List<char> OpeningBraces = new() { '(', '[', '{', '<' };
	private static readonly List<char> ClosingBraces = new() { ')', ']', '}', '>' };
	private static readonly Dictionary<char, int> IllegalScores = ClosingBraces.Zip(new[] { 3, 57, 1197, 25137 }).ToDictionary(c => c.First, c => c.Second);

	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public long PartOne(string[] inputLines) => inputLines.Sum(l => IllegalLineScore(l));

	private char GetClosingBrace(char c) => ClosingBraces[OpeningBraces.IndexOf(c)];

	private long IllegalLineScore(string line) {
		Stack<char> seenBrackets = new();
		foreach (char c in line) {
			if (OpeningBraces.Contains(c)) {
				seenBrackets.Push(c);
			} else if (seenBrackets.TryPeek(out char x) && GetClosingBrace(x) != c) {
				return IllegalScores[c];
			} else {
				seenBrackets.Pop();
			}
		}
		return 0;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public long PartTwo(string[] inputLines) {
		List<long> scores = inputLines.Where(l => IllegalLineScore(l) == 0).Select(l => IncompleteLineScore(l)).OrderBy(x => x).ToList();
		return scores[scores.Count / 2];
	}

	private long IncompleteLineScore(string line) {
		Stack<char> seenBrackets = new();
		long score = 0;
		foreach (char c in line) {
			if (OpeningBraces.Contains(c)) {
				seenBrackets.Push(c);
			} else {
				seenBrackets.Pop();
			}
		}
		while (seenBrackets.Any()) {
			char nextBracket = seenBrackets.Pop();
			score = score * 5 + OpeningBraces.IndexOf(nextBracket) + 1;
		}
		return score;
	}
}
