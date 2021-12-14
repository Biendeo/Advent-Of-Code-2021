namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 14, Name = "Extended Polymerization")]
public class Day14 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public long PartOne(string[] inputLines) => ComputeGreatestDifferenceInFrequencies(inputLines, 10);

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public long PartTwo(string[] inputLines) => ComputeGreatestDifferenceInFrequencies(inputLines, 40);

	private (string template, Dictionary<(char, char), char> insertionRules) ParseInput(string[] inputLines) => (inputLines.First(), inputLines[2..].ToDictionary(l => (l[0], l[1]), l => l[6]));

	private long ComputeGreatestDifferenceInFrequencies(string[] inputLines, int generations) {
		(string template, Dictionary<(char, char), char> insertionRules) = ParseInput(inputLines);
		char lastCharacter = template.Last();
		Dictionary<(char, char), long> pairingFrequencies = new();
		for (int i = 0; i < template.Length - 1; ++i) {
			InsertAndIncrement(pairingFrequencies, (template[i], template[i + 1]), 0L, 1L);
		}

		for (int gen = 0; gen < generations; ++gen) {
			pairingFrequencies = ComputeGeneration(pairingFrequencies, insertionRules);
		}

		Dictionary<char, long> elementFrequencies = new();
		foreach (KeyValuePair<(char, char), long> frequency in pairingFrequencies) {
			InsertAndIncrement(elementFrequencies, frequency.Key.Item1, 0L, frequency.Value);
		}
		++elementFrequencies[lastCharacter];
		return elementFrequencies.Max(e => e.Value) - elementFrequencies.Min(e => e.Value);
	}

	private Dictionary<(char, char), long> ComputeGeneration(Dictionary<(char, char), long> pairingFrequencies, Dictionary<(char, char), char> insertionRules) {
		Dictionary<(char, char), long> newPairingFrequencies = new();
		foreach (KeyValuePair<(char, char), char> insertionRule in insertionRules) {
			if (pairingFrequencies.TryGetValue(insertionRule.Key, out long x)) {
				InsertAndIncrement(newPairingFrequencies, (insertionRule.Key.Item1, insertionRule.Value), 0L, x);
				InsertAndIncrement(newPairingFrequencies, (insertionRule.Value, insertionRule.Key.Item2), 0L, x);
			}
		}
		return newPairingFrequencies;
	}

	private static void InsertAndIncrement<TKey>(Dictionary<TKey, long> d, TKey key, long startingValue, long incrementValue) where TKey : notnull {
		d.TryAdd(key, startingValue);
		d[key] += incrementValue;
	}
}
