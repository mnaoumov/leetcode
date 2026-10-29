namespace LeetCode.Problems._3839_Number_of_Prefix_Connected_Groups;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-176/problems/number-of-prefix-connected-groups/submissions/1919026009/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PrefixConnected(string[] words, int k)
    {
        var counts = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (word.Length < k)
            {
                continue;
            }

            var prefix = word[..k];

            counts.TryAdd(prefix, 0);
            counts[prefix]++;
        }

        return counts.Values.Count(count => count > 1);
    }
}
