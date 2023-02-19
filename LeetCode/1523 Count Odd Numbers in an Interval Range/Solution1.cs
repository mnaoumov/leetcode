using JetBrains.Annotations;

namespace LeetCode._1523_Count_Odd_Numbers_in_an_Interval_Range;

/// <summary>
/// https://leetcode.com/submissions/detail/896837174/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountOdds(int low, int high) => (high - low + 1) / 2 + (high - low + 1) % 2 * (low % 2);
}