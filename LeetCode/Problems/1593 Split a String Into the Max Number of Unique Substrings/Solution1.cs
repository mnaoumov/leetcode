namespace LeetCode.Problems._1593_Split_a_String_Into_the_Max_Number_of_Unique_Substrings;

/// <summary>
/// https://leetcode.com/submissions/detail/1428852860/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxUniqueSplit(string s)
    {
        return A(0, new HashSet<string>());

        int A(int startIndex, HashSet<string> usedWords)
        {
            var ans = 0;

            for (var endIndex = startIndex + 1; endIndex <= s.Length; endIndex++)
            {
                var word = s[startIndex..endIndex];

                if (!usedWords.Add(word))
                {
                    continue;
                }

                var next = A(endIndex, usedWords);
                usedWords.Remove(word);

                if (next > 0 || endIndex == s.Length)
                {
                    ans = Math.Max(ans, next + 1);
                }
            }

            return ans;
        }
    }
}
