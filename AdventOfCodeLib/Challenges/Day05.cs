namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 5, Name = "Hydrothermal Venture")]
public class Day05 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) => GetIntersections(inputLines, false);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => GetIntersections(inputLines, true);

	private int GetIntersections(string[] inputLines, bool countDiagonals) {
		Dictionary<(int x, int y), int> linePositions = new();
		foreach ((int startX, int startY, int endX, int endY) in inputLines) {
			foreach ((int x, int y) in GetPointsWhereLineGoes(startX, startY, endX, endY, countDiagonals)) {
				if (!linePositions.ContainsKey((x, y))) {
					linePositions.Add((x, y), 0);
				}
				++linePositions[(x, y)];
			}
		}
		return linePositions.Count(keyValue => keyValue.Value > 1);
	}

	private List<(int x, int y)> GetPointsWhereLineGoes(int startX, int startY, int endX, int endY, bool enableDiagonals) {
		if (startX == endX) return Enumerable.Range(Math.Min(startY, endY), Math.Abs(endY - startY) + 1).Select(y => (startX, y)).ToList();
		if (startY == endY) return Enumerable.Range(Math.Min(startX, endX), Math.Abs(endX - startX) + 1).Select(x => (x, startY)).ToList();
		if (enableDiagonals && startX - endX == startY - endY) return Enumerable.Range(Math.Min(startX, endX), Math.Abs(endX - startX) + 1).Select(x => (x, startY + x - startX)).ToList();
		if (enableDiagonals && startX - endX == endY - startY) return Enumerable.Range(Math.Min(startX, endX), Math.Abs(endX - startX) + 1).Select(x => (x, startY - x + startX)).ToList();
		return new();
	}
}

internal static class Day05Extensions {
	public static void Deconstruct(this string line, out int a0, out int a1, out int a2, out int a3) {
		int[] values = line.Replace(" -> ", ",").Split(',').Select(x => int.Parse(x)).ToArray();
		a0 = values[0];
		a1 = values[1];
		a2 = values[2];
		a3 = values[3];
	}
}
