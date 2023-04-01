using JetBrains.Annotations;

namespace LeetCode._2607_Make_K_Subarray_Sums_Equal;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-101/submissions/detail/925996865/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MakeSubKSumEqual(int[] arr, int k)
    {
        var n = arr.Length;
        var seen = new bool[n];
        var result = 0L;

        for (var i = 0; i < n; i++)
        {
            if (seen[i])
            {
                continue;
            }

            var j = i;
            var list = new List<int>();

            while (!seen[j])
            {
                seen[j] = true;
                list.Add(arr[j]);
                j = (j + k) % n;
            }

            list.Sort();
            var median = list[list.Count / 2];
            result += list.Sum(num => 0L + Math.Abs(num - median));
        }

        return result;
    }
}
