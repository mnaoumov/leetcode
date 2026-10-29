namespace LeetCode.Problems._1758_Minimum_Changes_To_Make_Alternating_Binary_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1126992195/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(string s)
    {
        var leadingZeroChangesCount = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var leadingZeroDigit = i % 2 == 0 ? '0' : '1';
            if (s[i] != leadingZeroDigit)
            {
                leadingZeroChangesCount++;
            }
        }

        return Math.Min(leadingZeroChangesCount, s.Length - leadingZeroChangesCount);
    }
}
