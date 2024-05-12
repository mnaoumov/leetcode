using JetBrains.Annotations;

namespace LeetCode.Problems._3076_Shortest_Uncommon_Substring_in_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-388/submissions/detail/1199102554/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] ShortestSubstrings(string[] arr)
    {
        var n = arr.Length;
        var ans = Enumerable.Repeat("", n).ToArray();

        for (var i = 0; i < n; i++)
        {
            var s = arr[i];

            for (var length = 1; length <= s.Length; length++)
            {
                var substrings = new List<string>();

                for (var j = 0; j <= s.Length - length; j++)
                {
                    substrings.Add(s[j..(j + length)]);
                }

                substrings.Sort();

                foreach (var substring in substrings)
                {
                    var isMatch = true;

                    for (var k = 0; k < n; k++)
                    {
                        if (k == i)
                        {
                            continue;
                        }

                        if (!arr[k].Contains(substring))
                        {
                            continue;
                        }

                        isMatch = false;
                        break;
                    }

                    if (!isMatch)
                    {
                        continue;
                    }

                    ans[i] = substring;
                    break;
                }

                if (ans[i] != "")
                {
                    break;
                }
            }
        }

        return ans;
    }
}
