namespace AdventOfCodeLib.Challenges;

[DayDetails(Day = 4, Name = "Giant Squid")]
public class Day04 : IDayChallenge {
	private const int CheckedValue = -1;
	private const int BoardSize = 5;

	public string PartOneFromFile(string[] inputLines) {
		(int[] drawnNumbers, List<int[,]> bingoBoards) = ParseInput(inputLines);
		return PartOne(drawnNumbers, bingoBoards).ToString();
	}

	public int PartOne(int[] drawnNumbers, List<int[,]> bingoBoards) => bingoBoards.Select(b => GetVictoryOfBoard(drawnNumbers, b)).Aggregate((a, b) => a.turnCount < b.turnCount ? a : b).score;

	public string PartTwoFromFile(string[] inputLines) {
		(int[] drawnNumbers, List<int[,]> bingoBoards) = ParseInput(inputLines);
		return PartTwo(drawnNumbers, bingoBoards).ToString();
	}

	public int PartTwo(int[] drawnNumbers, List<int[,]> bingoBoards) => bingoBoards.Select(b => GetVictoryOfBoard(drawnNumbers, b)).Aggregate((a, b) => a.turnCount > b.turnCount ? a : b).score;

	public static (int[] drawnNumbers, List<int[,]> bingoBoards) ParseInput(string[] input) {
		List<int[,]> bingoBoards = new();
		for (int inputY = 1; inputY < input.Length; inputY += 6) {
			int[,] board = new int[BoardSize, BoardSize];
			for (int y = 0; y < BoardSize; ++y) {
				int[] parsedRow = input[inputY + y + 1].Split(' ').Where(s => !string.IsNullOrEmpty(s)).Select(x => int.Parse(x)).ToArray();
				for (int x = 0; x < BoardSize; ++x) {
					board[x, y] = parsedRow[x];
				}
			}
			bingoBoards.Add(board);
		}
		return (input[0].Split(',').Select(x => int.Parse(x)).ToArray(), bingoBoards);
	}

	private IEnumerable<(int x, int y)> IterateBingoBoard() => Enumerable.Range(0, BoardSize).SelectMany(x => Enumerable.Range(0, BoardSize), (x, y) => (x, y));

	private (int turnCount, int score) GetVictoryOfBoard(int[] drawnNumbers, int[,] bingoBoard) {
		int[,] modifiedBoard = (int[,])bingoBoard.Clone();
		int lastDrawnNumber = -1;
		int turnCount;
		for (turnCount = 0; turnCount < drawnNumbers.Length && !DoesBoardHaveVictory(modifiedBoard); ++turnCount) {
			lastDrawnNumber = drawnNumbers[turnCount];
			foreach ((int x, int y) in IterateBingoBoard()) {
				if (modifiedBoard[x, y] == lastDrawnNumber) {
					modifiedBoard[x, y] = CheckedValue;
				}
			}
		}
		return (turnCount, GetBoardScore(modifiedBoard, lastDrawnNumber));
	}

	private bool DoesBoardHaveVictory(int[,] bingoBoard) => Enumerable.Range(0, BoardSize).Any(y => Enumerable.Range(0, BoardSize).Sum(x => bingoBoard[x, y]) == CheckedValue * BoardSize) ||
		Enumerable.Range(0, BoardSize).Any(x => Enumerable.Range(0, BoardSize).Sum(y => bingoBoard[x, y]) == CheckedValue * BoardSize);

	private int GetBoardScore(int[,] bingoBoard, int lastDrawnNumber) => IterateBingoBoard().Sum(c => bingoBoard[c.x, c.y] == CheckedValue ? 0 : bingoBoard[c.x, c.y]) * lastDrawnNumber;
}
