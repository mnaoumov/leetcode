using JetBrains.Annotations;

namespace LeetCode.Problems._3158_Find_the_XOR_of_Numbers_Which_Appear_Twice;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-131/submissions/detail/1267527144/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DuplicateNumbersXOR(int[] nums)
    {
        var seen = new HashSet<int>();
        return nums.Where(num => !seen.Add(num)).Aggregate(0, (current, num) => current ^ num);
    }
}
