using AdventOfCodeLib.Challenges;
using Xunit;

namespace Tests;

public class Day07Tests {
	[Theory]
	[InlineData(new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 37)]
	public void PartOneSucceeds(int[] input, int expectedResult) {
		Day07 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input));
	}

	[Theory]
	[InlineData(new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 }, 168)]
	public void PartTwoSucceeds(int[] input, int expectedResult) {
		Day07 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input));
	}
}
