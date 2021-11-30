namespace AdventOfCodeLib;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class DayDetailsAttribute : Attribute {
	public int Day;
	public string Name = "No name";
}
