using JetBrains.Annotations;

namespace LeetCode._1422_Maximum_Score_After_Splitting_a_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1126083875/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxScore(string s)
    {
        var zerosCount = 0;
        var ans = int.MinValue;

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '0')
            {
                zerosCount++;
            }

            ans = Math.Max(ans, 2 * zerosCount - i);
        }

        ans += s.Length - zerosCount - 1;

        return ans;
    }
}
