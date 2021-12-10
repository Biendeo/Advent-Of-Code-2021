namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 10, Name = "Syntax Scoring")]
public class Day10 : IDayChallenge {
	private static Dictionary<char, char> OpeningClosingBracePairs = new() {
		{ '(', ')' },
		{ '[', ']' },
		{ '{', '}' },
		{ '<', '>' }
	};
	
	private static Dictionary<char, long> ClosingBraceToIllegalScore = new() {
		{ ')', 3 },
		{ ']', 57 },
		{ '}', 1197 },
		{ '>', 25137 }
	};

	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public long PartOne(string[] inputLines) => inputLines.Sum(l => IllegalLineScore(l));

	private long IllegalLineScore(string line) {
		Stack<char> seenBrackets = new();
		foreach (char c in line) {
			if (OpeningClosingBracePairs.ContainsKey(c)) {
				seenBrackets.Push(c);
			} else if (seenBrackets.TryPeek(out char x) && OpeningClosingBracePairs[x] != c) {
				return ClosingBraceToIllegalScore[c];
			} else {
				seenBrackets.Pop();
			}
		}
		return 0;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public long PartTwo(string[] inputLines) {
		List<long> scores = inputLines.Where(l => IllegalLineScore(l) == 0).Select(l => IncompleteLineScore(l)).OrderBy(x => x).ToList();
		return scores[scores.Count() / 2];
	}

	private long IncompleteLineScore(string line) {
		Stack<char> seenBrackets = new();
		long score = 0;
		foreach (char c in line) {
			if (OpeningClosingBracePairs.ContainsKey(c)) {
				seenBrackets.Push(c);
			} else {
				seenBrackets.Pop();
			}
		}
		while (seenBrackets.Any()) {
			char nextBracket = seenBrackets.Pop();
			score = score * 5 + OpeningClosingBracePairs.Values.ToList().IndexOf(OpeningClosingBracePairs[nextBracket]) + 1;
		}
		return score;
	}
}
