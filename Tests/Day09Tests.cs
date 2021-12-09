using AdventOfCodeLib.Challenges;
using Xunit;

namespace Tests;

public class Day09Tests {
	private const string TestInput = "2199943210,3987894921,9856789892,8767896789,9899965678";

	[Theory]
	[InlineData(TestInput, 15)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day09 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(',')));
	}

	[Theory]
	[InlineData(TestInput, 1134)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day09 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(',')));
	}
}
