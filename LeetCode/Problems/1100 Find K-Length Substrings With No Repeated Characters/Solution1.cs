namespace LeetCode.Problems._1100_Find_K_Length_Substrings_With_No_Repeated_Characters;

/// <summary>
/// https://leetcode.com/problems/find-k-length-substrings-with-no-repeated-characters/submissions/1566552096/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumKLenSubstrNoRepeats(string s, int k)
    {
        if (s.Length < k)
        {
            return 0;
        }

        var counts = new Dictionary<char, int>();

        var ans = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            counts.TryAdd(letter, 0);
            counts[letter]++;

            if (i >= k)
            {
                var oldLetter = s[i - k];
                counts[oldLetter]--;

                if (counts[oldLetter] == 0)
                {
                    counts.Remove(oldLetter);
                }
            }

            if (i >= k - 1 && counts.Count == k)
            {
                ans++;
            }
        }

        return ans;
    }
}
