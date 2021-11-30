using System.Reflection;

namespace AdventOfCodeLib;

public interface IDayChallenge {
	public string PartOneFromFile(string[] inputLines);
	public string PartTwoFromFile(string[] inputLines);

	public int Day => GetType().GetCustomAttribute<DayDetailsAttribute>()?.Day ?? 0;
	public string Name => GetType().GetCustomAttribute<DayDetailsAttribute>()?.Name ?? "No name";
}
