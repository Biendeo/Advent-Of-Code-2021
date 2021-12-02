namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 2, Name = "Tomorrow")]
public class Day02 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		List<Step> input = ParseInput(inputLines);
		int x = 0, y = 0;

		foreach (Step step in input) {
			switch (step.Direction) {
				case Direction.Up:
					y -= step.Magnitude;
					break;
				case Direction.Forward:
					x += step.Magnitude;
					break;
				case Direction.Down:
					y += step.Magnitude;
					break;
			}
		}

		return Math.Abs(x * y);
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) {
		List<Step> input = ParseInput(inputLines);
		int x = 0, y = 0, aim = 0;

		foreach (Step step in input) {
			switch (step.Direction) {
				case Direction.Up:
					aim -= step.Magnitude;
					break;
				case Direction.Forward:
					x += step.Magnitude;
					y += step.Magnitude * aim;
					break;
				case Direction.Down:
					aim += step.Magnitude;
					break;
			}
		}

		return Math.Abs(x * y);
	}

	private List<Step> ParseInput(string[] inputLines) => inputLines.Select(l => new Step(l.Split(" ")[0], int.Parse(l.Split(" ")[1]))).ToList();

	private enum Direction {
		Forward,
		Up,
		Down
	}

	private class Step {
		public Direction Direction;
		public int Magnitude;

		public Step(string direction, int magnitude) {
			Direction = direction switch {
				"forward" => Direction.Forward,
				"up" => Direction.Up,
				"down" => Direction.Down,
				_ => throw new Exception("Bad input!")
			};
			Magnitude = magnitude;
		}
	}
}