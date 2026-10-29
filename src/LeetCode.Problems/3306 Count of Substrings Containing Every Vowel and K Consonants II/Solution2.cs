namespace LeetCode.Problems._3306_Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II;

/// <summary>
/// https://leetcode.com/problems/count-of-substrings-containing-every-vowel-and-k-consonants-ii/submissions/1569365588/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long CountOfSubstrings(string word, int k)
    {
        var n = word.Length;
        var counts = new Count[n + 1];
        counts[0] = new Count(0, 0, 0, 0, 0, 0);
        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            counts[i + 1] = word[i] switch
            {
                'a' => counts[i] with { A = counts[i].A + 1 },
                'e' => counts[i] with { E = counts[i].E + 1 },
                'i' => counts[i] with { I = counts[i].I + 1 },
                'o' => counts[i] with { O = counts[i].O + 1 },
                'u' => counts[i] with { U = counts[i].U + 1 },
                _ => counts[i] with { Consonants = counts[i].Consonants + 1 }
            };

            if (GetConstantsDiff(0, i + 1) < k || HasMissingVowel(0, i + 1))
            {
                continue;
            }

            var low = 0;
            var high = i;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                var consonantsDiff = GetConstantsDiff(mid, i + 1);

                if (consonantsDiff <= k)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var start = low;

            if (GetConstantsDiff(start, i + 1) != k || HasMissingVowel(start, i + 1))
            {
                continue;
            }

            high = i;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                var consonantsDiff = GetConstantsDiff(mid, i + 1);

                if (consonantsDiff < k)
                {
                    high = mid - 1;
                }
                else if (consonantsDiff > k)
                {
                    low = mid + 1;
                }
                else if (HasMissingVowel(mid, i + 1))
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            var end = high;

            ans += end - start + 1;
        }

        return ans;

        int GetConstantsDiff(int from, int to) => counts[to].Consonants - counts[from].Consonants;

        bool HasMissingVowel(int from, int to) =>
            counts[from].A == counts[to].A
            || counts[from].E == counts[to].E
            || counts[from].I == counts[to].I
            || counts[from].O == counts[to].O
            || counts[from].U == counts[to].U;
    }

    private record Count(int A, int E, int I, int O, int U, int Consonants);
}
