using JetBrains.Annotations;

namespace LeetCode.Problems._2744_Find_Maximum_Number_of_String_Pairs;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-107/submissions/detail/978570061/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumNumberOfStringPairs(string[] words)
    {
        var reverseWords = new HashSet<string>();

        var ans = 0;

        foreach (var word in words)
        {
            if (reverseWords.Contains(word))
            {
                ans++;
                reverseWords.Remove(word);
            }
            else
            {
                var reverseWord = string.Concat(word.Reverse());
                reverseWords.Add(reverseWord);
            }
        }

        return ans;
    }
}
