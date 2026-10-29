namespace LeetCode.Problems._3325_Count_Substrings_With_K_Frequency_Characters_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-420/submissions/detail/1427856109/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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

            while (counts[letter] == k)
            {
                ans += n - j;
                counts[s[i]]--;
                i++;
            }
        }

        return ans;
    }
}
