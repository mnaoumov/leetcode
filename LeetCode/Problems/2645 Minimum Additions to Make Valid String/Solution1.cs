using JetBrains.Annotations;

namespace LeetCode._2645_Minimum_Additions_to_Make_Valid_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-341/submissions/detail/934473983/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AddMinimum(string word)
    {
        var result = 0;
        var expectedIndex = 0;

        foreach (var letter in word)
        {
            var actualIndex = "abc".IndexOf(letter);
            var diff = actualIndex - expectedIndex;

            if (diff < 0)
            {
                diff += 3;
            }

            result += diff;
            expectedIndex = (actualIndex + 1) % 3;
        }

        var remainder = (word.Length + result) % 3;

        result += remainder == 0 ? 0 : 3 - remainder;

        return result;
    }
}
