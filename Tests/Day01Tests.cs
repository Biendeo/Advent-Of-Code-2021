using AdventOfCodeLib.Challenges;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests;

public class Day01Tests {
	private const string TestInput = "199,200,208,210,200,207,240,269,260,263";

	[Theory]
	[InlineData(TestInput, 7)]
	public void PartOneSucceeds(string values, int expectedResult) {
		Day01 challenge = new();
		List<int> parsedInput = values.Split(',').Select(x => int.Parse(x)).ToList();
		Assert.Equal(expectedResult, challenge.PartOne(parsedInput));
	}

	[Theory]
	[InlineData(TestInput, 5)]
	public void PartTwoSucceeds(string values, int expectedResult) {
		Day01 challenge = new();
		List<int> parsedInput = values.Split(',').Select(x => int.Parse(x)).ToList();
		Assert.Equal(expectedResult, challenge.PartTwo(parsedInput));
	}
}
