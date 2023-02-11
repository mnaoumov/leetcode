using JetBrains.Annotations;

namespace LeetCode._1470_Shuffle_the_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/892340246/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] Shuffle(int[] nums, int n) => Enumerable.Range(0, n).SelectMany(i => new[] { nums[i], nums[n + i] }).ToArray();
}
