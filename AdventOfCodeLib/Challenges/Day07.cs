namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 7, Name = "The Treachery of Whales")]
public class Day07 : IDayChallenge {
	private const int HopefullyLargestCrabDistance = 2000;

	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines.Single().Split(',').Select(x => int.Parse(x)).ToArray()).ToString();

	public int PartOne(int[] input) => Enumerable.Range(0, input.Max() + 1).Select(x => input.Sum(y => Math.Abs(x - y))).Min();

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines.Single().Split(',').Select(x => int.Parse(x)).ToArray()).ToString();

	private int[] TriangleNumbers = Enumerable.Range(0, HopefullyLargestCrabDistance).Select(x => Enumerable.Range(1, x).Sum()).ToArray();

	public int PartTwo(int[] input) => Enumerable.Range(0, input.Max() + 1).Select(x => input.Sum(y => TriangleNumbers[Math.Abs(x - y)])).Min();
}
