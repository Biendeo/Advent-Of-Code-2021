namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 2, Name = "Tomorrow")]
public class Day02 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		int x = 0, y = 0;
		foreach ((string direction, string magnitudeString) in inputLines.Select(l => l.Split(' '))) {
			int magnitude = int.Parse(magnitudeString);
			switch (direction) {
				case "up":
					y -= magnitude;
					break;
				case "forward":
					x += magnitude;
					break;
				case "down":
					y += magnitude;
					break;
			}
		}
		return Math.Abs(x * y);
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) {
		int x = 0, y = 0, aim = 0;
		foreach ((string direction, string magnitudeString) in inputLines.Select(l => l.Split(' '))) {
			int magnitude = int.Parse(magnitudeString);
			switch (direction) {
				case "up":
					aim -= magnitude;
					break;
				case "forward":
					x += magnitude;
					y += magnitude * aim;
					break;
				case "down":
					aim += magnitude;
					break;
			}
		}
		return Math.Abs(x * y);
	}
}