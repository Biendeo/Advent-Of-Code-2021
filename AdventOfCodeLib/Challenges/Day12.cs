namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 12, Name = "Passage Pathing")]
public class Day12 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) {
		(HashSet<string> caves, HashSet<(string, string)> connections) = ParseInput(inputLines);
		return CountCavePaths("start", new(), caves, connections, false, false);
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) {
		(HashSet<string> caves, HashSet<(string, string)> connections) = ParseInput(inputLines);
		return CountCavePaths("start", new(), caves, connections, true, false);
	}

	private (HashSet<string>, HashSet<(string, string)>) ParseInput(string[] inputLines) {
		HashSet<string> caves = new();
		HashSet<(string, string)> connections = new();
		foreach ((string cave1, string cave2) in inputLines.Select(s => (s.Split('-')[0], s.Split('-')[1]))) {
			caves.Add(cave1);
			caves.Add(cave2);
			connections.Add((cave1, cave2));
			connections.Add((cave2, cave1));
		}
		return (caves, connections);
	}

	private static bool IsAllLowercase(string s) => s.All(c => c >= 'a' && c <= 'z');

	private int CountCavePaths(string currentCave, Stack<string> pathSoFar, HashSet<string> caves, HashSet<(string, string)> connections, bool partTwoRules, bool hasVisitedSmallCaveTwice) {
		if (partTwoRules && pathSoFar.Any() && currentCave == "start") {
			return 0;
		} else if (IsAllLowercase(currentCave) && pathSoFar.Contains(currentCave)) {
			if (partTwoRules && !hasVisitedSmallCaveTwice) {
				hasVisitedSmallCaveTwice = true;
			} else {
				return 0;
			}
		} else if (currentCave == "end") {
			return 1;
		}
		pathSoFar.Push(currentCave);
		int pathsToEnd = connections.Where(c => c.Item1 == currentCave).Sum(c => CountCavePaths(c.Item2, pathSoFar, caves, connections, partTwoRules, hasVisitedSmallCaveTwice));
		pathSoFar.Pop();
		return pathsToEnd;
	}
}
