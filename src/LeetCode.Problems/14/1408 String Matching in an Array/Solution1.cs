namespace LeetCode.Problems._1408_String_Matching_in_an_Array;

/// <seealso href="https://leetcode.com/submissions/detail/1500112014/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> StringMatching(string[] words)
    {
        var ans = new List<string>();
        var n = words.Length;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (!words[j].Contains(words[i]))
                {
                    continue;
                }

                ans.Add(words[i]);
                break;
            }
        }

        return ans;
    }
}
