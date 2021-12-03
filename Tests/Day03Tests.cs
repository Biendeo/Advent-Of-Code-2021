using AdventOfCodeLib.Challenges;
using Xunit;

namespace Tests;

public class Day03Tests {
	private const string TestInput = "00100,11110,10110,10111,10101,01111,00111,11100,10000,11001,00010,01010";

	[Theory]
	[InlineData(TestInput, 198)]
	public void PartOneSucceeds(string values, int expectedResult) {
		Day03 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(values.Split(',')));
	}

	[Theory]
	[InlineData(TestInput, 230)]
	public void PartTwoSucceeds(string values, int expectedResult) {
		Day03 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(values.Split(',')));
	}
}
