namespace LeetCode.Problems._0859_Buddy_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/984909332/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool BuddyStrings(string s, string goal)
    {
        if (s.Length != goal.Length)
        {
            return false;
        }

        if (s.Length == 1)
        {
            return false;
        }

        var letters = new HashSet<char>();
        var firstMismatch = -1;
        var hasMismatchPair = false;
        var hasDuplicate = false;

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] != goal[i])
            {
                if (firstMismatch == -1)
                {
                    firstMismatch = i;
                }
                else if (hasMismatchPair || s[i] != goal[firstMismatch] || s[firstMismatch] != goal[i])
                {
                    return false;
                }
                else
                {
                    hasMismatchPair = true;
                }
            }
            else if (!hasDuplicate && !letters.Add(s[i]))
            {
                hasDuplicate = true;
            }
        }

        return firstMismatch == -1 ? hasDuplicate : hasMismatchPair;
    }
}
