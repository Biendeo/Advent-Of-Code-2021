namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 6, Name = "Lanternfish")]
public class Day06 : IDayChallenge {
	private const int NewFishLifespan = 8;
	private const int OldFishResetLifespan = 6;

	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines.Single().Split(',').Select(x => int.Parse(x)).ToList()).ToString();

	public long PartOne(List<int> input) => Solve(input, 80);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines.Single().Split(',').Select(x => int.Parse(x)).ToList()).ToString();

	public long PartTwo(List<int> input) => Solve(input, 256);

	public long Solve(List<int> input, int days) {
		Dictionary<int, long> fish = input.GroupBy(x => x).ToDictionary(x => x.Key, x => (long)x.Count());
		foreach (int i in Enumerable.Range(0, NewFishLifespan + 1)) fish.TryAdd(i, 0L);
		for (int day = 0; day < days; ++day) {
			long expiringFish = fish[0];
			for (int i = 0; i < NewFishLifespan; ++i) {
				fish[i] = fish[i + 1];
			}
			fish[NewFishLifespan] = expiringFish;
			fish[OldFishResetLifespan] += expiringFish;
		}
		return fish.Values.Sum();
	}
}
