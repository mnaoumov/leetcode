using JetBrains.Annotations;

namespace LeetCode._2957_Remove_Adjacent_Almost_Equal_Characters;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-119/submissions/detail/1115760739/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int RemoveAlmostEqualCharacters(string word)
    {
        var n = word.Length;
        var ans = 0;

        for (var i = 1; i < n; i += 2)
        {
            if (IsAlmostEqualToPrevious(i) || IsAlmostEqualToPrevious(i + 1))
            {
                ans++;
            }
        }

        return ans;

        bool IsAlmostEqualToPrevious(int index) =>
            index < n && Math.Abs(word[index] - word[index - 1]) <= 1;
    }
}
