using JetBrains.Annotations;

namespace LeetCode.Problems._2610_Convert_an_Array_Into_a_2D_Array_With_Conditions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-339/submissions/detail/926284602/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindMatrix(int[] nums)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var result = new List<IList<int>>();

        while (counts.Count > 0)
        {
            result.Add(counts.Keys.ToArray());

            foreach (var key in counts.Keys)
            {
                counts[key]--;

                if (counts[key] == 0)
                {
                    counts.Remove(key);
                }
            }
        }

        return result;
    }
}
