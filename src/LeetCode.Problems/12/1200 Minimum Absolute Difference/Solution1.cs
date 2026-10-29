namespace LeetCode.Problems._1200_Minimum_Absolute_Difference;

/// <summary>
/// https://leetcode.com/problems/minimum-absolute-difference/submissions/1897020586/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        Array.Sort(arr);
        var n =arr.Length;
        var minDiff = Enumerable.Range(0, n - 1).Select(i => arr[i + 1] - arr[i]).Min();
        var set = arr.ToHashSet();

        var ans = new List<IList<int>>();

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var a in arr)
        {
            var b = a + minDiff;
            if (set.Contains(b))
            {
                ans.Add(new List<int> { a, b });
            }
        }

        return ans;
    }
}
