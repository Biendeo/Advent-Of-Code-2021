using AdventOfCodeLib.Challenges;
using Xunit;

namespace Tests;

public class Day11Tests {
	private const string TestInput = "5483143223,2745854711,5264556173,6141336146,6357385478,4167524645,2176841721,6882881134,4846848554,5283751526";

	[Theory]
	[InlineData(TestInput, 1656)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day11 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(',')));
	}

	[Theory]
	[InlineData(TestInput, 195)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day11 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(',')));
	}
}
