namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 18, Name = "Snailfish")]
public class Day18 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines).ToString();

	public int PartOne(string[] inputLines) => Magnitude(inputLines.Aggregate((a, s) => Reduce($"[{a},{s}]")));

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines).ToString();

	public int PartTwo(string[] inputLines) => Helper.GetTwoDimensionalRange(0, inputLines.Length - 1, 0, inputLines.Length - 1).Max(a => Magnitude(Reduce($"[{inputLines[a.x]},{inputLines[a.y]}]")));

	public string Reduce(string line) {
		bool didSomethingThisPass;
		do {
			didSomethingThisPass = false;
			int depth = 0;
			for (int i = 0; i < line.Length; ++i) {
				if (line[i] == '[') {
					++depth;
				} else if (line[i] == ']') {
					if (depth > 4) {
						int indexOfThisLeftBracket = line[0..i].LastIndexOf('[');
						int indexOfThisComma = line[0..i].LastIndexOf(',');
						int indexOfNextLeftDigit = line[0..indexOfThisLeftBracket].LastIndexOfAny(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
						int indexOfNextRightDigit = line[i..].IndexOfAny(new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }) + i;
						if (indexOfNextLeftDigit == -1) {
							int indexOfEndOfRightDigit = line[indexOfNextRightDigit..].IndexOfAny(new[] { ']', ',' }) + indexOfNextRightDigit;
							line = line[..indexOfThisLeftBracket] + "0" + line[(i + 1)..indexOfNextRightDigit] + $"{int.Parse(line[indexOfNextRightDigit..indexOfEndOfRightDigit]) + int.Parse(line[(indexOfThisComma + 1)..i])}" + line[indexOfEndOfRightDigit..];
						} else if (indexOfNextRightDigit == i - 1) {
							int indexOfBeginningOfLeftDigit = line[..indexOfNextLeftDigit].LastIndexOfAny(new[] { '[', ',' });
							line = line[..(indexOfBeginningOfLeftDigit + 1)] + $"{int.Parse(line[(indexOfBeginningOfLeftDigit + 1)..(indexOfNextLeftDigit + 1)]) + int.Parse(line[(indexOfThisLeftBracket + 1)..indexOfThisComma])}" + line[(indexOfNextLeftDigit + 1)..indexOfThisLeftBracket] + "0" + line[(i + 1)..];
						} else {
							int indexOfBeginningOfLeftDigit = line[..indexOfNextLeftDigit].LastIndexOfAny(new[] { '[', ',' });
							int indexOfEndOfRightDigit = line[indexOfNextRightDigit..].IndexOfAny(new[] { ']', ',' }) + indexOfNextRightDigit;
							line = line[..(indexOfBeginningOfLeftDigit + 1)] + $"{int.Parse(line[(indexOfBeginningOfLeftDigit + 1)..(indexOfNextLeftDigit + 1)]) + int.Parse(line[(indexOfThisLeftBracket + 1)..indexOfThisComma])}" + line[(indexOfNextLeftDigit + 1)..indexOfThisLeftBracket] + "0" + line[(i + 1)..indexOfNextRightDigit] + $"{int.Parse(line[indexOfNextRightDigit..indexOfEndOfRightDigit]) + int.Parse(line[(indexOfThisComma + 1)..i])}" + line[indexOfEndOfRightDigit..];
						}
						didSomethingThisPass = true;
						break;
					}
					--depth;
				}
			}
			bool lastCharacterWasDigit = false;
			for (int i = 0; i < line.Length && !didSomethingThisPass; ++i) {
				if (line[i] >= '0' && line[i] <= '9') {
					if (lastCharacterWasDigit) {
						int numberToSplit = int.Parse(line[(i - 1)..(i + 1)]);
						line = line[..(i - 1)] + $"[{numberToSplit / 2},{(numberToSplit + 1) / 2}]" + line[(i + 1)..];
						didSomethingThisPass = true;
						break;
					}
					lastCharacterWasDigit = true;
				} else {
					lastCharacterWasDigit = false;
				}
			}
		} while (didSomethingThisPass);
		return line;
	}

	private int Magnitude(string line) {
		if (line.Length == 5) {
			return 3 * (line[1] - '0') + 2 * (line[3] - '0');
		}
		int indexOfComma = -1;
		int depth = 0;
		for (int i = 0; i < line.Length; ++i) {
			if (line[i] == '[') {
				++depth;
			} else if (line[i] == ']') {
				--depth;
			} else if (line[i] == ',' && depth == 1) {
				indexOfComma = i;
			}
		}
		return 3 * (indexOfComma == 2 ? (line[1] - '0') : Magnitude(line[1..indexOfComma])) + 2 * (indexOfComma == line.Length - 3 ? (line[^2] - '0') : Magnitude(line[(indexOfComma + 1)..^1]));
	}
}
