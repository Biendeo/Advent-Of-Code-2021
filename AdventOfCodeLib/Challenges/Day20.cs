namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 20, Name = "Trench Map")]
public class Day20 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) => EnhancedPixelCount(inputLines, 2);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => EnhancedPixelCount(inputLines, 50);

	private int EnhancedPixelCount(string[] inputLines, int passes) {
		(bool[] enhancement, HashSet<(int x, int y)> image) = ParseInput(inputLines);
		for (int i = 0; i < passes; ++i) {
			image = Enhance(enhancement, image, passes);
		}
		return image.Where(a => a.x >= (-1 * passes) && a.y >= (-1 * passes) && a.x < (inputLines[2].Length + 1 * passes) && a.y < (inputLines.Length - 2 + 1 * passes)).Count();
	}

	private HashSet<(int x, int y)> Enhance(bool[] enhancement, HashSet<(int x, int y)> image, int passes) {
		HashSet<(int x, int y)> newImage = new();
		Helper.GetTwoDimensionalRange(-200, 200, -200, 200).AsParallel().ForAll(a => {
			int foundNum = 0;
			foreach ((int y, int x) in Helper.GetTwoDimensionalRange(a.y - 1, a.y + 1, a.x - 1, a.x + 1)) {
				foundNum = foundNum * 2 + (image.Contains((x, y)) ? 1 : 0);
			}
			if (enhancement[foundNum]) {
				lock (newImage) {
					newImage.Add((a.x, a.y));
				}
			}
		});
		return newImage;
	}

	private (bool[] enhancement, HashSet<(int x, int y)> image) ParseInput(string[] inputLines) {
		HashSet<(int x, int y)> image = new();
		foreach ((int x, int y) in Helper.GetTwoDimensionalRange(0, inputLines[2].Length - 1, 0, inputLines.Length - 3)) {
			if (inputLines[y + 2][x] == '#') {
				image.Add((x, y));
			}
		}
		return (inputLines[0].Select(c => c == '#').ToArray(), image);
	}
}
