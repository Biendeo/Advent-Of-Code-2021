namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 17, Name = "Trick Shot")]
public class Day17 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines.Single()).ToString();

	public int PartOne(string input) => ComputeAndEvaluate(input, q => q.Max(r => r.highestY));

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines.Single()).ToString();

	public int PartTwo(string input) => ComputeAndEvaluate(input, q => q.Count());

	private int ComputeAndEvaluate(string input, Func<ParallelQuery<(bool lands, int highestY)>, int> f) {
		int[] inputValues = input.Replace(", y=", "..")[15..].Split("..").Select(a => int.Parse(a)).ToArray();
		return f(Helper.GetTwoDimensionalRange(0, 1000, -1000, 1000).AsParallel().Select(a => DoesLandInArea(a.x, a.y, inputValues[0], inputValues[1], inputValues[3], inputValues[2])).Where(r => r.lands));
	}

	private (bool lands, int highestY) DoesLandInArea(int xVel, int yVel, int xLeft, int xRight, int yTop, int yBottom) {
		int xv = xVel, yv = yVel, x = 0, y = 0, highestY = 0;
		while (y >= yBottom) {
			x += xv;
			y += yv;
			highestY = Math.Max(y, highestY);
			if (x >= xLeft && x <= xRight && y >= yBottom && y <= yTop) return (true, highestY);
			xv = xv > 0 ? xv - 1 : (xv < 0 ? xv + 1 : 0);
			yv -= 1;
		}
		return (false, highestY);
	}
}
