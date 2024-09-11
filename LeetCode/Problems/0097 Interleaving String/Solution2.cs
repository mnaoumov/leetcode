using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0097_Interleaving_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829625725/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        return s1.Length + s2.Length == s3.Length && CheckMatch(0, 0);

        bool CheckMatch(int index1, int index2)
        {
            if (index1 == s1.Length && index2 == s2.Length)
            {
                return true;
            }

            var match1 = index1 < s1.Length && s1[index1] == s3[index1 + index2] && CheckMatch(index1 + 1, index2);
            var match2 = index2 < s2.Length && s2[index2] == s3[index1 + index2] && CheckMatch(index1, index2 + 1);

            return match1 || match2;
        }
    }
}
