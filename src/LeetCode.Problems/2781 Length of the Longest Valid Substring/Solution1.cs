namespace LeetCode.Problems._2781_Length_of_the_Longest_Valid_Substring;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-354/submissions/detail/995568138/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestValidSubstring(string word, IList<string> forbidden)
    {
        var forbiddenSet = forbidden.ToHashSet();

        var ans = 0;

        var maxForbiddenLength = forbidden.Max(x => x.Length);

        var suffixes = new List<string>();

        var i = 0;

        for (var j = 0; j < word.Length; j++)
        {
            var letter = word[j];

            if (suffixes.Count < maxForbiddenLength)
            {
                suffixes.Add("");
            }

            for (var k = suffixes.Count - 1; k >= 1; k--)
            {
                suffixes[k] = suffixes[k - 1] + letter;
            }

            suffixes[0] = letter.ToString();

            foreach (var suffix in suffixes.Where(suffix => forbiddenSet.Contains(suffix)))
            {
                i = j - suffix.Length + 2;
                suffixes.RemoveRange(suffix.Length - 1, suffixes.Count - suffix.Length + 1);
                break;
            }

            ans = Math.Max(ans, j - i + 1);
        }

        return ans;
    }
}
