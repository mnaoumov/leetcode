using JetBrains.Annotations;

namespace LeetCode._1630_Arithmetic_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/935067138/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        var m = l.Length;
        var result = Enumerable.Repeat(true, m).ToArray();

        for (var i = 0; i < m; i++)
        {
            var list = new List<int>();

            for (var j = l[i]; j <= r[i]; j++)
            {
                list.Add(nums[j]);
            }

            if (list.Count < 2)
            {
                result[i] = false;
                continue;
            }

            list.Sort();

            for (var j = 2; j < list.Count; j++)
            {
                if (list[j] - list[j - 1] == list[1] - list[0])
                {
                    continue;
                }

                result[i] = false;
                break;
            }
        }

        return result;
    }
}
