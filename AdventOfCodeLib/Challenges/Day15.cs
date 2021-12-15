using System.Text;

namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 15, Name = "Chiton")]
public class Day15 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		int[,] costs = new int[inputLines.First().Length, inputLines.Length];

		PriorityQueue<(int x, int y), int> searchQueue = new();
		searchQueue.Enqueue((costs.GetLength(0) - 1, costs.GetLength(1) - 1), inputLines.Last().Last() - '0');
		costs[costs.GetLength(0) - 1, costs.GetLength(1) - 1] = inputLines.Last().Last() - '0';

		while (searchQueue.Count > 0) {
			(int currentX, int currentY) = searchQueue.Dequeue();
			foreach ((int newX, int newY) in Helper.GetNeighbors(currentX, currentY, 0, costs.GetLength(0) - 1, 0, costs.GetLength(1) - 1, false)) {
				if (costs[newX, newY] == 0) {
					costs[newX, newY] = costs[currentX, currentY] + inputLines[newY][newX] - '0';
					searchQueue.Enqueue((newX, newY), costs[newX, newY]);
				}
			}
		}

		return costs[0, 0] - inputLines[0][0] + '0';
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) {
		string[] newInput = new string[inputLines.Length * 5];
		for (int bigY = 0; bigY < 5; ++bigY) {
			for (int y = 0; y < inputLines.Length; ++y) {
				StringBuilder sb = new();
				for (int bigX = 0; bigX < 5; ++bigX) {
					sb.Append(string.Concat(inputLines[y].Select(c => (char)(((c - '1' + bigX + bigY) % 9) + '1'))));
				}
				newInput[bigY * inputLines.Length + y] = sb.ToString();
			}
		}
		return PartOne(newInput);
	}
}
