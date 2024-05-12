using JetBrains.Annotations;

namespace LeetCode.Problems._2405_Optimal_Partition_of_String;

/// <summary>
/// https://leetcode.com/submissions/detail/914095119/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PartitionString(string s)
    {
        var set = new HashSet<int>();
        var result = 1;

        foreach (var letter in s.Where(letter => !set.Add(letter)))
        {
            result++;
            set = new HashSet<int> { letter };
        }

        return result;
    }
}
