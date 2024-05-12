using JetBrains.Annotations;

namespace LeetCode.Problems._2825_Make_String_a_Subsequence_Using_Cyclic_Increments;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-111/submissions/detail/1025785735/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanMakeSubsequence(string str1, string str2)
    {
        var index2 = 0;

        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
        foreach (var letter1 in str1)
        {
            var letter2 = str2[index2];

            if (letter1 != letter2 && letter2 != letter1 + 1 && (letter1 != 'z' || letter2 != 'a'))
            {
                continue;
            }

            index2++;

            if (index2 == str2.Length)
            {
                break;
            }
        }

        return index2 == str2.Length;
    }
}
