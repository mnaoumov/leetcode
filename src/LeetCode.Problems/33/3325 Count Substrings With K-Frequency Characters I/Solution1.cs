namespace LeetCode.Problems._3325_Count_Substrings_With_K_Frequency_Characters_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-420/submissions/detail/1427846357/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumberOfSubstrings(string s, int k)
    {
        var counts = new Dictionary<char, int>();

        var ans = 0;

        var i = 0;

        var n = s.Length;

        for (var j = 0; j < n; j++)
        {
            var letter = s[j];
            counts.TryAdd(letter, 0);
            counts[letter]++;

            if (counts[letter] < k)
            {
                continue;
            }

            ans += n - j;

            while (counts[letter] == k)
            {
                counts[s[i]]--;
                i++;
            }
        }

        return ans;
    }
}
