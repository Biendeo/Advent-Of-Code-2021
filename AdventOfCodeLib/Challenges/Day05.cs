namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 5, Name = "Hydrothermal Venture")]
public class Day05 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) => GetIntersections(inputLines, false);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => GetIntersections(inputLines, true);

	private int GetIntersections(string[] inputLines, bool countDiagonals) {
		Dictionary<(int x, int y), int> linePositions = new();
		foreach (int[] lineCoords in inputLines.Select(line => line.Replace(" -> ", ",").Split(',').Select(x => int.Parse(x)).ToArray())) {
			foreach ((int x, int y) in GetPointsWhereLineGoes(lineCoords[0], lineCoords[1], lineCoords[2], lineCoords[3], countDiagonals)) {
				linePositions.TryGetValue((x, y), out int oldValue);
				linePositions[(x, y)] = oldValue + 1;
			}
		}
		return linePositions.Count(keyValue => keyValue.Value > 1);
	}

	private List<(int x, int y)> GetPointsWhereLineGoes(int startX, int startY, int endX, int endY, bool enableDiagonals) {
		if (startX == endX) return Enumerable.Range(Math.Min(startY, endY), Math.Abs(endY - startY) + 1).Select(y => (startX, y)).ToList();
		if (startY == endY) return Enumerable.Range(Math.Min(startX, endX), Math.Abs(endX - startX) + 1).Select(x => (x, startY)).ToList();
		if (enableDiagonals && Math.Abs(startX - endX) == Math.Abs(startY - endY))
			return Enumerable.Range(Math.Min(startX, endX), Math.Abs(endX - startX) + 1).Select(x => (x, startY + (x - startX) * (startX - endX + startY - endY != 0 ? 1 : -1))).ToList();
		return new();
	}
}
