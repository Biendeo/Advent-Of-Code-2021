using AdventOfCodeLib.Challenges;
using Xunit;

namespace Tests;

public class Day16Tests {
	[Theory]
	[InlineData("D2FE28", 6)]
	[InlineData("8A004A801A8002F478", 16)]
	[InlineData("620080001611562C8802118E34", 12)]
	[InlineData("C0015000016115A2E0802F182340", 23)]
	[InlineData("A0016C880162017C3686B18A3D4780", 31)]
	public void PartOneSucceeds(string input, int expectedResult) {
		Day16 challenge = new();
		Assert.Equal(expectedResult, challenge.PartOne(input));
	}

	[Theory]
	[InlineData("C200B40A82", 3L)]
	[InlineData("04005AC33890", 54L)]
	[InlineData("880086C3E88112", 7L)]
	[InlineData("CE00C43D881120", 9L)]
	[InlineData("D8005AC2A8F0", 1L)]
	[InlineData("F600BC2D8F", 0L)]
	[InlineData("9C005AC2F8F0", 0L)]
	[InlineData("9C0141080250320F1802104A08", 1L)]
	public void PartTwoSucceeds(string input, long expectedResult) {
		Day16 challenge = new();
		Assert.Equal(expectedResult, challenge.PartTwo(input));
	}
}
