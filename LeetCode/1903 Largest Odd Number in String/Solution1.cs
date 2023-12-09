using JetBrains.Annotations;

namespace LeetCode._1903_Largest_Odd_Number_in_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1113976870/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LargestOddNumber(string num)
    {
        var oddDigits = new HashSet<int> { 1, 3, 5, 7, 9 };
        var lastOddDigitIndex = Enumerable.Range(0, num.Length)
            .LastOrDefault(i => oddDigits.Contains(num[i] - '0'), defaultValue: -1);
        return num[..(lastOddDigitIndex + 1)];
    }
}
