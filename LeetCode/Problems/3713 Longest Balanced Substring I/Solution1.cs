namespace LeetCode.Problems._3713_Longest_Balanced_Substring_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-471/problems/longest-balanced-substring-i/submissions/1798888230/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestBalanced(string s)
    {
        var n = s.Length;
        const int lettersCount = 26;
        var counts = new int[n + 1, 26];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < lettersCount; j++)
            {
                counts[i + 1, j] = counts[i, j];
            }

            var letterIndex = s[i] - 'a';
            counts[i + 1, letterIndex]++;
        }

        for (var length = n; length >= 1; length--)
        {
            for (var i = 0; i <= n - length; i++)
            {
                var countsSet = new HashSet<int>();
                var isBalanced = true;

                for (var j = 0; j < lettersCount; j++)
                {
                    var count = counts[i + length, j] - counts[i, j];

                    if (count == 0)
                    {
                        continue;
                    }

                    countsSet.Add(count);

                    if (countsSet.Count <= 1)
                    {
                        continue;
                    }

                    isBalanced = false;
                    break;
                }

                if (isBalanced)
                {
                    return length;
                }
            }
        }

        return 1;
    }
}
