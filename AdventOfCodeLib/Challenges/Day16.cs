namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 16, Name = "Packet Decoder")]
public class Day16 : IDayChallenge {
	public string PartOneFromFile(string[] inputLines) => PartOne(inputLines.Single()).ToString();

	public int PartOne(string input) {
		(int versionSum, _) = GetPacketVersionSumAndValue(ToBinary(input), out _);
		return versionSum;
	}

	public string PartTwoFromFile(string[] inputLines) => PartTwo(inputLines.Single()).ToString();

	public long PartTwo(string input) {
		(_, long valueSum) = GetPacketVersionSumAndValue(ToBinary(input), out _);
		return valueSum;
	}

	private static string ToBinary(string input) => string.Concat(input.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));

	private (int versionSum, long value) GetPacketVersionSumAndValue(string binaryInput, out int packetLength) {
		int versionSum = Convert.ToInt32(binaryInput[0..3], 2);
		int packetTypeId = Convert.ToInt32(binaryInput[3..6], 2);
		long value = 0;
		if (packetTypeId == 4) {
			int lastValue = 16;
			packetLength = 6;
			while (lastValue >= 16) {
				lastValue = Convert.ToInt32(binaryInput[packetLength..(packetLength + 5)], 2);
				packetLength += 5;
				value = 16L * value + lastValue % 16;
			}
		} else {
			List<long> values = new();
			if (binaryInput[6] == '0') {
				int lengthOfBits = Convert.ToInt32(binaryInput[7..22], 2);
				packetLength = 22;
				while (packetLength != 22 + lengthOfBits) {
					(int subVersion, long subValue) = GetPacketVersionSumAndValue(binaryInput[packetLength..], out int subPacketLength);
					packetLength += subPacketLength;
					versionSum += subVersion;
					values.Add(subValue);
				}
			} else {
				int numberOfSubPackets = Convert.ToInt32(binaryInput[7..18], 2);
				packetLength = 18;
				for (int i = 0; i < numberOfSubPackets; ++i) {
					(int subVersion, long subValue) = GetPacketVersionSumAndValue(binaryInput[packetLength..], out int subPacketLength);
					versionSum += subVersion;
					values.Add(subValue);
					packetLength += subPacketLength;
				}
			}
			value = packetTypeId switch {
				0 => values.Sum(),
				1 => values.Aggregate((a, b) => a * b),
				2 => values.Min(),
				3 => values.Max(),
				5 => values[0] > values[1] ? 1 : 0,
				6 => values[0] < values[1] ? 1 : 0,
				7 => values[0] == values[1] ? 1 : 0,
				_ => throw new Exception($"Weird packet type ID {packetTypeId}")
			};
		}
		return (versionSum, value);
	}
}
