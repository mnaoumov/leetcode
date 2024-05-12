using JetBrains.Annotations;

namespace LeetCode.Problems._1272_Remove_Interval;

/// <summary>
/// https://leetcode.com/submissions/detail/1176512754/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> RemoveInterval(int[][] intervals, int[] toBeRemoved)
    {
        var ans = new List<IList<int>>();

        foreach (var interval in intervals)
        {
            var i0 = interval[0];
            var i1 = interval[1];
            var t0 = toBeRemoved[0];
            var t1 = toBeRemoved[1];

            if (i1 <= t0 || i0 >= t1)
            {
                ans.Add(interval);
            }
            else
            {
                if (i0 < t0)
                {
                    ans.Add(new[] { i0, t0 });
                }

                if (t1 < i1)
                {
                    ans.Add(new[] { t1, i1 });
                }
            }
        }

        return ans;
    }
}
