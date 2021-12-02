using AdventOfCodeLib.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests;

public class Day02Tests {
	private const string TestInput = "forward 5,down 5,forward 8,up 3,down 8,forward 2";

	[Theory]
	[InlineData(TestInput, 150)]
	public void PartOneSucceeds(string values, int expectedResult) {
		Day02 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(values.Split(',')));
	}

	[Theory]
	[InlineData(TestInput, 900)]
	public void PartTwoSucceeds(string values, int expectedResult) {
		Day02 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(values.Split(',')));
	}
}
