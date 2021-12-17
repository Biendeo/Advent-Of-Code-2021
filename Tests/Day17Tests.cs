using AdventOfCodeLib.Challenges;
using Xunit;

namespace Tests;

public class Day17Tests {
	private const string TestInput = "target area: x=20..30, y=-10..-5";

	[Theory]
	[InlineData(TestInput, 45)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day17 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input));
	}

	[Theory]
	[InlineData(TestInput, 112)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day17 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input));
	}
}
