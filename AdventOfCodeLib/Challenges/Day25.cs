namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 25, Name = "Sea Cucumber")]
public class Day25 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		int generations = 0;
		bool hasMoved = true;
		char[,] flow = new char[inputLines[0].Length, inputLines.Length];
		for (int i = 0; i < inputLines.Length * inputLines[0].Length; ++i) flow[i % inputLines[0].Length, i / inputLines[0].Length] = inputLines[i / inputLines[0].Length][i % inputLines[0].Length];
		while (hasMoved) {
			hasMoved = false;
			char[,] newFlow = (char[,])flow.Clone();
			++generations;
			for (int y = 0; y < inputLines.Length; ++y) {
				for (int x = 0; x < inputLines[0].Length; ++x) {
					if (flow[x, y] == '>' && flow[(x + 1) % inputLines[0].Length, y] == '.') {
						newFlow[x, y] = '.';
						newFlow[(x + 1) % inputLines[0].Length, y] = '>';
						++x;
						hasMoved = true;
					}
				}
			}
			flow = newFlow;
			newFlow = (char[,])flow.Clone();
			for (int x = 0; x < inputLines[0].Length; ++x) {
				for (int y = 0; y < inputLines.Length; ++y) {
					if (flow[x, y] == 'v' && flow[x, (y + 1) % inputLines.Length] == '.') {
						newFlow[x, y] = '.';
						newFlow[x, (y + 1) % inputLines.Length] = 'v';
						++y;
						hasMoved = true;
					}
				}
			}
			flow = newFlow;
		}
		return generations;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public string PartTwo(string[] inputLines) => "The End!";
}
