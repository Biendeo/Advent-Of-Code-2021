using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day01Tests {
	[Fact]
	public void PartOneSucceeds() {
		Day01 challenge = new();
		Assert.Equal("The answer to part 1", challenge.PartOneFromFile(Array.Empty<string>()));
	}

	[Fact]
	public void PartTwoSucceeds() {
		Day01 challenge = new();
		Assert.Equal("The answer to part 2", challenge.PartTwoFromFile(Array.Empty<string>()));
	}
}
