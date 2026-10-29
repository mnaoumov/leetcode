namespace LeetCode.Problems._1358_Number_of_Substrings_Containing_All_Three_Characters;

/// <summary>
/// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/submissions/1569797904/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSubstrings(string s)
    {
        var n = s.Length;
        var counts = new Count[n + 1];
        counts[0] = new Count(0, 0, 0);
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            counts[i + 1] = s[i] switch
            {
                'a' => counts[i] with { A = counts[i].A + 1 },
                'b' => counts[i] with { B = counts[i].B + 1 },
                'c' => counts[i] with { C = counts[i].C + 1 },
                _ => counts[i]
            };

            if (counts[i + 1].A == 0 || counts[i + 1].B == 0 || counts[i + 1].C == 0)
            {
                continue;
            }

            var low = 0;
            var high = i;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (counts[mid].A == counts[i + 1].A || counts[mid].B == counts[i + 1].B ||
                    counts[mid].C == counts[i + 1].C)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            ans += low;
        }

        return ans;
    }

    private record Count(int A, int B, int C);
}