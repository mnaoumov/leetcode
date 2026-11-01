namespace LeetCode.Problems._1908_Game_of_Nim;

/// <seealso href="https://leetcode.com/submissions/detail/887146115/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool NimGame(int[] piles) => piles.Aggregate(0, (result, pile) => result ^ pile) != 0;
}
