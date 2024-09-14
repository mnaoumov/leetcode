namespace LeetCode.Problems._3285_Find_Indices_of_Stable_Mountains;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-139/submissions/detail/1389892906/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> StableMountains(int[] height, int threshold) => Enumerable.Range(1, height.Length - 1)
        .Where(i => height[i - 1] > threshold)
        .ToArray();
}
