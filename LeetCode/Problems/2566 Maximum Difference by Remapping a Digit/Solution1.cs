using JetBrains.Annotations;

namespace LeetCode.Problems._2566_Maximum_Difference_by_Remapping_a_Digit;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-98/submissions/detail/900356939/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMaxDifference(int num)
    {
        var numStr = num.ToString();
        var firstNon9Digit = numStr.FirstOrDefault(digitChar => digitChar != '9');
        var max = int.Parse(numStr.Replace(firstNon9Digit, '9'));
        var min = int.Parse(numStr.Replace(numStr[0], '0'));
        return max - min;
    }
}
