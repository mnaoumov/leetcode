namespace LeetCode.Problems._2506_Count_Pairs_Of_Similar_Strings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-324/submissions/detail/861385201/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SimilarPairs(string[] words)
    {
        var keys = words.Select(ToKey).ToArray();

        var result = 0;

        for (var i = 0; i < words.Length; i++)
        {
            for (var j = i + 1; j < words.Length; j++)
            {
                if (keys[i] == keys[j])
                {
                    result++;
                }
            }
        }

        return result;
    }

    private static string ToKey(string str) => new(str.Distinct().OrderBy(letter => letter).ToArray());
}
