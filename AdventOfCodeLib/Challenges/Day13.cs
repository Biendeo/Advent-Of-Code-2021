using System.Text;

namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 13, Name = "Transparent Origami")]
public class Day13 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		(HashSet<(int x, int y)> dots, List<(bool xFold, int value)> folds) = ParseInput(inputLines);
		return Fold(dots, folds.First().xFold, folds.First().value).Count;
	}

	private (HashSet<(int x, int y)> dots, List<(bool xFold, int value)> folds) ParseInput(string[] inputLines) {
		HashSet<(int x, int y)> dots = new();
		List<(bool xFold, int value)> folds = new();
		bool blankLine = false;
		foreach (string line in inputLines) {
			if (line == string.Empty) blankLine = true;
			else if (!blankLine) dots.Add((int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1])));
			else folds.Add((line[11] == 'x', int.Parse(line[13..])));
		}
		return (dots, folds);
	}

	private HashSet<(int x, int y)> Fold(HashSet<(int x, int y)> dots, bool xFold, int value) =>
		new HashSet<(int x, int y)>(dots.Select(d => xFold ? (d.x > value ? (2 * value) - d.x : d.x, d.y) : (d.x, d.y > value ? (2 * value) - d.y : d.y)));

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines);

	public string PartTwo(string[] inputLines) {
		(HashSet<(int x, int y)> dots, List<(bool xFold, int value)> folds) = ParseInput(inputLines);
		foreach ((bool xFold, int value) in folds) {
			dots = Fold(dots, xFold, value);
		}
		StringBuilder sb = new();
		int maxX = dots.Max(d => d.x);
		int maxY = dots.Max(d => d.y);
		for (int y = 0; y <= maxY; ++y) {
			for (int x = 0; x <= maxX; ++x) {
				sb.Append(dots.Contains((x, y)) ? '#' : ' ');
			}
			if (y != maxY) sb.AppendLine();
		}
		return sb.ToString();
	}
}
