using JetBrains.Annotations;

namespace LeetCode._2957_Remove_Adjacent_Almost_Equal_Characters;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-119/submissions/detail/1115770723/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int RemoveAlmostEqualCharacters(string word)
    {
        var n = word.Length;
        var ans = 0;

        var i = 1;

        while (i < n)
        {
            if (IsAlmostEqualToPrevious(i))
            {
                ans++;
                i += 2;
            }
            else
            {
                i++;
            }
        }

        return ans;

        bool IsAlmostEqualToPrevious(int index) =>
            index < n && Math.Abs(word[index] - word[index - 1]) <= 1;
    }
}
