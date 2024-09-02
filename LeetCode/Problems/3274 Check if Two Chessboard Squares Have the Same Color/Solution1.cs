using JetBrains.Annotations;

namespace LeetCode.Problems._3274_Check_if_Two_Chessboard_Squares_Have_the_Same_Color;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-413/submissions/detail/1374787212/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckTwoChessboards(string coordinate1, string coordinate2) => Parity(coordinate1) == Parity(coordinate2);
    private static bool Parity(string coordinate) => (coordinate[0] + coordinate[1]) % 2 == 0;
}
