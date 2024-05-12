using JetBrains.Annotations;

namespace LeetCode.Problems._2496_Maximum_Value_of_a_String_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/857677513/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumValue(string[] strs)
    {
        return strs.Max(str => int.TryParse(str, out var num) ? num : str.Length);
    }
}
