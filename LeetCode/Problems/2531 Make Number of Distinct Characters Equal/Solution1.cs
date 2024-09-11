namespace LeetCode.Problems._2531_Make_Number_of_Distinct_Characters_Equal;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-327/submissions/detail/873767528/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsItPossible(string word1, string word2)
    {
        var letterCounts1 = CountLetters(word1);
        var letterCounts2 = CountLetters(word2);

        foreach (var key1 in letterCounts1.Keys)
        {
            foreach (var key2 in letterCounts2.Keys)
            {
                var count1 = letterCounts1.Keys.Count;
                var count2 = letterCounts2.Keys.Count;

                if (letterCounts1[key1] == 1 && key2 != key1)
                {
                    count1--;
                }

                if (letterCounts2[key2] == 1 && key2 != key1)
                {
                    count2--;
                }

                if (!letterCounts1.ContainsKey(key2))
                {
                    count1++;
                }

                if (!letterCounts2.ContainsKey(key1))
                {
                    count2++;
                }

                if (count1 == count2)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static Dictionary<char, int> CountLetters(string word) =>
        word.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
}
