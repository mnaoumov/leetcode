using JetBrains.Annotations;

namespace LeetCode._2937_Make_Three_Strings_Equal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-372/submissions/detail/1101773071/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindMinimumOperations(string s1, string s2, string s3)
    {
        var i = 0;

        while (i < s1.Length && i < s2.Length && i < s3.Length && s1[i] == s2[i] && s2[i] == s3[i])
        {
            i++;
        }

        if (i == 0)
        {
            return -1;
        }

        return s1.Length + s2.Length + s3.Length - 3 * i;
    }
}
