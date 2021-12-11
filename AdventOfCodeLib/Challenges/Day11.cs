namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 11, Name = "Dumbo Octopus")]
public class Day11 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		int[,] map = ParseMap(inputLines);
		return Enumerable.Range(0, 100).Sum(x => Step(map));
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) {
		int[,] map = ParseMap(inputLines);
		int step;
		for (step = 1; Step(map) != map.GetLength(0) * map.GetLength(1); ++step) {}
		return step;
	}

	private int[,] ParseMap(string[] inputLines) {
		int[,] map = new int[inputLines.First().Length, inputLines.Length];
		foreach ((int x, int y) in Helper.GetTwoDimensionalRange(0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1)) {
			map[x, y] = inputLines[y][x] - '0';
		}
		return map;
	}

	private int Step(int[,] map) {
		bool[,] hasFlashed = new bool[map.GetLength(0), map.GetLength(1)];
		int flashes = 0;

		foreach ((int x, int y) in Helper.GetTwoDimensionalRange(0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1)) {
			++map[x, y];
		}

		bool hasFlashedThisPass;
		do {
			hasFlashedThisPass = false;
			foreach ((int x, int y) in Helper.GetTwoDimensionalRange(0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1)) {
				if (!hasFlashed[x, y] && map[x, y] > 9) {
					foreach ((int nx, int ny) in Helper.GetNeighbors(x, y, 0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1, true)) {
						++map[nx, ny];
					}
					hasFlashed[x, y] = true;
					++flashes;
					hasFlashedThisPass = true;
				}
			}
		} while (hasFlashedThisPass);

		foreach ((int x, int y) in Helper.GetTwoDimensionalRange(0, map.GetLength(0) - 1, 0, map.GetLength(1) - 1)) {
			if (hasFlashed[x, y]) map[x, y] = 0;
		}

		return flashes;
	}
}
