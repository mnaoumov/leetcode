namespace LeetCode.Problems._3541_Find_Most_Frequent_Vowel_and_Consonant;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-156/problems/find-most-frequent-vowel-and-consonant/submissions/1630142865/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxFreqSum(string s)
    {
        var counts = s.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };

        var maxVowelCount = 0;
        var maxConsonantCount = 0;

        foreach (var (letter, count) in counts)
        {
            if (vowels.Contains(letter))
            {
                maxVowelCount = Math.Max(maxVowelCount, count);
            }
            else
            {
                maxConsonantCount = Math.Max(maxConsonantCount, count);
            }
        }

        return maxVowelCount + maxConsonantCount;
    }
}
