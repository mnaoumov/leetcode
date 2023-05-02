using JetBrains.Annotations;

namespace LeetCode._0097_Interleaving_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829620277/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        var index1 = 0;
        var index2 = 0;

        while (true)
        {
            if (index1 == s1.Length && index2 == s2.Length)
            {
                return true;
            }

            var lettersTaken = false;

            while (index1 < s1.Length && s1[index1] == s3[index1 + index2])
            {
                lettersTaken = true;
                index1++;
            }

            while (index2 < s2.Length && s2[index2] == s3[index1 + index2])
            {
                lettersTaken = true;
                index2++;
            }

            if (!lettersTaken)
            {
                return false;
            }
        }
    }
}
