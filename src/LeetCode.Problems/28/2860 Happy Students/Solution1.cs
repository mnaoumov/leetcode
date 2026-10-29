namespace LeetCode.Problems._2860_Happy_Students;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-363/submissions/detail/1051417987/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountWays(IList<int> nums)
    {
        var sortedNums = nums.OrderBy(num => num).ToArray();
        var n = nums.Count;
        return Enumerable.Range(0, n + 1)
            .Count(k => (k == 0 || sortedNums[k - 1] < k) && (k == n || k < sortedNums[k]));
    }
}
