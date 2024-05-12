using JetBrains.Annotations;

namespace LeetCode.Problems._1908_Game_of_Nim;

/// <summary>
/// https://leetcode.com/submissions/detail/887146115/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool NimGame(int[] piles) => piles.Aggregate(0, (result, pile) => result ^ pile) != 0;
}
