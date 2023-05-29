using JetBrains.Annotations;

namespace LeetCode._2710_Remove_Trailing_Zeros_From_a_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-347/submissions/detail/958680214/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string RemoveTrailingZeros(string num) => num.TrimEnd('0');
}
