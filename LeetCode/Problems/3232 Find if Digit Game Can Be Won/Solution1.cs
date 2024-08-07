using JetBrains.Annotations;

namespace LeetCode.Problems._3232_Find_if_Digit_Game_Can_Be_Won;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-408/submissions/detail/1335663531/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanAliceWin(int[] nums)
    {
        var sum = nums.Sum();
        var oneDigitsSum = nums.Where(x => x < 10).Sum();
        return sum != 2 * oneDigitsSum;
    }
}
