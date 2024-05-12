using JetBrains.Annotations;

namespace LeetCode.Problems._3006_Find_Beautiful_Indices_in_the_Given_Array_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-380/submissions/detail/1145542723/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> BeautifulIndices(string s, string a, string b, int k)
    {
        var ans = new List<int>();

        for (var i = 0; i <= s.Length - a.Length; i++)
        {
            if (s[i..(i + a.Length)] != a)
            {
                continue;
            }

            var hasJ = false;

            for (var j = Math.Max(0, i - k); j <= Math.Min(s.Length - b.Length, i + k); j++)
            {
                if (s[j..(j + b.Length)] != b)
                {
                    continue;
                }

                hasJ = true;
                break;
            }

            if (hasJ)
            {
                ans.Add(i);
            }
        }

        return ans;
    }
}
