namespace LeetCode.Problems._2743_Count_Substrings_Without_Repeating_Character;

/// <summary>
/// https://leetcode.com/submissions/detail/1297105776/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSpecialSubstrings(string s)
    {
        var ans = 1;
        var visibleLetters = new HashSet<char> { s[0] };

        var i = 0;

        for (var j = 1; j < s.Length; j++)
        {
            while (!visibleLetters.Add(s[j]))
            {
                visibleLetters.Remove(s[i]);
                i++;
            }

            ans += j - i + 1;
        }
        
        return ans;
    }
}
