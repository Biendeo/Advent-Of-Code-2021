namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 3, Name = "Binary Diagnostic")]
public class Day03 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] input) {
		int gammaRate = Convert.ToInt32(string.Concat(Enumerable.Range(0, input.First().Length).Select(index => IsMostCommonDigitInPositionOne(input, index) ? '1' : '0')), 2);
		int epsilonRate = (1 << input.First().Length) - 1 - gammaRate;
		return gammaRate * epsilonRate;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] input) {
		List<string> remainingOxygenNumbers = new(input), remainingCo2ScrubberNumbers = new(input);
		for (int i = 0; i < input.First().Length; ++i) {
			if (remainingOxygenNumbers.Count > 1) {
				char charToKeep = IsMostCommonDigitInPositionOne(remainingOxygenNumbers, i) ? '1' : '0';
				remainingOxygenNumbers.RemoveAll(s => s[i] != charToKeep);
			}
			if (remainingCo2ScrubberNumbers.Count > 1) {
				char charToRemove = IsMostCommonDigitInPositionOne(remainingCo2ScrubberNumbers, i) ? '1' : '0';
				remainingCo2ScrubberNumbers.RemoveAll(s => s[i] == charToRemove);
			}
		}
		return Convert.ToInt32(string.Concat(remainingOxygenNumbers.Single()), 2) * Convert.ToInt32(string.Concat(remainingCo2ScrubberNumbers.Single()), 2);
	}

	private bool IsMostCommonDigitInPositionOne(IEnumerable<string> values, int index) => values.Count(v => v[index] == '1') * 2 >= values.Count();
}