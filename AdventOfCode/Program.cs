using AdventOfCodeLib;
using System.Diagnostics;

static void RunSolution<T>(Func<T> solution) {
	Stopwatch stopwatch = new();
	stopwatch.Start();
	T result = solution();
	stopwatch.Stop();
	Console.WriteLine(result);
	Console.WriteLine($"Completed in {stopwatch.ElapsedMilliseconds}ms");
	Console.WriteLine();
}

static IDayChallenge[] GetAllDayChallenges() => typeof(IDayChallenge).Assembly.GetTypes()
	.Where(t => t.GetInterfaces().Contains(typeof(IDayChallenge)))
	.Select(t => (IDayChallenge)t.GetConstructors().Single().Invoke(Array.Empty<object>()))
	.OrderBy(challenge => challenge.Day)
	.ToArray();

IDayChallenge[] dayChallenges = GetAllDayChallenges();

foreach (var challenge in dayChallenges) {
	string dayWithLeadingZeroes = challenge.Day.ToString().PadLeft(2, '0');
	string[] inputLines = File.ReadAllLines(Path.Combine("input", $"{dayWithLeadingZeroes}.txt"));
	Console.WriteLine($"Day {dayWithLeadingZeroes} - {challenge.Name}");
	Console.WriteLine("Part 1");
	RunSolution(() => challenge.PartOneFromFile(inputLines));
	Console.WriteLine("Part 2");
	RunSolution(() => challenge.PartTwoFromFile(inputLines));
}
