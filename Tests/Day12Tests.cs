using AdventOfCodeLib.Challenges;
using System;
using Xunit;

namespace Tests;

public class Day12Tests {
	public const string TestInputShort = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";
	public const string TestInputLong = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";
	public const string TestInputReallyLong = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

	[Theory]
	[InlineData(TestInputShort, 10)]
	[InlineData(TestInputLong, 19)]
	[InlineData(TestInputReallyLong, 226)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day12 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input.Split(Environment.NewLine)));
	}

	[Theory]
	[InlineData(TestInputShort, 36)]
	[InlineData(TestInputLong, 103)]
	[InlineData(TestInputReallyLong, 3509)]
	public void PartTwoSucceeds(string input, int expectedResult) {
		Day12 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input.Split(Environment.NewLine)));
	}
}
