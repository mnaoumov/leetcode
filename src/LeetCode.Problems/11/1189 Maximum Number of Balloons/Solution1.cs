namespace LeetCode.Problems._1189_Maximum_Number_of_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/856504352/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxNumberOfBalloons(string text)
    {
        var textCounts = CountLetters(text);
        const string target = "balloon";
        var targetCounts = CountLetters(target);

        var result = int.MaxValue;

        foreach (var (letter, count) in targetCounts)
        {
            result = Math.Min(result, textCounts.GetValueOrDefault(letter) / count);
        }

        return result;
    }

    private static Dictionary<char, int> CountLetters(string text) => text.GroupBy(letter => letter).ToDictionary(g => g.Key, g => g.Count());
}
