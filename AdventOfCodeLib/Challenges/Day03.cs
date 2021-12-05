namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 3, Name = "Binary Diagnostic")]
public class Day03 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] input) {
		int gammaRate = BinaryToInt(Enumerable.Range(0, input.First().Length).Select(index => IsMostCommonDigitInPositionOne(input, index) ? '1' : '0'));
		int epsilonRate = (1 << input.First().Length) - 1 - gammaRate;
		return gammaRate * epsilonRate;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] input) => GetRating(input, true) * GetRating(input, false);

	private static int GetRating(string[] input, bool keepMostCommon) {
		List<string> remainingNumbers = new(input);
		for (int i = 0; i < input.First().Length && remainingNumbers.Count > 1; ++i) {
			bool mostCommonDigitIsOne = IsMostCommonDigitInPositionOne(remainingNumbers, i);
			remainingNumbers.RemoveAll(s => s[i] == '1' != mostCommonDigitIsOne == keepMostCommon);
		}
		return BinaryToInt(remainingNumbers.Single());
	}

	private static bool IsMostCommonDigitInPositionOne(IEnumerable<string> values, int index) => values.Count(v => v[index] == '1') * 2 >= values.Count();
	private static int BinaryToInt(IEnumerable<char> s) => Convert.ToInt32(string.Concat(s), 2);
}
